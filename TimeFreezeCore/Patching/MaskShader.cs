using HarmonyLib;
using JumpKing;
using JK = JumpKing;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

// namespace TimeFreezeCore.Patching;
// internal class MaskShader
// {
//     public MaskShader(Harmony harmony)
//     {
//         Type type = typeof(JK.MaskShader);
//         MethodInfo Update = type.GetMethod(nameof(JK.MaskShader.Update));
//         harmony.Patch(
//             Update,
//             prefix: new HarmonyMethod(AccessTools.Method(typeof(MaskShader), nameof(preUpdate)))
//         );
//     }

//     private static bool preUpdate() {
//         return !Manager.HasFlags(FreezeState.Wind);
//     }
// }