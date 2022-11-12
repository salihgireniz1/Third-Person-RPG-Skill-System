using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IUseSkill
{
    public Animator Animator => animator;

    public bool CastingSpell { get; set; }
    public Transform UserTransform { get => bodyTransform; }

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerStateMachine machine;

    [SerializeField]
    private Transform bodyTransform;
    public float GetAnimationDuration(string animationName)
    {
        var clip = Animator.runtimeAnimatorController.animationClips.First(a => a.name == animationName);
        return clip.length;
    }

    public void HandleSkillAnimation(string animationName, bool condition)
    {
        Animator.SetBool(animationName, condition);
        CastingSpell = condition;
        Debug.Log(CastingSpell);
        switch (condition)
        {
            case true:
                machine.ChangeState(machine.skillState);
                break;
            default:
                machine.ChangeState(machine.normalState);
                break;
        }
    }
}
