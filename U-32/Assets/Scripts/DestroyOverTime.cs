using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float destroyTimer;
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
