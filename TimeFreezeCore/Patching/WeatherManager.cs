using HarmonyLib;
using JK = JumpKing;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class WeatherManager
{
    public WeatherManager(Harmony harmony)
    {
        Type type = typeof(JK.WeatherManager);
        MethodInfo Update = type.GetMethod(nameof(JK.WeatherManager.Update));
        harmony.Patch(
            Update,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(WeatherManager), nameof(preUpdate)))
        );
    }

    private static bool preUpdate() {
        return !Manager.HasFlags(FreezeState.Weather);
    }
}