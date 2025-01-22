using HarmonyLib;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;


using JumpKing.Mods;
using JumpKing.PauseMenu;

using TimeFreezeCore.Menu;
using TimeFreezeCore.Models;

namespace TimeFreezeCore;
[JumpKingMod(IDENTIFIER)]
public static class TimeFreezeCore
{
    const string IDENTIFIER = "JeFi.TimeFreezeCore";
    const string HARMONY_IDENTIFIER = "JeFi.TimeFreezeCore.Harmony";

    public static string AssemblyPath { get; set; }

    [BeforeLevelLoad]
    public static void BeforeLevelLoad()
    {
        AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#if DEBUG
        Debugger.Launch();
        Debug.WriteLine("------");
        Harmony.DEBUG = true;
        Environment.SetEnvironmentVariable("HARMONY_LOG_FILE", $@"{AssemblyPath}\harmony.log.txt");
#endif

        Harmony harmony = new Harmony(HARMONY_IDENTIFIER);

        try {
            new Patching.AchievementManager(harmony);
            new Patching.TimeInfo(harmony);
            new Patching.JumpGame(harmony);
            new Patching.LevelManager(harmony);
            new Patching.LoopingProp(harmony);
            new Patching.SandBlock(harmony);
            new Patching.ScrollingBackground(harmony);
            new Patching.WaterBlock(harmony);
            new Patching.WeatherManager(harmony);
            new Patching.WindManager(harmony);
        }
        catch (Exception e) {
            Debug.WriteLine(e.ToString());

            // Debug.WriteLine($"Message: {e.Message}");
            // Debug.WriteLine($"Stack Trace: {e.StackTrace}");

            // if (e.InnerException != null)
            // {
            //         Debug.WriteLine("Inner Exception:");
            //         Debug.WriteLine(e.InnerException.ToString());
            // }
        }

#if DEBUG
        Environment.SetEnvironmentVariable("HARMONY_LOG_FILE", null);
        Controller.SetAllFlags();
#endif
    }

    [OnLevelStart]
    public static void OnLevelStart()
    {
        // reset Controller
        // Controller.Reset();
        Manager.ResetTicks();
    }

#if DEBUG
    #region Menu Items
    [PauseMenuItemSetting]
    public static ToggleTimeFreeze ToggleTimeFreeze(object factory, GuiFormat format)
    {
        return new ToggleTimeFreeze();
    }

    [PauseMenuItemSetting]
    public static ToggleFreezeWater ToggleFreezeWater(object factory, GuiFormat format)
    {
        return new ToggleFreezeWater();
    }

    [PauseMenuItemSetting]
    public static ToggleFreezeSand ToggleFreezeSand(object factory, GuiFormat format)
    {
        return new ToggleFreezeSand();
    }


    [PauseMenuItemSetting]
    public static ToggleFreezeWind ToggleFreezeWind(object factory, GuiFormat format)
    {
        return new ToggleFreezeWind();
    }

    [PauseMenuItemSetting]
    public static ToggleFreezeProps ToggleFreezeProps(object factory, GuiFormat format)
    {
        return new ToggleFreezeProps();
    }

    [PauseMenuItemSetting]
    public static ToggleFreezeWeather ToggleFreezeWeather(object factory, GuiFormat format)
    {
        return new ToggleFreezeWeather();
    }

    [PauseMenuItemSetting]
    public static ToggleFreezeScrollingBackground ToggleFreezeScrollingBackground(object factory, GuiFormat format)
    {
        return new ToggleFreezeScrollingBackground();
    }
    #endregion
#endif
}
