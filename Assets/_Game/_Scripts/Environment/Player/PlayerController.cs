using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;

    [SerializeField]
    private Transform playerObj;

    [SerializeField]
    private float smoothTime = 0.125f;

    Animator playerAnimator;
    Rigidbody body;
    Vector3 velo;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    public void Move()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        playerAnimator.SetFloat("speed", direction.magnitude);
        body.velocity = direction * moveSpeed * Time.fixedDeltaTime;

        Vector3 rot = Vector3.SmoothDamp(playerObj.rotation.eulerAngles, body.velocity,ref velo, smoothTime);

        if(body.velocity != Vector3.zero)
            playerObj.rotation = Quaternion.LookRotation(body.velocity);
    }
}
