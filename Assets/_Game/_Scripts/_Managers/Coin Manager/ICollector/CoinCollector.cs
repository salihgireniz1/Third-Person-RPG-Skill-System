using UnityEngine;

[RequireComponent(typeof(IHandleCoinData))]
[RequireComponent(typeof(IDestroy))]
[RequireComponent(typeof(ISpawnImage))]
[RequireComponent(typeof(IAnimateCoinImage))]
public class CoinCollector : MonoBehaviour, ICollector
{
    IHandleCoinData coinDataRespond;
    IDestroy coinDestroyRespond;
    ISpawnImage imageSpawnRespond;
    IAnimateCoinImage imageAnimator;

    private void Awake()
    {
        coinDataRespond = GetComponent<IHandleCoinData>();
        coinDestroyRespond = GetComponent<IDestroy>();
        imageSpawnRespond = GetComponent<ISpawnImage>();
        imageAnimator = GetComponent<IAnimateCoinImage>();
    }

    public void Collect(GameObject coin)
    {
        // Handle the amount of collection.
        int amount = HandleCollectionAmount(coin);

        // Handle the data of collection.
        HandleCollectionData(amount);

        // Handle the processes that happen to collection after collecting it.
        GameObject spawnedImageObject = imageSpawnRespond.SpawnImage(coin.transform.position);
        imageAnimator.Animate(spawnedImageObject);
        coinDestroyRespond.Destruction(coin);
    }

    public int HandleCollectionAmount(GameObject collectedCoin)
    {
        ICollectable coinAmountRespond = collectedCoin.GetComponent<ICollectable>();

        // Tell them to save new coin amount.(Give them coin amount.)
        int collectedAmount = coinAmountRespond.Amount;
        return collectedAmount;
    }
    public void HandleCollectionData(int amount)
    {
        coinDataRespond.UpdateCoinScore(amount);
    }
}
