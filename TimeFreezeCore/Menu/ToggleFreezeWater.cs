using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleFreezeWater : ITextToggle
{
    public ToggleFreezeWater() : base(Controller.HasFlags(FreezeState.Water))
    {
    }

    protected override string GetName() => "Water Blocks";

    protected override bool CanChange()
    {
        return Controller.isStopTime;
    }
    protected override void OnToggle()
    {
        if (toggle) Controller.SetFlags(FreezeState.Water);
        else Controller.UnsetFlags(FreezeState.Water);
    }
}
