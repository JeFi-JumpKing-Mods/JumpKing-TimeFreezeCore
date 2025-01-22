using HarmonyLib;
using JK = JumpKing.Level;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class WaterBlock
{
    public WaterBlock(Harmony harmony)
    {
        Type type = typeof(JK.WaterBlock);
        MethodInfo canBlockPlayerGetter = AccessTools.PropertyGetter(type, "canBlockPlayer");
        harmony.Patch(
            canBlockPlayerGetter,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(WaterBlock), nameof(postcanBlockPlayerGetter)))
        );
    }
    private static void postcanBlockPlayerGetter(ref bool __result) {
        if (Manager.HasFlags(FreezeState.Water)) {
            __result =  true;
        }
    }
}