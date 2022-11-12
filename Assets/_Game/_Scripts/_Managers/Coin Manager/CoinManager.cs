using System;
using UnityEngine;

[RequireComponent(typeof(ICollector))]
public class CoinManager : MonoSingleton<CoinManager>
{
    #region Event
    public static event Action<int> OnCoinScoreUpdated;
    #endregion

    #region Variables
    ICollector collector;
    #endregion

    #region Initialize/MonoBehaviour
    void Awake()
    {
        collector = GetComponent<ICollector>();
    }
    private void Start()
    {
        int currentCoinScore = GetComponent<IHandleCoinData>().GetCurrentCoinScore();
        OnCoinScoreUpdated?.Invoke(currentCoinScore);
    }
    #endregion

    #region Methods
    public void UpdateCoinScore(int total)
    {
        OnCoinScoreUpdated?.Invoke(total);
    }

    /// <summary>
    /// Initialize all the methods to collect a coin completely.
    /// </summary>
    /// <param name="coin">
    /// The coin object to collect, 
    /// the one that player collided.
    /// </param>
    public void CollectCoin(GameObject coin)
    {
        collector.Collect(coin);
    }
    #endregion
}