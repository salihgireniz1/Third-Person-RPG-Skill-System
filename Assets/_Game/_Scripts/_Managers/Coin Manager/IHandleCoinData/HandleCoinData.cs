using System;
using System.Collections.Generic;
using UnityEngine;

public class HandleCoinData : MonoBehaviour, IHandleCoinData
{
    #region Constant
    const string COIN_SCORE = "CoinScore";
    #endregion

    #region Properties
    public int CoinScore
    {
        get => GetCurrentCoinScore();
        private set
        {
            coinScore = value;
        }
    }
    #endregion

    #region Variables
    private int coinScore;
    #endregion

    #region Methods
    public void SaveCoinScore()
    {
        ES3.Save(COIN_SCORE, coinScore);
    }
    public int GetCurrentCoinScore()
    {
        return ES3.Load(COIN_SCORE, 0);
    }
    public void UpdateCoinScore(int amount)
    {
        CoinScore += amount;
        SaveCoinScore();
        CoinManager.Instance.UpdateCoinScore(CoinScore);
    }
    #endregion
}