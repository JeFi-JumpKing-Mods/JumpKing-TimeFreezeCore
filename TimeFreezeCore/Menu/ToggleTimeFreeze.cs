using System.ComponentModel;
using System.Windows.Markup;
using JumpKing.PauseMenu.BT.Actions;

namespace TimeFreezeCore.Menu;
public class ToggleTimeFreeze : ITextToggle
{
    public ToggleTimeFreeze() : base(Controller.isStopTime)
    {
    }

    protected override string GetName() => "Time Freeze";
    protected override void OnToggle()
    {
        Controller.isStopTime = toggle;
    }
}
