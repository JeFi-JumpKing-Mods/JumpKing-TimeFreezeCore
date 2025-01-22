using HarmonyLib;
using JumpKing;

using System.Reflection;

using System;
using JumpKing.MiscSystems.Achievements;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class AchievementManager
{
    public AchievementManager(Harmony harmony)
    {
        Type type = AccessTools.TypeByName("JumpKing.MiscSystems.Achievements.AchievementManager");
        MethodInfo GetCurrentStats = AccessTools.Method(type, "GetCurrentStats");
        harmony.Patch(
            GetCurrentStats,
            postfix: new HarmonyMethod(AccessTools.Method(typeof(AchievementManager), nameof(postGetCurrentStats)))
        );
    }

    private static void postGetCurrentStats(ref PlayerStats __result) {
        if (Manager.HasFlags(FreezeState.Ticks, ignoreStop: true)) {
            __result._ticks -= Manager.StoppedTicks;
        }
    }
}