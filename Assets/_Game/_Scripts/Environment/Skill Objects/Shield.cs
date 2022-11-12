using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Shield : MonoBehaviour
{
    public float damageArea;
    public float power;
    public void ApplyDamage(Vector3 contactPoint)
    {

    }
    private void Update()
    {
        Collider[] contacts = Physics.OverlapSphere(transform.position, damageArea);
        foreach (var contact in contacts)
        {
            Rigidbody rb = contact.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, transform.position, damageArea, 3.0f);
        }
    }
}
