using StarterAssets;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [HideInInspector]
    public ThirdPersonController controller;

    public PlayerBaseState normalState = new NormalState();
    public PlayerBaseState skillState = new SkillState();
    public PlayerBaseState ragdollState = new RagdollState();

    PlayerBaseState currentState;

    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
        ChangeState(normalState);
    }
    public void ChangeState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    private void FixedUpdate()
    {
        currentState.UpdateState(this);
    }
}
