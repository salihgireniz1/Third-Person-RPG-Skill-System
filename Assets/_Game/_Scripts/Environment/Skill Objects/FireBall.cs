using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float forwardSpeed;
    public float power;
    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        body.velocity = transform.forward * forwardSpeed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 dir = transform.position - collision.GetContact(0).point;
        if(collision.gameObject.TryGetComponent(out Rigidbody body))
        {
            body.AddForce(dir * power);
        }
        Destroy(this.gameObject);
    }
}
