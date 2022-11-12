using UnityEngine;

[RequireComponent(typeof(IHandleScreenPosition))]
public class HandleCoinImage : MonoBehaviour, ISpawnImage
{
    #region Properties
    public GameObject Image { get => image; }
    #endregion

    #region Variables
    [SerializeField]
    private GameObject image;
    #endregion

    private GameObject spawnedImage;
    private Transform parentUIElement;
    IHandleScreenPosition screenPositionRespond;
    void Awake()
    {
        screenPositionRespond = GetComponent<IHandleScreenPosition>();
    }

    public GameObject SpawnImage(Vector3 spawnPosition)
    {
        Vector3 newSpawnPosition = screenPositionRespond.GetScreenPositionOfObject(spawnPosition);
        spawnedImage = Instantiate(Image, newSpawnPosition, Quaternion.identity, parentUIElement) as GameObject;

        return spawnedImage;
    }
}
