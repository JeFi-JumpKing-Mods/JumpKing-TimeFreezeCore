using System.Reflection;
using HarmonyLib;

namespace TimeFreezeCore.Models;

internal static class Manager
{
    private static FieldInfo PauseManager;
    public static bool isStopTime;
    public static FreezeState State;
    public static int StoppedTicks;
    static Manager() {
        PauseManager = AccessTools.Field("JumpKing.PauseMenu.PauseManager:instance");
        isStopTime = false;
        State = FreezeState.None;
    }

    public static void ResetTicks() {
        StoppedTicks = 0;
    }

    public static void Update() {
        isStopTime = Controller.isStopTime;
        State = Controller.GetCurrentState();
    }

    public static bool HasFlags(FreezeState flags, bool ignoreStop = false) {
        return (isStopTime || ignoreStop) && (State&flags) == flags;
    }
}