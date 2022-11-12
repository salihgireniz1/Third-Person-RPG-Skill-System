public class SkillState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine machine)
    {

        machine.controller.enabled = false;
    }

    public override void UpdateState(PlayerStateMachine machine)
    {

    }
}
