using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeTicks : ITextToggle
{
    public ToggleFreezeTicks() : base(Controller.HasFlags(FreezeState.Ticks))
    {
    }

    protected override string GetName() => "Ticks";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Ticks);
        else Controller.UnsetFlags(FreezeState.Ticks);
    }
}
