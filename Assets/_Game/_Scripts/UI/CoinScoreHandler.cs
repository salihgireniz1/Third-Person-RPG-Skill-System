using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScoreHandler : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        CoinManager.OnCoinScoreUpdated += UpdateCoinText;
    }
    private void OnDisable()
    {
        CoinManager.OnCoinScoreUpdated -= UpdateCoinText;
    }
    public void UpdateCoinText(int total)
    {
        text.text = total.ToString();
    }
}
