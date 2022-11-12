using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBlackHole : Skill
{
    public ThrowBlackHole(SkillInfo Info, IUseSkill skillUser) : base(Info, skillUser) { }

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

        GameObject blackHole = MonoBehaviour.Instantiate(Info.skillObject, SkillUser.UserTransform.position, Quaternion.identity, SkillUser.UserTransform);
        blackHole.transform.localPosition = Info.spawnPositionOffset;
        blackHole.transform.localRotation = Quaternion.Euler(Vector3.zero);
        blackHole.transform.parent = null;

        blackHole.GetComponent<Singularity>().MoveBlackHole(SkillUser.UserTransform);

        yield return new WaitForSeconds(Info.castTime - Info.spawnTime);
        SkillUser.HandleSkillAnimation(Info.animationName, false);
    }
}
