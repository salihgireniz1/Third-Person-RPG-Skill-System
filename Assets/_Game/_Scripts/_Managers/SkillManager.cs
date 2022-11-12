using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoSingleton<SkillManager>
{
    public Player user;
    public List<SkillInfo> skillInfos;
    public List<Button> buttons;
    public Dictionary<int, Skill> skillDict = new Dictionary<int, Skill>();
    public Dictionary<int, float> coolDownDict = new Dictionary<int, float>();

    List<Image> buttonImages = new List<Image>();

    private void Awake()
    {
        InitSkills();
    }

    public void InitSkills()
    {
        Skill throwBall = new ThrowBall(skillInfos[0], user);
        Skill shield = new ActivateShield(skillInfos[1], user);
        Skill blackHole = new ThrowBlackHole(skillInfos[2], user);

        skillDict.Add(0, throwBall);
        coolDownDict.Add(0, skillInfos[0].coolDown);
        buttons[0].onClick.AddListener(() => UseSkillByIndex(0));

        skillDict.Add(1, shield);
        coolDownDict.Add(1, skillInfos[1].coolDown);
        buttons[1].onClick.AddListener(() => UseSkillByIndex(1));

        skillDict.Add(2, blackHole);
        coolDownDict.Add(2, skillInfos[2].coolDown);
        buttons[2].onClick.AddListener(() => UseSkillByIndex(2));

        for (int i = 0; i < buttons.Count; i++)
        {
            buttonImages.Add(buttons[i].gameObject.GetComponent<Image>());
        }
    }

    public void UseSkillByIndex(int index)
    {
        if (coolDownDict[index] < skillInfos[index].coolDown || user.CastingSpell)
        {
            return;
        }
        skillDict[index].UseSkill();
        coolDownDict[index] = 0f;
    }

    private void Update()
    {
        HandleCoolDowns();
    }
    public void HandleCoolDowns()
    {
        for (int i = 0; i < skillDict.Count; i++)
        {
            if (coolDownDict[i] < skillInfos[i].coolDown)
            {
                coolDownDict[i] += Time.deltaTime;
                buttonImages[i].fillAmount = coolDownDict[i] / skillInfos[i].coolDown;
            }
            else if (coolDownDict[i] > skillInfos[i].coolDown)
            {
                coolDownDict[i] = skillInfos[i].coolDown;
                buttons[i].GetComponent<Image>().fillAmount = 1;
            }
        }
    }
}