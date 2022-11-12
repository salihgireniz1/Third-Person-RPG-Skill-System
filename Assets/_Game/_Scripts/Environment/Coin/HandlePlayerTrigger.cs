
using UnityEngine;

[RequireComponent(typeof(ICollectable))]
public class HandlePlayerTrigger : MonoBehaviour, ITriggerPlayer
{
    ICollectable collectableRespond;
    void Awake()
    {
        collectableRespond = GetComponent<ICollectable>();
    }
    public void OnTrigger()
    {
        // Initialize coin collecting processes.
        collectableRespond.Collect();
    }
}
