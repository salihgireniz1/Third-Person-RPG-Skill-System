using StarterAssets;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    public Rigidbody body;
    public Animator animator;
    public CharacterController controller;
    public ThirdPersonController tpController;
    public GameObject ragdollCamera;

    public float randomForce = 1000f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        tpController = GetComponent<ThirdPersonController>();
    }
    public void RagdollMe()
    {
        body = gameObject.AddComponent<Rigidbody>();
        body.mass = 45;
        animator.enabled = false;
        controller.enabled = false;
        tpController.enabled = false;
        ragdollCamera.SetActive(true);
        body.AddExplosionForce(randomForce, transform.position + Random.insideUnitSphere, 5f);
    }
}
