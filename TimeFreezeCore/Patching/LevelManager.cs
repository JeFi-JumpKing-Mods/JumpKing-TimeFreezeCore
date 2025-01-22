using HarmonyLib;
using JumpKing;
using JK = JumpKing.Level;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class LevelManager
{
    public LevelManager(Harmony harmony)
    {
        Type type = typeof(JK.LevelManager);
        MethodInfo Update = AccessTools.Method(type, nameof(JK.LevelManager.Update));
        harmony.Patch(
            Update,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(LevelManager), nameof(preUpdate)))
        );
    }

    private static void preUpdate() {
        if (Manager.isStopTime) {
            Manager.StoppedTicks++;
        }
    }
}