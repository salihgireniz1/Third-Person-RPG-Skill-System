using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHandler : MonoSingleton<CoroutineHandler>
{
    public void PlayCoroutine(IEnumerator routine)
    {
        this.StartCoroutine(routine);
    }
}
