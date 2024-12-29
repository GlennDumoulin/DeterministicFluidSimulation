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
        float2 aspect_inv = float2(_MainTex_TexelSize.x * _MainTex_TexelSize.w, 1);

        // Color advection with the velocity field
        float2 delta = tex2D(_VelocityField, i.uv).xy * aspect_inv * _DeltaTime;
        float3 color = tex2D(_MainTex, i.uv - delta).xyz;

        // Blend dye with the color from the buffer.
        float2 pos = (i.uv - 0.5) * aspect;

        for (int i = 0; i < _ForceCount; ++i)
        {
            // Dye (injection color)
            float3 dye = saturate(sin((_CurrTime + i * 1.53) * float3(2.72, 5.12, 4.98)) + 0.5);

            float amp = exp(-_ForceExponent * distance(_ForceOrigins[i].xy, pos));
            color = lerp(color, dye, saturate(amp * 100));
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
