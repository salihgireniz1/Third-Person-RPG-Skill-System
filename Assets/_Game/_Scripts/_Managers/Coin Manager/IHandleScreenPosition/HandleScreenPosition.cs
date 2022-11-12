using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScreenPosition : MonoBehaviour, IHandleScreenPosition
{
    public Camera Cam { get => cam; }
    Camera cam;
    public Vector3 GetScreenPositionOfObject(Vector3 worldPosition)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        return screenPosition;
    }
}