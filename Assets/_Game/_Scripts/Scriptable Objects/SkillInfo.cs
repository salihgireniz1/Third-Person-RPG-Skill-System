using UnityEngine;

[CreateAssetMenu(fileName = "Skill Info", menuName = "Skill/SkillInfo")]
public class SkillInfo : ScriptableObject
{
    public GameObject skillObject;
    public Vector3 spawnPositionOffset;
    public string animationName;
    public float coolDown;
    public float spawnTime;
    public float castTime;
}
