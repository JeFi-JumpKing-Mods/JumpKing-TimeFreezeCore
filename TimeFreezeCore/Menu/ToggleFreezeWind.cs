using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeWind : ITextToggle
{
    public ToggleFreezeWind() : base(Controller.HasFlags(FreezeState.Wind))
    {
    }

    protected override string GetName() => "Wind";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Wind);
        else Controller.UnsetFlags(FreezeState.Wind);
    }
}
