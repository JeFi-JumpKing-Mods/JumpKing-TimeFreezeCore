using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeProps : ITextToggle
{
    public ToggleFreezeProps() : base(Controller.HasFlags(FreezeState.Props))
    {
    }

    protected override string GetName() => "Props Animation";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Props);
        else Controller.UnsetFlags(FreezeState.Props);
    }
}
