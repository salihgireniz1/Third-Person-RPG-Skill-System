using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinImageAnimator : MonoBehaviour, IAnimateCoinImage
{
    public Transform CollectedCoinsImage { get; }
    public Tween AnimationTween
    {
        get => animationTween;
        private set => animationTween = value;
    }
    public float AnimationDuration { get => animationDuration; }
    public Ease Ease { get => ease; }
    [SerializeField] float animationDuration;
    [SerializeField] Ease ease;
    Tween animationTween;
    IDestroy destroyerRespond;
    void Awake()
    {
        destroyerRespond = GetComponent<IDestroy>();
    }
    public Tween SetAnimation(Transform image)
    {
        AnimationTween = image.DOMove(CollectedCoinsImage.position, AnimationDuration).SetEase(Ease).OnComplete(() => destroyerRespond.Destruction(image.gameObject));
        return AnimationTween;
    }
    public void Animate(GameObject collectedCoinImage)
    {
        SetAnimation(collectedCoinImage.transform).Play();
    }
}
