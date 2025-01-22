using System;

namespace TimeFreezeCore;

[Flags]
public enum FreezeState: long {
    None = 0,
    Sand = 1<<0,
    Water = 1<<1,
    Props = 1<<2,
    Wind = 1<<3,
    Weather = 1<<4,
    ScrollingBackground = 1<<5,
    Ticks = 1<<6,
}