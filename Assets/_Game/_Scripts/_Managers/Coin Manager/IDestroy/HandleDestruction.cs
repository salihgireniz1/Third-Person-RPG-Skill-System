using System;
using System.Collections.Generic;
using UnityEngine;

public class HandleDestruction : MonoBehaviour, IDestroy
{
    /// <summary>
    /// Destroys the collected coin.
    /// </summary>
    public void Destruction(GameObject go)
    {
        Destroy(go);
    }
}
