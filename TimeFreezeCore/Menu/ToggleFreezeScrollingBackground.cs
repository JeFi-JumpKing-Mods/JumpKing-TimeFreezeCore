using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeScrollingBackground : ITextToggle
{
    public ToggleFreezeScrollingBackground() : base(Controller.HasFlags(FreezeState.ScrollingBackground))
    {
    }

    protected override string GetName() => "ScrollingBackground";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.ScrollingBackground);
        else Controller.UnsetFlags(FreezeState.ScrollingBackground);
    }
}
