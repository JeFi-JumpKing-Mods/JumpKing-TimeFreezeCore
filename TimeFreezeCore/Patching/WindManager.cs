using HarmonyLib;
using JumpKing;
using JK = JumpKing;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class WindManager
{
    public WindManager(Harmony harmony)
    {
        Type type = typeof(JK.WindManager);
        MethodInfo CurrentVelocityRawGetter = AccessTools.PropertyGetter(type, "CurrentVelocityRaw");
        harmony.Patch(
            CurrentVelocityRawGetter,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(WindManager), nameof(postCurrentVelocityRawGetter)))
        );
    }

    private static void postCurrentVelocityRawGetter(ref float __result) {
        if (Manager.HasFlags(FreezeState.Wind)) {
            __result = 0f;
        }
    }
}