using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerStateMachine machine;

    [SerializeField]
    float gameDuration;

    [SerializeField]
    float replayDuration;
    private void Start()
    {
        StartCoroutine(InitGameOverProcess());
    }
    IEnumerator InitGameOverProcess()
    {
        yield return new WaitForSeconds(gameDuration);
        machine.ChangeState(machine.ragdollState);
        yield return new WaitForSeconds(replayDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}