using UnityEngine;

[RequireComponent(typeof(IHandleCoinData))]
[RequireComponent(typeof(IDestroy))]
public class BasicCollector : MonoBehaviour, ICollector
{
    IHandleCoinData coinDataRespond;
    IDestroy coinDestroyRespond;

    private void Awake()
    {
        coinDataRespond = GetComponent<IHandleCoinData>();
        coinDestroyRespond = GetComponent<IDestroy>();
    }
    public void Collect(GameObject collectedObject)
    {
        // Handle the amount of collection.
        int amount = HandleCollectionAmount(collectedObject);

        // Handle the data of collection.
        HandleCollectionData(amount);

        coinDestroyRespond.Destruction(collectedObject);
    }

    public int HandleCollectionAmount(GameObject collectedObject)
    {
        ICollectable coinAmountRespond = collectedObject.GetComponent<ICollectable>();

        // Tell them to save new coin amount.(Give them coin amount.)
        int collectedAmount = coinAmountRespond.Amount;
        return collectedAmount;
    }

    public void HandleCollectionData(int amount)
    {
        coinDataRespond.UpdateCoinScore(amount);
    }
}
