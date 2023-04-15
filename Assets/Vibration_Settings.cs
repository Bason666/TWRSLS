using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Vibrat1;
    public Sprite Vibrat2;

    private Image vibra;
    void Start()
    {
        vibra = GetComponent <Image>();
        vibra.sprite = Vibrat1;
    }
    public void OnClick()
    {



        if (vibra.sprite == Vibrat1)
        {
            vibra.sprite = Vibrat2;
            return;
        }
        if (vibra.sprite == Vibrat2)
        {
            vibra.sprite = Vibrat1;
            return;
        }
    }
  
}
