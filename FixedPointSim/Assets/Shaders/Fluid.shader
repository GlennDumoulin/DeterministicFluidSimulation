// StableFluids - A GPU implementation of Jos Stam's Stable Fluids on Unity
// https://github.com/keijiro/StableFluids

Shader "Hidden/StableFluids"
{
    Properties
    {
        _MainTex("", 2D) = ""
        _VelocityField("", 2D) = ""
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    // Fixed-point precision setup
#define FRACTIONAL_BITS 22
#define SCALING_FACTOR (1 << FRACTIONAL_BITS)
#define FIXED_ONE SCALING_FACTOR // Represent 1.0 in fixed-point

// Fixed-point conversions
#define TO_FIXED(x) ((int)((x) * SCALING_FACTOR))
#define TO_FLOAT(x) ((float)(x) / SCALING_FACTOR)
#define TO_FIXEDFLOAT(x) (TO_FLOAT(TO_FIXED(x)))

#define TO_FIXED2(v) (int2(TO_FIXED(v.x), TO_FIXED(v.y)))
#define TO_FLOAT2(v) (float2(TO_FLOAT(v.x), TO_FLOAT(v.y)))
#define TO_FIXEDFLOAT2(v) (TO_FLOAT2(TO_FIXED2(v)))

#define TO_FIXED3(v) (int3(TO_FIXED(v.x), TO_FIXED(v.y), TO_FIXED(v.z)))
#define TO_FLOAT3(v) (float3(TO_FLOAT(v.x), TO_FLOAT(v.y), TO_FLOAT(v.z)))
#define TO_FIXEDFLOAT3(v) (TO_FLOAT3(TO_FIXED3(v)))

// Fixed-point arithmetic operations
// #define FIXED_ADD(a, b) ((int)((a) + (b)))
// #define FIXED_SUB(a, b) ((int)((a) - (b)))
// #define FIXED_MUL(a, b) ((int)(((a) * (b)) >> FRACTIONAL_BITS))
// #define FIXED_DIV(a, b) ((int)(((a) << FRACTIONAL_BITS) / (b)))

// #define FIXED_ADD2_S(a, b) (int2(FIXED_ADD(a.x, b), FIXED_ADD(a.y, b)))
// #define FIXED_ADD2_V(a, b) (int2(FIXED_ADD(a.x, b.x), FIXED_ADD(a.y, b.y)))
// #define FIXED_SUB2_S(a, b) (int2(FIXED_SUB(a.x, b), FIXED_SUB(a.y, b)))
// #define FIXED_SUB2_V(a, b) (int2(FIXED_SUB(a.x, b.x), FIXED_SUB(a.y, b.y)))
// #define FIXED_MUL2_S(a, b) (int2(FIXED_MUL(a.x, b), FIXED_MUL(a.y, b)))
// #define FIXED_MUL2_V(a, b) (int2(FIXED_MUL(a.x, b.x), FIXED_MUL(a.y, b.y)))
// #define FIXED_DIV2_S(a, b) (int2(FIXED_DIV(a.x, b), FIXED_DIV(a.y, b)))
// #define FIXED_DIV2_V(a, b) (int2(FIXED_DIV(a.x, b.y), FIXED_DIV(a.y, b.y)))

// #define FIXED_ADD3_S(a, b) (int3(FIXED_ADD(a.x, b), FIXED_ADD(a.y, b), FIXED_ADD(a.z, b)))
// #define FIXED_ADD3_V(a, b) (int3(FIXED_ADD(a.x, b.x), FIXED_ADD(a.y, b.y), FIXED_ADD(a.z, b.z)))
// #define FIXED_SUB3_S(a, b) (int3(FIXED_SUB(a.x, b), FIXED_SUB(a.y, b), FIXED_SUB(a.z, b)))
// #define FIXED_SUB3_V(a, b) (int3(FIXED_SUB(a.x, b.x), FIXED_SUB(a.y, b.y), FIXED_SUB(a.z, b.z)))
// #define FIXED_MUL3_S(a, b) (int3(FIXED_MUL(a.x, b), FIXED_MUL(a.y, b), FIXED_MUL(a.z, b)))
// #define FIXED_MUL3_V(a, b) (int3(FIXED_MUL(a.x, b.x), FIXED_MUL(a.y, b.y), FIXED_MUL(a.z, b.z)))
// #define FIXED_DIV3_S(a, b) (int3(FIXED_DIV(a.x, b), FIXED_DIV(a.y, b), FIXED_DIV(a.z, b)))
// #define FIXED_DIV3_V(a, b) (int3(FIXED_DIV(a.x, b.x), FIXED_DIV(a.y, b.y), FIXED_DIV(a.z, b.z)))

    sampler2D _MainTex;
    float4 _MainTex_TexelSize;

    sampler2D _VelocityField;

#define MAX_INPUTS 10
    float4 _ForceOrigins[MAX_INPUTS];
    int _ForceCount;
    float _ForceExponent;

    float _CurrTime;
    float _DeltaTime;

    half4 frag_advect(v2f_img i) : SV_Target
    {
        // Aspect ratio coefficients
        float2 aspect = float2(_MainTex_TexelSize.y * _MainTex_TexelSize.z, 1);
        aspect = TO_FIXEDFLOAT2(aspect);
        float2 aspect_inv = float2(_MainTex_TexelSize.x * _MainTex_TexelSize.w, 1);
        aspect_inv = TO_FIXEDFLOAT2(aspect_inv);

        // Color advection with the velocity field
        float2 delta = tex2D(_VelocityField, i.uv).xy * aspect_inv * TO_FIXEDFLOAT(_DeltaTime);
        delta = TO_FIXEDFLOAT2(delta);
        float3 color = tex2D(_MainTex, i.uv - delta).xyz;
        color = TO_FIXEDFLOAT3(color);

        // Blend dye with the color from the buffer.
        float2 pos = (i.uv - 0.5) * aspect;
        pos = TO_FIXEDFLOAT2(pos);

        for (int i = 0; i < _ForceCount; ++i)
        {
            // Dye (injection color)
            float3 dye = saturate(
                sin(
                    TO_FIXEDFLOAT(TO_FIXEDFLOAT(_CurrTime) + TO_FIXEDFLOAT(i * 1.53)) *
                    TO_FIXEDFLOAT3(float3(2.72, 5.12, 4.98))
                ) + 0.5
            );
            dye = TO_FIXEDFLOAT3(dye);

            float amp = exp(
                TO_FIXEDFLOAT(-_ForceExponent) *
                TO_FIXEDFLOAT(distance(TO_FIXEDFLOAT2(_ForceOrigins[i].xy), pos))
            );
            amp = TO_FIXEDFLOAT(amp);
            color = lerp(
                color, dye,
                saturate(amp * 100)
            );
            color = TO_FIXEDFLOAT3(color);
        }

        return half4(color, 1);
    }

    half4 frag_render(v2f_img i) : SV_Target
    {
        half3 rgb = tex2D(_MainTex, i.uv).rgb;

        // Mixing channels up to get slowly changing false colors
        //rgb = sin(float3(3.43, 4.43, 3.84) * rgb +
        //          float3(0.12, 0.23, 0.44) * _Time.y) * 0.5 + 0.5;

        return half4(GammaToLinearSpace(rgb), 1);
    }

    ENDCG

    SubShader
    {
        Cull Off ZWrite Off ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag_advect
            ENDCG
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag_render
            ENDCG
        }
    }
}
