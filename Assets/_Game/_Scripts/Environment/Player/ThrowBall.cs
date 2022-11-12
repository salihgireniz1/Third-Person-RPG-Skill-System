using System.Collections;
using UnityEngine;

public class ThrowBall : Skill
{
    public ThrowBall(SkillInfo Info, IUseSkill skillUser) : base(Info, skillUser) { }

    public override IUseSkill SkillUser
    {
        get; set;
    }

    public override SkillInfo Info { get; set; }

    public override void UseSkill()
    {
        CoroutineHandler.Instance.PlayCoroutine(Throw());
    }

    IEnumerator Throw()
    {

        // Change user animation state.
        SkillUser.HandleSkillAnimation(Info.animationName, true);

        // Spawn skill right at time.
        yield return new WaitForSeconds(Info.spawnTime);

        GameObject fireBall = MonoBehaviour.Instantiate(Info.skillObject, SkillUser.UserTransform.position, Quaternion.identity, SkillUser.UserTransform);
        fireBall.transform.localPosition = Info.spawnPositionOffset;
        fireBall.transform.localRotation = Quaternion.Euler(Vector3.zero);
        fireBall.transform.parent = null;

        yield return new WaitForSeconds(Info.castTime-Info.spawnTime);
        SkillUser.HandleSkillAnimation(Info.animationName, false);
    }
}
