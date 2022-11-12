public class NormalState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.controller.enabled = true;
    }

    public override void UpdateState(PlayerStateMachine machine)
    {

    }
}
