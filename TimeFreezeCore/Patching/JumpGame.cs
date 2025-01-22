using HarmonyLib;
using JumpKing;
using JK = JumpKing;

using System.Reflection;

using System;
using TimeFreezeCore.Models;

namespace TimeFreezeCore.Patching;
internal class JumpGame
{
    public JumpGame(Harmony harmony)
    {
        Type type = typeof(JK.JumpGame);
        MethodInfo Update = AccessTools.Method(type, nameof(JK.JumpGame.Update));
        harmony.Patch(
            Update,
            prefix: new HarmonyMethod(AccessTools.Method(typeof(JumpGame), nameof(preUpdate)))
        );
    }

    private static void preUpdate() {
        Manager.Update();
    }
}