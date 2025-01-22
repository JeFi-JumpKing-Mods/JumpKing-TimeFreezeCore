namespace TimeFreezeCore;
public static class Controller
{
    public static bool isStopTime;
    private static FreezeState State {get; set;}
    static Controller() {
        Reset();
    }

    public static void Reset() {
        isStopTime = false;
        UnsetAllFlags();
    }
    public static void SetFlags(FreezeState flags) {
        State |= flags;
    }
    public static void SetAllFlags() {
        State = ~FreezeState.None;
    }
    public static void UnsetFlags(FreezeState flags) {
        State &= ~flags;
    }
    public static void UnsetAllFlags() {
        State = FreezeState.None;
    }
    public static bool HasFlags(FreezeState flags) {
        return (State&flags) == flags;
    }
    public static FreezeState GetCurrentState() {
        return State;
    }
}
