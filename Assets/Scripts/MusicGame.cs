using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    public AudioSource Musc;
    void Start()
    {
        if (Volume_Setting.MuscOn == false)
            Musc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
