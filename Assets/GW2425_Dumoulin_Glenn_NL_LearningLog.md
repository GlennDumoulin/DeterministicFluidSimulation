# Grad Work - Learning Log


## Summer Vacation

Ideas for Grad Work:

- Networked Physics  
 --> I would like to learn about networking because it's not a topic we see during GD courses.  
 --> Networking itself is not very interesting.  
 --> I remembered a conversation I had with someone at the networking evening during the LA study trip in 2024. He gave me the idea to do something with networked physics because the challenge is to make sure the physics yield the exact same results on every device.


## Kick-Off Week

I had a short chat with Alex Vanden Abeele who told me Networked Physics is an interesting topic because of the deterministic physics that need to happen. So that's good news for me, I found my Grad Work topic.

When I asked who I could ask to be my supervisor he suggested Thomas Goussaert, Tom Tesh & himself amongst some other teachers who I didn't have courses from and thus don't really know.

Armed with this newly acquired knowledge I submitted the following for the topic assignment:  
1. Network-based Physics, I want to learn about networking and I figured researching deterministic physics through networking would make for an interesting topic.
2. Game Development
3. Thomas Goussaert or Alex Vanden Abeele


## Topic Discussion

For the topic discussion I had to learn about the SOTA of my topic and looked at the following sources:  
1. [Introduction to Networked Physics](https://gafferongames.com/post/introduction_to_networked_physics/) | Search Terms: Networked Physics  
 --> short introduction to a few popular techniques for doing networked physics (deterministic lockstep, snapshot interpolation & state synchronization)

2. [Networking Physics / Lockstep VS State sync (Next Gen Networked Games Episode 2)](https://youtu.be/9OjIDko1uzc?si=2g1PsLk4g91p95Cw) | Search Terms: Networked Physics  
 --> visualization of the `1. Introduction to Networked Physics` article

3. [TCP vs UDP: What’s the Difference and Which Protocol Is Better?](https://www.avast.com/c-tcp-vs-udp-difference) | Search Terms: networking TCP vs UDP for gaming  
 --> short overview of the working and use-cases for TCP and UDP

4. [Networked Physics Challenges - Q&A](https://daily.dev/blog/networked-physics-challenges-qanda) | Search Terms: Networked Physics  
 --> overview of some common challenges and possible solutions  
 --> _DISMISSED_ complex topics | Reason: Out of Scope

5. [Client-side prediction](https://en.wikipedia.org/wiki/Client-side_prediction) | Search Terms: Networking Client Prediction  
 --> explains client-side prediction

6. [Networked Physics](https://www.simoneriksson.com/networked-physics) | Search Terms: Networked Physics  
 --> _DISMISSED_ shallow explanation of implementation in custom engine | Reason: Not Very Usefull


I got assigned Alex Vanden Abeele as my supervisor and Kasper Geeroms as my coach.

Some feedback I got during and after my topic discussion with Alex:  
[My Notes]  
- Multiplayer Game Programming <-- book available in Howest library
- Explore Game Engines (Networking and Physics options/capabilities)
- Think of a specific case study

[Supervisor Feedback]  
- Specifieer iets kleiner game domein waarin de physics zou moeten gebeuren
- Lees multiplayer networking
- Ga naar de plenaire sessies
- Denk over de case study
- Explore game engines en wat ze bieden wat betreft physics en networking


## Literature Study

In preparation for the literature study I need to decide on a more specific case study. Alex gave me some suggestions such as vehicle physics or some sort of simulation like a fluid. The fluid simulation idea intrigued me but I'll need to gather some information about them.

I also need to explore some game engines because I only have experience with Unreal Engine and Unity. Some engines, and their networking and physics options/capabilities, I want to take a look at are:  
- Unreal Engine 5
- Unity 6
- CryEngine 5
- Godot
- GameMaker

To gather this information I looked at the following sources:  
1. [But How DO Fluid Simulations Work?](https://youtu.be/qsYE1wMEMPA?si=vn8H7uEYsQaBL4Sk) | Search Terms: how do fluid simulations work  
 --> explains how fluid simulations work using Navier-Stokes Equations, Diffusion & Advection whilst also Clearing Divergence

2. [Computational fluid dynamics](https://en.wikipedia.org/wiki/Computational_fluid_dynamics) | Search Terms: how does fluid simulation work  
 --> _DISMISSED_ describes what CFD is and it's history, not related to games | Reason: Not Relevant

3. [Navier–Stokes equations](https://en.wikipedia.org/wiki/Navier%E2%80%93Stokes_equations) | Search Terms: navier stokes equation  
 --> in-depth explanation of the Navier-Stokes Equations and how different situations impact them, such as Newtonian fluids

4. [Newtonian fluid](https://en.wikipedia.org/wiki/Newtonian_fluid) | Search Terms: newtonian fluid  
 --> explains what Newtonian fluids are  
 --> _DISMISSED_ compressible fluids and anisotropic fluids | Reason: Not Relevant

5. [Physics - Unreal Engine 5.5 Documentation](https://dev.epicgames.com/documentation/en-us/unreal-engine/physics-in-unreal-engine) | Search Terms: unreal engine networked physics  
 --> overview of Unreal Engine's Chaos Physics  
 --> _DISMISSED_ all features excluding Networked Physics, Chaos Visual Debugger, Physics Fields and Fluid Simulation | Reason: Not Relevant

6. [Networking Overview for Unreal Engine](https://dev.epicgames.com/documentation/en-us/unreal-engine/networking-overview-for-unreal-engine) | Search Terms: unreal engine networking  
 --> overview of networking in Unreal Engine

7. [Unity - Manual: Physics](https://docs.unity3d.com/Manual/PhysicsSection.html) | Search Terms: unity physics  
 --> overview of different physics engines available in Unity  
 --> _DISMISSED_ all engines except Box2D | Reason: Not Relevant

8. [Unity - Manual: Unity multiplayer overview](https://docs.unity3d.com/Manual/multiplayer.html) | Search Terms: unity multiplayer  
 --> overview of Unity 6's multiplayer features

9. [Unity 6 Unite: Everything new Revealed in 6 Minutes](https://youtu.be/RoS4ahvRJ7g?si=SFWiPat63pR51Pui) | Search Terms: unity 6 networking  
 --> compilation video of new features included in Unity 6  
 --> _DISMISSED_ everything except Multiplayer Center | Reason: Not Relevant

10. [Physics | Unity Multiplayer](https://docs-multiplayer.unity3d.com/netcode/current/advanced-topics/physics/) | Search Terms: unity networked physics  
 --> explains how Unity handles networked physics using NetworkRigidBody(2D)'s

11. [CRYENGINE | Features: Physics](https://www.cryengine.com/features/view/physics) | Search Terms: cryengine networked physics  
 --> overview of some key features of CryEngine's physics solution, including water simulation

12. [Exploring CryEngine: A Game Development Powerhouse](https://medium.com/@be.content23/exploring-cryengine-a-game-development-powerhouse-825b6f5619bd) | Search Terms: cryengine networking  
 --> introduction to CryEngine and it's key features, including Advanced Physics Engine & Networking and Multiplayer Support

I also loaned the book Alex recommended from the Howest library, but I haven't read much of it yet:  
1. [Multiplayer Game Programming](book by Joshua Glazer and Sanjay Madhav)  
 --> in-depth explanation of many relevant industry standards, protocols, techniques and more  
 --> describes the process of creating a multiplayer game including connecting players, handling jittering and latency, syncing data and more  
 --> accessible online at (https://github.com/kurong00/GameProgramBooks/blob/master/11.Multiplayer%20Game%20Programming/Multiplayer%20Game%20Programming.pdf)  
 --> Amazon link (https://www.amazon.com/Multiplayer-Game-Programming-Architecting-Networked/dp/0134034309)


With this newly acquired information this is what my grad work title and case study look like:  
[Title]  
Go with the Flow: Networking a physics-based fluid simulation in different game engines

[Case Study]  
- Create a simple physics-based fluid simulation which runs over a network.
- Do this for multiple different game engines. Possible engines: Unreal Engine 5, Unity 6 & CryEngine V. Maybe Godot and GameMaker, not researched yet.
- Compare the experience and results.


The presentation of my SOTA and current grad work state went awfully. I do feel like I did a decent amount of work for this assignment, but I did not really prepare the presentating itself and just kinda winged it in the moment which caused me to blackout.

From what I was able to tell my fellow students they raised some interesting points I hadn't considered yet. Mainly that the fluid simulation runs on the GPU and that I need to synchronize the simulation on different devices with different GPU's. So I need to figure out how to send the data for the fluid calculations over a network. I also believe I heard Alex mention streaming buffers so I might need to take a look at what that is.

Besides that I also have a bit of an update for my case study because I was told to stick with one game engine and focus on making sure that the fluid is synced for all users. So here is an updated version:  
[Title]  
Go with the Flow: Synchronizing a GPU-based fluid simulation over a network

[Case Study]  
- Create a simple 2D physics-based fluid simulation.
- Run the fluid calculations on the GPU.
- Sync the simulation over a network.


## Coach Session 1

Informal meetup, getting to know fellow students a bit better and what we can expect from our coach during this Grad Work. Basically questions/issues we have that are not directly related to the actual project and more about the course in general or issues/challenges I myself might be facing.


## Research Proposition

For this assignment I need to present a research question and hypotheses, but before I can prepare this I need to look into how to do the fluid calculations on the GPU.

For this I used the following sources:  
1. [Coding Adventure: Simulating Fluids](https://youtu.be/rSKMYc1CQHE?si=U8wt1Ij8EXR1CjT0) | Search Terms: sebastian lague fluid simulation  
 --> theoretical and practical explanation of creating a particle-based fluid simulation  
 --> _DISMISSED_ interesting video to watch but my case study will implement a grid-based fluid and not particle-based | Reason: No Longer Relevant

2. [Unity Fluid Simulation Tutorial: CPU & GPU Methods](https://daily.dev/blog/unity-fluid-simulation-tutorial-cpu-and-gpu-methods) | Search Terms: unity grid-based fluid simulation  
 --> comparison between CPU & GPU implementation for a fluid simulation in Unity

3. [Real-Time Fluid Dynamics for Games](https://www.researchgate.net/publication/2560062_Real-Time_Fluid_Dynamics_for_Games) | Search Terms: jos stam fluid simulation  
 --> simple and rapid implementation of a fluid dynamics solver for game engines

4. [ChatGPT - Networking Fluid Simulations Unity](https://chatgpt.com/share/6714d670-290c-8002-b4c7-899d8904806a) | Search Terms: /  
 --> Chat with ChatGPT about the non-deterministic floating-point calculations in GPU’s  
 --> Discussing some possible solutions such as fixed-point calculations and buffer streaming

5. [Fixed-point arithmetic](https://en.wikipedia.org/wiki/Fixed-point_arithmetic) | Search Terms: fixed-point arithmetic  
 --> explains fixed-point arithmetic and basic operations

6. [How do fixed-point physics (engines) work?](https://gamedev.stackexchange.com/questions/183953/how-do-fixed-point-physics-engines-work) | Search Terms: fixed point arithmetic in games  
 --> compares fixed-point with floating-point with some warnings for common issues/pitfalls

7. [Decoding Numerical Representation: Floating-Point vs. Fixed-Point Arithmetic in Computing](https://dev.to/mochafreddo/decoding-numerical-representation-floating-point-vs-fixed-point-arithmetic-in-computing-3h46) | Search Terms: fixed point arithmetic in gpu  
 --> comparison between floating-point and fixed-point for use-cases, limitations, performance,...


From these sources I learned about something called fixed-point arithmetic to replace the floating-points because floating-point arithmetic are not guaranteed to give the exact same result every time and also not across different devices or different GPU's. This makes floating-point calculations a no-go for my implementation and fixed-points form a great replacement. They are basically just integers so they are deterministic, which is what we need in the first place, but the negative of fixed-points is that the decimal point is fixed (as the name implies) meaning that the range and precision of fixed-points are severly more limited than floating-points.

Let's update our case study again and add the research question and hypotheses now:  
[Research Question]  
- "What are the effects of networking a physics-based fluid simulation on performance and accuracy in a GPU-accelerated environment?"
- "How does networking affect the computational performance and accuracy of a GPU-based fluid simulation?"
- "How does the networking of a physics-based fluid simulation impact performance and accuracy in a GPU-accelerated environment?"

[Hypotheses]  
Performance:  
- H0: "Networking the fluid simulation has no significant impact on the performance (computation time, GPU load) of the simulation."
- H1: "Networking the fluid simulation significantly impacts performance, reducing computational efficiency due to synchronization overhead."
- H2: "Increasing the number of synchronized devices influences the computational efficiency of the simulation."

Accuracy:  
- H0: "Networking the fluid simulation has no significant effect on the accuracy of the simulation, with all synchronized devices maintaining consistent simulation results."
- H1: "Networking the fluid simulation reduces the accuracy of the simulation due to network latency or synchronization errors, resulting in inconsistent fluid behavior across devices."
- H2: "Networking the fluid simulation reduces the accuracy of the simulation due to the use of fixed-point arithmetic, resulting in deterministic but less precise results."

[Case Study]  
- Create a simple 2D physics-based fluid simulation.
- Run the fluid calculations on the GPU.
- Sync the simulation over a network.
- Measure performance and accuracy effects of using fixed-point arithmetic for deterministic GPU calculations.


The meeting with Alex went well. My proposed RQ and hypotheses are good, we also decided that the last RQ I have is the best one of the three.

Some notes from the meeting:  
- What is significant?, this is about the hypotheses and what will be defined as a significant impact on the results.
- First 2 steps of the case study are basically a grad work on it's own, try finding an example/tool online that does this already
  - Shortly after the meeting I went to look for one such tool/implementation to use and found one reasonably fast which looked promising
  - [Stable Fluids](https://github.com/keijiro/StableFluids)  
   --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity


## Experiment(s) & Results

Let's update our case study once again and add some definitions for "Significant":  
[Research Question]  
"How does the networking of a physics-based fluid simulation impact performance and accuracy in a GPU-accelerated environment?"

[Hypotheses]  
Performance:  
- H0: "Networking the fluid simulation has no significant impact on the performance (computation time, GPU load) of the simulation."
- H1: "Networking the fluid simulation significantly impacts performance, reducing computational efficiency due to synchronization overhead."
- H2: "Increasing the number of synchronized devices influences the computational efficiency of the simulation."

H0/H1: "Significant" can be defined as a certain % increase over the non-networked version. The exact % will be decided later possibly based on the initial tests of the non-networked version.
H2: Number of devices to measure results with could range from 2 to 5. This range is subject to change but gives an idea of what should be feasible. Ideally this range gets extended to around 10 devices.

Accuracy:  
- H0: "Networking the fluid simulation has no significant effect on the accuracy of the simulation, with all synchronized devices maintaining consistent simulation results."
- H1: "Networking the fluid simulation reduces the accuracy of the simulation due to network latency or synchronization errors, resulting in inconsistent fluid behavior across devices."
- H2: "Networking the fluid simulation reduces the accuracy of the simulation due to the use of fixed-point arithmetic, resulting in deterministic but less precise results."

H0/H1/H2: "Significant" can be defined as visually noticeable differences between the non-networked and networked versions or between synchronized devices. This requires tests were inputs on the fluid are exactly the same to see if the fluid reacts the same.

[Case Study]  
1. Create a 2D Unity project and add the Stable Fluids GitHub implementation from keijiro.
  - [Stable Fluids](https://github.com/keijiro/StableFluids)  
   --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity
2. Measure performance and accuracy of non-networked version with floating-point arithmetic.
3. Implement fixed-point arithmetic for deterministic GPU calculations in preparation of networking the simulation.
4. Measure performance and accuracy of non-networked version with fixed-point arithmetic.
5. Sync the simulation over a network.
6. Measure performance and accuracy of networked version with fixed-point arithmetic.
7. Measure performance and accuracy with increasing number of synchronized devices.

I'm not really sure how the handle the measuring of the results. My first idea is by logging data, but I fear this logging overhead will also impact the results of the measurements.


Supervisor Meeting Questions/Notes:  
[Questions]  
- Does the Bibliography only contain literature study sources or also case study sources?  
 --> Everything which is referenced in the paper must be included in the bibliography.

[Notes]  
- Does the GitHub implementation not use fixed-point already?  *No, the implementation uses floating-point.*
- Which data has to be sent over the network?  *The inputs that need to be handled by all connected clients. This includes origin and vector of the force, which type of input it is and when it should be handled.*
- Accuracy measurements can be done by logging the fluid state after X amount of seconds (5, 10, 20,...) on all connected clients.
- Update the definitions of "Significant" for the measurements.
- Limit the testing with multiple devices to 2 (or maybe 3) devices on the same local network and use multiple instances of the project on each device to test the scaling.


## Experiment Design

After my meeting with Alex I used the following sources to improve my understanding of Unity's networking and looking into ways to handle the measurements for the case study:  
1. [Stable Fluids](https://github.com/keijiro/StableFluids) | Search Terms: Unity GPU fluid simulation  
 --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity

2. [What's the Unity Standalone Profiler?](https://thegamedev.guru/unity-performance/profiling-standalone-mode/) | Search Terms: Unity standalone profiler  
 --> A short introduction to Unity's Standalone Profiler and how to use it

3. [Unity - Manual: Unity Profiler](https://docs.unity3d.com/6000.0/Documentation/Manual/Profiler.html) | Search Terms: Unity standalone profiler  
 --> overview of the Unity Profiler's features

4. [Save Profiler Details to File](https://discussions.unity.com/t/save-profiler-details-to-file/502106/8) | Search Terms: Unity profiler save to file  
 --> Unity forum about saving profiler details to a file  
 --> bottom response contains code example to extend which data is actually saved

5. [COMPLETE Unity Multiplayer Tutorial (Netcode for Game Objects)](https://youtu.be/3yuBOB3VrCk?si=o-l8tZrkIJTKYicD) | Search Terms: Unity networking tutorial  
 --> Good introduction video to Unity's Netcode for Game Objects (NGO)  
 --> Older video using NGO version 1.0, gives decent idea of the working of different components/features

6. [NetworkTime and ticks | Unity Multiplayer](https://docs-multiplayer.unity3d.com/netcode/current/advanced-topics/networktime-ticks/#example-2-using-network-time-to-create-a-synced-event) | Search Terms: Unity networking time  
 --> example of how to use ServerTime to sync events on all clients


I also got around to actually testing the GitHub implementation I found to see how it works and IF it works to begin with. From this testing I found the following:  
- It works well in Unity 6
- It does not use fixed-points, but regular floating-points
- It requires some changes to be made because it only checks for inputs of the user which is running the application. For my grad work, all connected clients need to be able to interact with the fluid and send these inputs over the network to be handled

Following from that last point some new issues and ideas came to mind:  
- Do I need to make these changes to accept multiple inputs in the beginning of the case study or do I only implement this when it is needed for the networking part?  
 --> Currently I put it in the beginning of the case study but the more I think about it, the more I think I should move it back because the impact it might have on the results are due to the networking needs.
- I can send what kind of input needs to be handled by all clients instead of the results of the inputs. This way all clients do their own calculations and it's definitely not only the host doing all the work and sending results to all clients.
- The inputs that are sent over the network might not arrive at the same time on all clients but a fluid simulation is very sensitive for synchronized events. If one client executes an input a few frames later than another client the state of the fluid could have changed a lot resulting in different states from then onwards between both clients. A possible solution might be to delay the execution of inputs using Unity's ServerTime.  
 --> The delay idea is something that I feel might work for this grad work, but at the same time it feels like a cheap solution that won't work in wider applications. I mostly think this because the fluid state can change a lot in a short period of time, so an input event that doesn't arrive on a certain client or arrives to late can make a big de-sync over time.


Yet another update for the case study. This time also the Experiment Design is added:  
[Hypotheses]  
Performance:  
- H0: "Networking the fluid simulation has no significant impact on the performance (computation time, GPU load) of the simulation."
- H1: "Networking the fluid simulation significantly impacts performance, reducing computational efficiency due to synchronization overhead."
- H2: "Increasing the number of synchronized devices influences the computational efficiency of the simulation."

H0/H1: "Significant" can be defined as a certain % increase over the non-networked version. The exact % will be decided later, possibly based on the initial tests of the non-networked version.  
H2: Number of devices to measure results with should remain limited to 2 (or maybe 3) devices on the same local area network. Each device can run multiple instances of the program asynchronously.  
*NOTE: Increasing the number of instances per device will most likely also reduce computational efficiency.*

Accuracy:  
- H0: "Networking the fluid simulation has no significant effect on the accuracy of the simulation, with all synchronized devices maintaining consistent simulation results."
- H1: "Networking the fluid simulation reduces the accuracy of the simulation due to network latency or synchronization errors, resulting in inconsistent fluid behavior across devices."
- H2: "Networking the fluid simulation reduces the accuracy of the simulation due to the use of fixed-point arithmetic, resulting in deterministic but less precise results."

H0/H1/H2: "Significant" can be defined as exceeding a certain threshold value when subtracting the state of two instances from each other. The exact threshold value will be decided later, possibly based on the initial tests of the non-networked version.  
*NOTE: This requires tests were inputs on the fluid are exactly the same to see if the fluid reacts the same.*

[Case Study]  
1. Create a 2D Unity project and add the Stable Fluids GitHub implementation from keijiro.
  - [Stable Fluids](https://github.com/keijiro/StableFluids)  
   --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity
2. Implement support for multiple unhandled inputs
3. Implement delay to make sure the inputs are handled at the same time on every synchronized client.
4. Measure performance and accuracy of non-networked version with floating-point arithmetic.
5. Implement fixed-point arithmetic for deterministic GPU calculations in preparation of networking the simulation.
6. Measure performance and accuracy of non-networked version with fixed-point arithmetic.
7. Sync the simulation over a network.
8. Measure performance and accuracy of networked version with fixed-point arithmetic.
9. Measure performance and accuracy with increasing number of synchronized clients.

[Experiment Design]  
### What are the concrete measurements you are going to do?

For the performance I will use Unity's Profiler to get performance data for CPU, GPU & Memory Usage. Then compare results from different points in the case study (floating-point, fixed-point & networked) and see how these steps influence the performance of the simulation.

For the accuracy I will log the current state of the fluid after X amount of seconds (5, 10, 20,...). Then subtract the state results from 2 clients that were synchronized and see what the difference is between them.

### What data needs to be sent over the network?

At this point I think that the only thing that needs to be communicated between clients is which inputs need to be handled and when. All the calculations for the impacts of these inputs will be handled by each client itself. The data required for these inputs currently looks like this:

Input Data (21 bytes):  
- Force Origin [vector2]
- Force Vector [vector2]
- Execution Time (using ServerTime) [float]
- Is Stir Input [bool]

### Who are the subjects you are going to test with?

For my tests I only require 2 devices on the same local area network, as mentioned in hypothesis H2 of Performance. So I will only need my brother and his laptop and my own laptop.

### What are the results you expect?

For the performance I expect to prove hypothesis H0 and thus to disprove hypothesis H1. I believe that the networking of a fluid simulation will have some impact on the computation time of the project but I don't think the impact will be of significant size. For the GPU load I expect even less, if any, impact because the networking implementation will not directly interfere with the GPU and it's tasks.

For hypothesis H2 of performance I expect some impact on computational efficiency however I think most impact here will be due to having multiple instances open on each device meaning all those instances will be using the same CPU & GPU. To prove this theory it does require different tests which are out of scope for this research project, but could be seen as possible future work.

For the accuracy I also expect to prove hypothesis H0 and thus to disprove hypothesis H1. I think the accuracy should not suffer from reduced accuracy due to the networking implementation. Though I do believe hypothesis H2 might be proven to be true depending on where the split between the decimal and fractional part will end up. If the decimal part is too small we might not be able to represent big enough values needed for the simulation, but if the fractional part is too small then we will suffer from reduced accuracy because the values won't be precise enough for certain details.

### What parts of the case study/experiment will answer which of the hypotheses?

- Steps 1-4 are the setup of the experiment and serve as an initial measurements. These results will be used to compare against later measurements in order to answer the following hypotheses: Performance H0/H1 and Accuracy H0/H1.
- Steps 5-6 handle the implementation and measurements of fixed-point arithmetic. These results will be used to answer hypothesis H2 from Accuracy.
- Steps 7-8 handle the implementation and measurements of networking. These results will be used to answer the following hypotheses: Performance H0/H1 and Accuracy H0/H1.
- Step 9 handles the measurements of increasing amounts of synchronized clients. These results will be used to answer hypothesis H2 from Performance.


## Coach Session 2

This coach session is about the reflection report that we will need to make. The preparations for this began with a reality check for me because I didn't really use a learning log. I wrote down some feedback and notes from meetings with my supervisor, but some things were in a markdown file, others in a note on my phone and feedback on my assignments were only on the Leho assignments themself. So I had to retrace my steps throughout the entire grad work this far and collect everything in this document, which took a substantial amount of time and effort I should have probably put into more important things.

Now for the actual preparations for the coach session:  
[Planning & Time Management]  
My way of "planning" is mostly tracking what I need to do split up in smaller tasks. I don't really plan when I will do which tasks because it actually stresses me out more than it helps me be more productive.

I am an overthinker and a perfectionist so if I do make a planning and I notice I'm taking too long to complete the tasks I planned for the day, then I either work faster and therefore make more mistakes resulting in having to work even longer on a certain task, or I simply get stuck in a state of not being able to do anything at all and just stare at my screen.

I also sometimes have issues focussing on one thing. Even though I have less things to do for school than most, if not all, of my fellow students yet I still feel like I have to many things that I need to do and things that I want to do for myself and others.

[Risk Assessment]  
Being a perfectionist and always wanting to give 200% of myself for everything leads to me often overestimating what I can do in a certain amount of time. This was also the case during grad work and might still be the case at the time of writing this. I had to change my case study many times already because what I present may be nice and interesting case studies and research projects but they are not viable for this grad work course. In the beginning I was going to compare multiple game engines with each other instead of focussing on one game engine and making sure it works, then I was going to create the fluid simulation on the GPU myself instead of finding a tool or implementation online to allow me to focus on the networking part of the research project, and now I believe it might still be a bit too ambitious because of the amount of quite significant changes I need to make to the implementation I found online.

The positive is of course that the project is definitely ambitious enough to form an interesting research project. I think the biggest risk of this project is that I need to figure out a couple of important things while working on the case study or I need to create some smaller test projects. Whatever I end up choosing will take some time that I won't be spending on the actual case study.

[SWOT]  
Strengths & Weaknesses:  
I firmly believe that my strengths are also my weaknesses. I have a very unique and complex topic/project, something I did not find anything about when looking at the Zotero library of Howest. So the project definitely stands out from others due to its "one of a kind" nature, but on the contrary it also means I did not have a starting point or something to base my project on.

The complexity of the subject and the lack of almost any knowledge about it made it so that I had to not just research but also discover and learn everything.


Opportunities & Threats:  
I'm not sure I understand this part correctly but I would say something I can use which helps a lot for my research project is the networking implementation that's by default present in Unity making it a lot easier for people to create multiplayer/networked experiences. Also the GitHub implementation I found is extremely helpful as a starting point for my case study. But if these things give my project a competitive edge is something I'm not sure about.

For threats I find this even harder to think of something. Maybe something could be that if there was a generalization of how GPU's should implement floating-point arithmetic and guarantying that the results are deterministic across all devices and GPU's, it would erase the need of using fixed-point arithmetic which is something I will need to take some time for to implement.

[Future Work]  
- Expand the networking to support Wide Area Network connections. This will increase RTTs (Round-Trip Times) because the packets have to travel further, but I don't expect there to be significant impacts on the performance and accuracy of the fluid simulation. I do think my approach of delaying inputs for synchronized execution will have to be changed because either some clients might not receive the inputs on time to be executed or the delay would be too long and become noticeable by users.
- Expand fluid simulation to 3D. This will increase the amount of data that needs to be sent over the network because vectors are now vector3's instead of vector2's.

[Reflection]  
In my opinion I have done a decent job so far in delivering results that meet expectations. But I also know I could have done more already such as begin working on the case study or writing the literature study text for the paper. I will need to focus a bit harder to make sure I end up with a successful research project.

I'm not sure if I won't make the same mistake again of overestimating the scope of a project, but at least I have some more experience now thanks to the continuous feedback I got from my supervisor Alex who helped me scope down the project to a feasible size and focussing on the core of what I actually wanted to research, that core in this case being synchronization over a network.

I don't think I really learned new things about myself during this project but I definitely got reminded of some things I often seem to forget until it's to late for big changes, for example that I always will overthink basically everything and only be satisfied when a result is exactly as I imagined it in an ideal scenario. I know these things about myself but the perfectionist in me tends to ignore them in the hopes I'll achieve those ambitious end results I picture in my head.

I probably should have done some more practical research already to figure out some things I'm still uncertain about how I will need to handle them in the case study. Or maybe those are simply part of the process of executing the case study.


## After Coach Session 2 - 3/12

Apparently the coach session was more an explanation of what is expected from the reflection report, but having done some thinking about these topics will probably help. I know I struggle with plannings but I should try to at least have a list of all tasks I need to do and some simple sprint planning.

I have been experiencing some sort of work block where even though I'm sitting behind my laptop for 6+ hours with at least some idea of what I would like to do that day, I don't make any progress at all. I think the struggle of not finding an internship is affecting my mental and overshadowing everything else I try to focus on.


## 4/12

Today I felt a bit better when I tried working and I spent some time improving my understanding of the different topics included in the reflection report (Risk Assessment, SWOT, Critical Reflection,...).

I started thinking of some risks that might interfere with the project and thought of some responses to each risks in case they do happen to occur.

I decided to take things a bit slower today then I would usually do because of the past few days with nothing to show for it. Of course this means I once again have little progress, I do feel better because I lowered my expectations and I feel a bit more energized to continue working tomorrow.


## 5/12

I continued working on the risk assessment. Looking back at the preparations I did for the second coach session, I think my risk assessment at that point was more fitting as a part of the critical reflection instead.

I also revised my SWOT analysis but what I already did for this part was already a decent SWOT analysis. I mainly did some rephrasing and moving points between categories (strength <--> opportunity) to correct positioning of internal and external factors.


## 6/12 (My Birthday)

I know it seems like a bad habit at this point but today will be a short work day because it's my birthday and I can decide when I work on this project. So today I want to get started on retracing my project planning so far and future steps.

The project planning up to this point of grad work has been made but for the tentative planning of future steps in the project is a bit more difficult. I spent some time thinking about how to handle the future planning but haven't written anything down yet.


## 9/12

Back to grad work after a busy weekend. I didn't have much time to really sit down and focus on getting something done, but today I want to finish my tentative planning for the remainder of grad work.

I noticed that the exam presentation planning went online on Leho, and I will have to go on January 13 at 10:06. This means I am one of the very first ones to have my final presentation. Also means I am one of the first ones to be done with grad work, which for me also means I'm done for this semester early. From today there are exactly 5 weeks remaining until this presentation so I will have to start working a bit harder to meet the deadline.

I did not really meet my expectations today. I was able to make some progress but some other things came up today which needed my attention such as a mail I had to send to my coach Kasper Geeroms about how I should include this learning log into the reflection report because it seems to already be quite a lengthy document.

Kasper suggested placing an excerpt of my learning log from the past few weeks to give an idea of my logging and add the full document as an appendix in the end. Instead of an appendix I will attach this document itself to the pdf to reduce the length of the document.


## 10/12

I created a Trello board today for my tentative planning: https://trello.com/b/e3n4wvjc/grad-work. I will use this board for all tasks that still need to be done, or I am currently doing, for this grad work. This means not only the case study but also the manuscript and reflection report. I will not create tasks and lists for things I have already done for previous milestones because this would just waste time without a real benefit besides having a clear overview of when I've done which tasks.

I also wrote down the schedule for past milestones and upcoming sprints. Because I know how plannings can impact me I will only specify a main focus for each sprint and not go into too much detail about the tasks.

Tomorrow I have a meeting with my internship coach because my search hasn't been going well and I want to discuss what I should do next in the process. For tomorrow I also want to add all tasks I can think of that need doing for the case study. Then I can also define a main focus for the upcoming sprints because without tasks predefined this is pretty difficult.


## 11/12

I had my meeting with my internship coach and I basically have two options:  
1. Be less selective and contact a lot more companies
2. Delay internship to first semester next year, which is not recommended but an option nonetheless

So I did spend some time after the meeting to look for some more companies that I can contact for a possible internship, most of them are from the Howest internship tool but some are companies I haven't contacted yet because I wasn't sure if it would be a great fit for me. I will not contact the companies today because I do need to make sure my reflection report is done in time for the assignment.

When I began adding the tasks for the case study to my Trello board, I realized I had put off making some decisions about my case study. For example my doubt I expressed earlier about when to execute the multiple inputs and delay steps because they are more related to the networking implementation and might impact earlier measurements. After some consideration I will move the delay step back because it doesn't affect the architecture of the simulation.

While adding the tasks it seems like something isn't right. I can't move implementing the delay back because for my accuracy measurements I need a way to execute the same set of inputs for each measurement iteration, measuring each iteration with different inputs holds no value at all. So I've decided to create a basic version of a delay system in the beginning of the project and then during network implementation update it for the synchronization requirements.

Here follows the updated case study:  
[Case Study]  
1. Create a 2D Unity project and add the Stable Fluids GitHub implementation from keijiro.
  - [Stable Fluids](https://github.com/keijiro/StableFluids)  
   --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity
2. Implement basic delay system
3. Implement support for multiple unhandled inputs
4. Create system to replay inputs
5. Measure performance and accuracy of non-networked version with floating-point arithmetic.
6. Implement fixed-point arithmetic for deterministic GPU calculations in preparation of networking the simulation.
7. Measure performance and accuracy of non-networked version with fixed-point arithmetic.
8. Sync the simulation over a network.
9. Update delay system to make sure the inputs are handled at the same time on every synchronized client.
10. Measure performance and accuracy of networked version with fixed-point arithmetic.
11. Measure performance and accuracy with increasing number of synchronized clients.


## 13/12

Today I began working on the centralized document to contain all the reflection report topics. I also noticed I forgot to prepare my critical reflection so I added a task to my Trello board.

I hope to finish this document tomorrow and then Sunday I can start doing the project setup. I will add my learning log as a document in the GitHub repository I will create for the project. This way I have a link to the full learning log for in the reflection report and for the submission at the end of the project.


## 14/12

I did not completely finish the document as I hoped to do today but most parts of it are done. All that remains for tomorrow is the Learning Log and Critical Reflection parts. This shouldn't be too much extra work for tomorrow, but I might have to delay sending new mails to companies for an internship until Monday.


## 15/12

The Learning Log was, as expected, not that much work. But the Critical Reflection took a bit longer than I anticipated because I forgot to prepare this topic like I did for all the other topics. However I think it turned out good and with a bit of help from ChatGPT to rephrase it a bit, it also reads better.

Last thing I had to do before submitting the Reflection Report was to create the GitHub repository where my learning log would be available together with all the rest of my grad work (case study projects, manuscript,...) and add the URL to the full Learning Log.

After submitting the assignment I decided to call it quits for today and enjoy a free evening and play a board game with my parents. This does mean I will not have completed everything I had planned for this milestone, but the project setup was a secondary focus in my Time Management for this milestone so it's not that bad.

Tomorrow marks the beginning of the next milestone: the manuscript draft. Although, the first day of the new milestone will not be spent working on the manuscript draft. My goal for tomorrow is to finish the project setup and send the mails to companies for an internship which I also hoped to do somewhere this week but will be moved back a tiny bit.


## 16/12

First thing I did today was re-evaluate the tasks I want to-do this during this milestone. The main focus remains working on the manuscript draft, but I also need to finish the project setup and preferably start working on the first steps of the case study.

I finished the project setup and took some time to get more familiar with the code base I will be starting the project from. The last thing I did today was to contact some companies for my internship.


## 17/12

I started by configuring the build settings for the project and played a bit with Unity's Profiler to get a better understanding of how it works. This also led me to discover that I will need to create a custom Profiler because I can only profile one instance using Unity's Profiler.

I need to create the custom one before I execute any measurements because all tests need to use the same environment except for the changes we want to compare against each other. So I also spent a bit of time looking into how I can do this.

Final thing I did today was to get started on the manuscript. I didn't do much yet but future work and appendices are ready for now.


## 18/12

Today I want to get started on the Literature Review of the Manuscript Draft. First thing to do is decide what topics should be included within this section and in what order I should present them.

Here follows an overview of the topics I want to explain:  
1. Fluid Simulations
  - Particle-based Simulations
  - Grid-based Simulations
  - GPU Acceleration
2. Determinism in GPU-based Environments
  - Determinism
  - Non-deterministic Floating-point Arithmetic
  - Fixed-point Arithmetic
3. Networking
  - TCP and UDP
  - Network Topologies
	- Client-server Architecture
	- Peer-to-peer Architecture
  - Networking Challenges
    - Latency
	- Packet Loss
  - Networking in Unity
4. Synchronization Techniques
  - State Synchronization
  - Input Synchronization
  - Handling Desynchronization


## 19/12

I knew the Literature Review would be a lot of work, but I still underestimated how long this would take. I hope to get the draft done before the weekend. I also want to get more progress done on the case study this week so I am deciding to push anything other than the Literature Review for the Manuscript Draft back to the very end of the week and work on the case study after I am done with the Literature Review.

The draft version of the Literature Review will not include any images yet, but hopefully most, if not all, references should be in place. Using my Zotero Library from within Microsoft Word is super helpful because adding a citation automatically updates the references list at the end of the paper following my chosen citation style, IEEE.


## 20/12

I really hope to finish the Literature Review today, but it might still be a bit too much work. Any topics not yet drafted by the end of tomorrow will have to wait until after the draft submission because like I said earlier, I really want to get some more progress done on the Case Study this week.

I also don't have that much time to work tomorrow, so I will most likely fail again to reach my goal for this week. This also makes me a bit worried for the research as a whole, because everything that has to move over to the next sprint makes that sprint itself less doable.


## 21/12

Like I mentioned yesterday, I didn't have a lot of time to work at all today. I did an activity with my parents and brother for my mom's birthday.

Sadly, once again basically all my time today went to the Literature Review, which luckily is finished now (the draft at least). I found it very difficult to write this part because I struggled a lot with deciding what I should explain more or less and how to paraphrase it to make sure the message is conveyed in a clear way for readers of multiple skill-levels.

Tomorrow, I am finally going to work on the Case Study again and hopefully get a lot of progress to minimize the increase in workload for the next sprint(s).


## 22/12

So I finally got started on the Case Study and well, it's for the best because I have been struggling for many hours today with setting up the project to begin with the floating-point measurements. I still haven't figured out how I can combine multiple inputs to be handled in a single dispatch call of the compute shader because somehow when I send all inputs at once, none get handled. I hope that when I finally get it working and I can move on to regular C# scripts again, and not shaders and compute shaders, that things will speed up. Not only do I hope that's the case I pretty much need it to.

I had also hoped to maybe sneak in an introduction and maybe the abstract & keywords for the manuscript draft, but because of the troubles in the Case Study that also didn't happen. I did submit the little bit I have done because at least I can get feedback on the Literature Review.

Looking back at the past milestone period, I don't really know what went so wrong. I did spend a lot of time brainstorming for solutions to newly discovered issues such as the Unity Profiler actually not being what I needed it to be and having a lot more work on the Literature Review than anticipated. I did look into the usability of the Unity Profiler before this milestone but my research was clearly not thorough enough, which could have saved me a lot of time during this milestone.


## 23/12

I had my first meeting with a company for my internship and got two more reactions from other companies who intvited me to a first meeting. I'm happy that my internship search is finally starting to get somewhere even if these first couple of companies don't end up working out. The only added difficulty now is that a lot of companies want to do a coding test, which means I have to make time for these tests besides working on this grad work.

There is a lot to do this week if I want to get back on track with my original planning and annoyingly most of today was spent on getting the fluid simulation to work again since it fully broke down yesterday when trying to batch forces in a singular `Dispatch()` call.

The mistake I made took me way more hours than I like to admit but I finally figured it out. Instead of using `VFB.V3 = VFB.V2` I had to use `Graphics.CopyTexture(VFB.V2, VFB.V3)`. The prior approach actually makes both variables share the same texture, which completely broke the updating of the simulation. I thought something was going wrong in the compute shader, so many hours were waisted on debugging something that wasn't even causing issues.


## 24/12

I finished up handling multiple inputs in a singular `Dispatch()` call after finally solving the bug yesterday, and then I had to do same in the shader to handle multiple pour inputs. You might be able to guess it, but this also came with some troubles. This time luckily not that bad as with the compute shader.

After that I also made sure that multiple pour inputs would not inject the same dye color into the fluid, by adding an offset to the current time based on the index of the input being handled. This way there is some variation in dies if there are multiple pour inputs, but the results should still be deterministic. Too guarantee deterministic execution order I will need to sort the inputs, potentially based on the client index.

The final thing I began to work on today was the saving of inputs to a file. This way we can later reload the same inputs to test deterministic results and for the accuracy measurements.



## References overview

### Case Study - References

Online Sources:  
1. [Stable Fluids](https://github.com/keijiro/StableFluids) | Search Terms: Unity GPU fluid simulation  
 --> A straightforward GPU implementation of Jos Stam's "Stable Fluids" on Unity

2. [What's the Unity Standalone Profiler?](https://thegamedev.guru/unity-performance/profiling-standalone-mode/) | Search Terms: Unity standalone profiler  
 --> A short introduction to Unity's Standalone Profiler and how to use it

3. [Unity - Manual: Unity Profiler](https://docs.unity3d.com/6000.0/Documentation/Manual/Profiler.html) | Search Terms: Unity standalone profiler  
 --> overview of the Unity Profiler's features

4. [Save Profiler Details to File](https://discussions.unity.com/t/save-profiler-details-to-file/502106/8) | Search Terms: Unity profiler save to file  
 --> Unity forum about saving profiler details to a file  
 --> bottom response contains code example to extend which data is actually saved

5. [COMPLETE Unity Multiplayer Tutorial (Netcode for Game Objects)](https://youtu.be/3yuBOB3VrCk?si=o-l8tZrkIJTKYicD) | Search Terms: Unity networking tutorial  
 --> Good introduction video to Unity's Netcode for Game Objects (NGO)  
 --> Older video using NGO version 1.0, gives decent idea of the working of different components/features

6. [NetworkTime and ticks | Unity Multiplayer](https://docs-multiplayer.unity3d.com/netcode/current/advanced-topics/networktime-ticks/#example-2-using-network-time-to-create-a-synced-event) | Search Terms: Unity networking time  
 --> example of how to use ServerTime to sync events on all clients


### Literature Study - References

Online Sources:  
1. [Introduction to Networked Physics](https://gafferongames.com/post/introduction_to_networked_physics/) | Search Terms: Networked Physics  
 --> short introduction to a few popular techniques for doing networked physics (deterministic lockstep, snapshot interpolation & state synchronization)

2. [Networking Physics / Lockstep VS State sync (Next Gen Networked Games Episode 2)](https://youtu.be/9OjIDko1uzc?si=2g1PsLk4g91p95Cw) | Search Terms: Networked Physics  
 --> visualization of the `1. Introduction to Networked Physics` article

3. [TCP vs UDP: What’s the Difference and Which Protocol Is Better?](https://www.avast.com/c-tcp-vs-udp-difference) | Search Terms: networking TCP vs UDP for gaming  
 --> short overview of the working and use-cases for TCP and UDP

4. [Networked Physics Challenges - Q&A](https://daily.dev/blog/networked-physics-challenges-qanda) | Search Terms: Networked Physics  
 --> overview of some common challenges and possible solutions  
 --> _DISMISSED_ complex topics | Reason: Out of Scope

5. [Client-side prediction](https://en.wikipedia.org/wiki/Client-side_prediction) | Search Terms: Networking Client Prediction  
 --> explains client-side prediction

6. [Networked Physics](https://www.simoneriksson.com/networked-physics) | Search Terms: Networked Physics  
 --> _DISMISSED_ shallow explanation of implementation in custom engine | Reason: Not Very Usefull

7. [But How DO Fluid Simulations Work?](https://youtu.be/qsYE1wMEMPA?si=vn8H7uEYsQaBL4Sk) | Search Terms: how do fluid simulations work  
 --> explains how fluid simulations work using Navier-Stokes Equations, Diffusion & Advection whilst also Clearing Divergence

8. [Computational fluid dynamics](https://en.wikipedia.org/wiki/Computational_fluid_dynamics) | Search Terms: how does fluid simulation work  
 --> _DISMISSED_ describes what CFD is and it's history, not related to games | Reason: Not Relevant

9. [Navier–Stokes equations](https://en.wikipedia.org/wiki/Navier%E2%80%93Stokes_equations) | Search Terms: navier stokes equation  
 --> in-depth explanation of the Navier-Stokes Equations and how different situations impact them, such as Newtonian fluids

10. [Newtonian fluid](https://en.wikipedia.org/wiki/Newtonian_fluid) | Search Terms: newtonian fluid  
 --> explains what Newtonian fluids are  
 --> _DISMISSED_ compressible fluids and anisotropic fluids | Reason: Not Relevant

11. [Physics - Unreal Engine 5.5 Documentation](https://dev.epicgames.com/documentation/en-us/unreal-engine/physics-in-unreal-engine) | Search Terms: unreal engine networked physics  
 --> overview of Unreal Engine's Chaos Physics  
 --> _DISMISSED_ all features excluding Networked Physics, Chaos Visual Debugger, Physics Fields and Fluid Simulation | Reason: Not Relevant  
 --> _DISMISSED_ case study no longer uses Unreal Engine | Reason: No Longer Relevant

12. [Networking Overview for Unreal Engine](https://dev.epicgames.com/documentation/en-us/unreal-engine/networking-overview-for-unreal-engine) | Search Terms: unreal engine networking  
 --> overview of networking in Unreal Engine  
 --> _DISMISSED_ case study no longer uses Unreal Engine | Reason: No Longer Relevant

13. [Unity - Manual: Physics](https://docs.unity3d.com/Manual/PhysicsSection.html) | Search Terms: unity physics  
 --> overview of different physics engines available in Unity  
 --> _DISMISSED_ all engines except Box2D | Reason: Not Relevant

14. [Unity - Manual: Unity multiplayer overview](https://docs.unity3d.com/Manual/multiplayer.html) | Search Terms: unity multiplayer  
 --> overview of Unity 6's multiplayer features

15. [Unity 6 Unite: Everything new Revealed in 6 Minutes](https://youtu.be/RoS4ahvRJ7g?si=SFWiPat63pR51Pui) | Search Terms: unity 6 networking  
 --> compilation video of new features included in Unity 6  
 --> _DISMISSED_ everything except Multiplayer Center | Reason: Not Relevant

16. [Physics | Unity Multiplayer](https://docs-multiplayer.unity3d.com/netcode/current/advanced-topics/physics/) | Search Terms: unity networked physics  
 --> explains how Unity handles networked physics using NetworkRigidBody(2D)'s

17. [CRYENGINE | Features: Physics](https://www.cryengine.com/features/view/physics) | Search Terms: cryengine networked physics  
 --> overview of some key features of CryEngine's physics solution, including water simulation  
 --> _DISMISSED_ case study no longer uses CryEngine | Reason: No Longer Relevant

18. [Exploring CryEngine: A Game Development Powerhouse](https://medium.com/@be.content23/exploring-cryengine-a-game-development-powerhouse-825b6f5619bd) | Search Terms: cryengine networking  
 --> introduction to CryEngine and it's key features, including Advanced Physics Engine & Networking and Multiplayer Support  
 --> _DISMISSED_ case study no longer uses CryEngine | Reason: No Longer Relevant

19. [Coding Adventure: Simulating Fluids](https://youtu.be/rSKMYc1CQHE?si=U8wt1Ij8EXR1CjT0) | Search Terms: sebastian lague fluid simulation  
 --> theoretical and practical explanation of creating a particle-based fluid simulation  
 --> _DISMISSED_ interesting video to watch but my case study will implement a grid-based fluid and not particle-based | Reason: No Longer Relevant

20. [Unity Fluid Simulation Tutorial: CPU & GPU Methods](https://daily.dev/blog/unity-fluid-simulation-tutorial-cpu-and-gpu-methods) | Search Terms: unity grid-based fluid simulation  
 --> comparison between CPU & GPU implementation for a fluid simulation in Unity

21. [Real-Time Fluid Dynamics for Games](https://www.researchgate.net/publication/2560062_Real-Time_Fluid_Dynamics_for_Games) | Search Terms: jos stam fluid simulation  
 --> simple and rapid implementation of a fluid dynamics solver for game engines

22. [ChatGPT - Networking Fluid Simulations Unity](https://chatgpt.com/share/6714d670-290c-8002-b4c7-899d8904806a) | Search Terms: /  
 --> Chat with ChatGPT about the non-deterministic floating-point calculations in GPU’s  
 --> Discussing some possible solutions such as fixed-point calculations and buffer streaming

23. [Fixed-point arithmetic](https://en.wikipedia.org/wiki/Fixed-point_arithmetic) | Search Terms: fixed-point arithmetic  
 --> explains fixed-point arithmetic and basic operations

24. [How do fixed-point physics (engines) work?](https://gamedev.stackexchange.com/questions/183953/how-do-fixed-point-physics-engines-work) | Search Terms: fixed point arithmetic in games  
 --> compares fixed-point with floating-point with some warnings for common issues/pitfalls

25. [Decoding Numerical Representation: Floating-Point vs. Fixed-Point Arithmetic in Computing](https://dev.to/mochafreddo/decoding-numerical-representation-floating-point-vs-fixed-point-arithmetic-in-computing-3h46) | Search Terms: fixed point arithmetic in gpu  
 --> comparison between floating-point and fixed-point for use-cases, limitations, performance,...


Physical Sources:  
1. [Multiplayer Game Programming](book by Joshua Glazer and Sanjay Madhav)  
 --> in-depth explanation of many relevant industry standards, protocols, techniques and more  
 --> describes the process of creating a multiplayer game including connecting players, handling jittering and latency, syncing data and more  
 --> accessible online at (https://github.com/kurong00/GameProgramBooks/blob/master/11.Multiplayer%20Game%20Programming/Multiplayer%20Game%20Programming.pdf)  
 --> Amazon link (https://www.amazon.com/Multiplayer-Game-Programming-Architecting-Networked/dp/0134034309)  
 --> short description of interesting parts/chapters:  
   - Chapter 2, The Transport Layer  
    ==> Explains UDP and TCP
   - Chapter 2, The Application Layer  
    ==> This layer contains game code
   - Chapter 3
    ==> Explains Berkeley Socket API and how to create, bind, use,... sockets with it  
	==> Includes code examples for wrappers for API functions
   - Chapter 4  
    ==> Explains how to efficiently serialize data to send the most data in the least amount of packets  
	==> Explains fixed point numbers to save bits when sending floating point numbers of which range and precision limits are known in advance  
	==> Includes code examples for reading from and writing to a stream of serialized data
   - Chapter 5  
    ==> Explains Object Replication to identify objects in the networked environment so all clients know which object needs to be created, updated or destroyed based on their networkID  
	==> Explains RPC's and RMI's which will probably come in handy for my case study to send inputs that need to be handled by the clients  
	==> Includes code examples for linking objects to a networkID, RPC's,...
   - Chapter 6  
    ==> Explains two common-used network topologies: client-server and peer-to-peer  
	==> Explains a technique called input sharing, which I could use by letting each client handle the shared inputs instead of sending results over the network  
	==> Explains seeding a pseudo-randing number generator for deterministic random number generation across clients  
	==> Includes code examples for implementing client-server and peer-to-peer
   - Chapter 7  
    ==> Explains latency, jitter and packet loss  
	==> Includes code examples for creating a custom reliabability layer on top of UDP
   - Chapter 8  
    ==> Explains how to handle latency using techniques like client-side interpolation, client-side prediction, move prediction & replay and server side rewind  
	==> Includes code examples for the techniques explained in this chapter
   - Chapter 9  
    ==> Explains some approaches of handling scalability such as static zones, server partitioning and prioritizing certain objects or RPC's
   - Chapter 10  
    ==> Explains how to improve security of data transmissions by using encryption, input validation or software cheat detection
   - Chapter 11  
    ==> Explains how Unreal Engine 4 and Unity 5 implement networking into their engines
   - Chapter 12  
    ==> Explains some common features included in gamer services like Steam or PlayStation Network  
	==> Includes code examples for Steam implementation of matchmaking, networking, stats, achievements,...
   - Chapter 13  
    ==> Introduction to Cloud Hosting using REST API's, JSON and Node.JS  
	==> Includes code examples for handling processes and virtual machines
