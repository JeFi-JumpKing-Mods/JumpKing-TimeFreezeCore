using HarmonyLib;
using JumpKing;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class LoopingProp
{
    public LoopingProp(Harmony harmony)
    {
        Type type = AccessTools.TypeByName("JumpKing.Props.LoopingProp");
        MethodInfo Update = AccessTools.Method(type, "Update");
        harmony.Patch(
            Update,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(LoopingProp), nameof(preUpdate)))
        );
    }

    private static bool preUpdate() {
        return !Manager.HasFlags(FreezeState.Props);
    }
}