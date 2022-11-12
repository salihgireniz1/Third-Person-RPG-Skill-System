using DG.Tweening;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour
{
    //This is the main script which pulls the objects nearby
    public float GRAVITY_PULL = 100f;
    public float moveDuration;
    public float distance;
    public AnimationCurve goingCurve;
    public AnimationCurve comingCurve;
    public float scaleAmount;
    public static float m_GravityRadius = 1f;


    void Awake() {
        m_GravityRadius = GetComponent<SphereCollider>().radius;

        if(GetComponent<SphereCollider>()){
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }
    
    void OnTriggerStay (Collider other) {
        if(other.attachedRigidbody && other.GetComponent<SingularityPullable>()) {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
        }
    }
    public void MoveBlackHole(Transform user)
    {
        Movement(user).Play();
    }
    Sequence Movement(Transform user)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(transform.forward *distance + transform.position, moveDuration).SetEase(goingCurve))
            .Join(transform.DOScale(scaleAmount, moveDuration).SetEase(goingCurve))
            .Append(transform.DOMove(user.position + Vector3.up, moveDuration).SetEase(comingCurve))
            .Join(transform.DOScale(0f, moveDuration).SetEase(comingCurve))
            .OnComplete(() => Destroy(this.gameObject));
        return seq;
    }
}
