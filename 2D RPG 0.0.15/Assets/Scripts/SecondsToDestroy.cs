using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsToDestroy : MonoBehaviour
{
    public float secondsToDestroy = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }


}
