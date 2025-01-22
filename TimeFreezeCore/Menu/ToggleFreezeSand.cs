using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeSand : ITextToggle
{
    public ToggleFreezeSand() : base(Controller.HasFlags(FreezeState.Sand))
    {
    }

    protected override string GetName() => "Sand Blocks";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Sand);
        else Controller.UnsetFlags(FreezeState.Sand);
    }
}
