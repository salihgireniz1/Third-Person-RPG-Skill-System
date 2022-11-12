using UnityEngine;

public abstract class Skill 
{
    public Skill(SkillInfo Info, IUseSkill skillUser)
    {
        this.Info = Info;
        this.SkillUser = skillUser;
    }
    public abstract IUseSkill SkillUser { get; set; }
    public abstract SkillInfo Info { get; set; }
    public abstract void UseSkill();
}
