using HarmonyLib;
using JumpKing;
using JK = JumpKing.Level;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class ScrollingBackground
{
    public ScrollingBackground(Harmony harmony)
    {
        Type type = typeof(JK.ScrollingBackground);
        MethodInfo Update = type.GetMethod(nameof(JK.ScrollingBackground.Update));
        harmony.Patch(
            Update,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(ScrollingBackground), nameof(preUpdate)))
        );
    }

    private static bool preUpdate() {
        return !Manager.HasFlags(FreezeState.ScrollingBackground);
    }
}