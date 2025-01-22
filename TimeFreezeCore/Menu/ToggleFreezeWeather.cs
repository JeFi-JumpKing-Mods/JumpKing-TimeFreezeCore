using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeWeather : ITextToggle
{
    public ToggleFreezeWeather() : base(Controller.HasFlags(FreezeState.Weather))
    {
    }

    protected override string GetName() => "Weather Animation";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Weather);
        else Controller.UnsetFlags(FreezeState.Weather);
    }
}
