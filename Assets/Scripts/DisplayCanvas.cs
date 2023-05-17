using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCanvas : MonoBehaviour
{
    private Canvas canvas;



    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("ggDead") == 1)
            canvas.enabled = true;
        else
            canvas.enabled = false;

    }
}
