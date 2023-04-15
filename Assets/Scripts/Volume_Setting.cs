using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volume_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Volume_ON;
    public Sprite Volume_Off;

    private Image volum;
    void Start()
    {
        volum = GetComponent<Image>();
        volum.sprite = Volume_ON;
    }
    public void OnClick()
    {

        if (volum.sprite == Volume_ON)
        {
            volum.sprite = Volume_Off;
            return;
        }
        if(volum.sprite == Volume_Off)
        {
            volum.sprite = Volume_ON;
            return;
        }
    }

}
