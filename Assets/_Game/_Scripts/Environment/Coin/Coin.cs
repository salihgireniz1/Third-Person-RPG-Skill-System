using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public int Amount { get => amount; }

    [SerializeField]
    private int amount;
    public void Collect()
    {
        CoinManager.Instance.CollectCoin(this.gameObject);
    }
}