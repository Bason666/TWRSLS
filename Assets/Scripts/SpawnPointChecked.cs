using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointChecked : MonoBehaviour
{
    private float WaitTime = 4f;


    void Start()
    {
        Destroy(gameObject, WaitTime);
    }

}
