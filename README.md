Hello everyone, recently I have found source code of Bad Piggies game, 
so I decided to port it on vita.The problem is that there is only source 
of 2.3.6 version of this game made on newer version of Unity than i had to
use for vita. So I had to backport everything, and for now its running not so
good, but I will improve everything later.
Known problems:
- White & purple curves around stone and dirt - caused by some custom Unity LWRP shader
that is unsupported in Unity 2017.Solution - make own shader.I am inexperienced with HLSL :C
- No vehicles can be saved due to PSV data management.Solution - use own JSON method in WPFPrefs.cs
- Most of SFX/BG sounds not working.Caused by asset bundles.If someone could pack two audio bundles
properly...No solution at the moment.
- In-game shop is not working so you can`t buy field of dreams, glue, mechanic etc.
Solution - make hack for unlimited items or rip them away.