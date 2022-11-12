
public class RagdollState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<RagdollHandler>().RagdollMe();
    }

    public override void UpdateState(PlayerStateMachine machine)
    {

    }
}
