using HarmonyLib;
using JK = JumpKing.Level;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class SandBlock
{
    public SandBlock(Harmony harmony)
    {
        Type type = typeof(JK.SandBlock);
        MethodInfo canBlockPlayerGetter = AccessTools.PropertyGetter(type, "canBlockPlayer");
        harmony.Patch(
            canBlockPlayerGetter,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(SandBlock), nameof(postcanBlockPlayerGetter)))
        );
    }
    private static void postcanBlockPlayerGetter(ref bool __result) {
        if (Manager.HasFlags(FreezeState.Sand)) {
            __result =  true;
        }
    }
}









