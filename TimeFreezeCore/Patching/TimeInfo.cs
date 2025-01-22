using HarmonyLib;
using JK = JumpKing.PauseMenu.BT.Stats;

using System.Reflection;

using System;
using JumpKing.MiscSystems.Achievements;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class TimeInfo
{
    public TimeInfo(Harmony harmony)
    {
        Type type = typeof(JK.TimeInfo);
        MethodInfo CreateLabel = AccessTools.Method(type, nameof(JK.TimeInfo.CreateLabel));
        harmony.Patch(
            CreateLabel,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(TimeInfo), nameof(preCreateLabel)))
        );
    }

    private static void preCreateLabel(ref PlayerStats p_stats) {
        if (Manager.HasFlags(FreezeState.Ticks, ignoreStop: true)) {
            p_stats._ticks += Manager.StoppedTicks;
        }
    }
}