using UnityEngine;

public interface IUseSkill
{
    Transform UserTransform { get; }
    Animator Animator { get; }
    bool CastingSpell { get; set; }
    float GetAnimationDuration(string name);
    void HandleSkillAnimation(string animationName, bool condition);
}
