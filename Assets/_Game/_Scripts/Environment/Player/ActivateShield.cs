using UnityEngine;

public class ActivateShield : Skill
{
    public ActivateShield(SkillInfo Info, IUseSkill skillUser) : base(Info, skillUser) { }

    public override IUseSkill SkillUser
    {
        get; set;
    }

    public override SkillInfo Info { get; set; }

    public override void UseSkill()
    {
        GameObject shield = MonoBehaviour.Instantiate(Info.skillObject, SkillUser.UserTransform.position, Quaternion.identity, SkillUser.UserTransform);
        shield.transform.localPosition = Info.spawnPositionOffset;
        shield.transform.localRotation = Quaternion.Euler(Vector3.zero);
        MonoBehaviour.Destroy(shield, 3f);
    }
}
