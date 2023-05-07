using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Vibrat1;
    public Sprite Vibrat2;
    public Image vibra;
    void Start()
    {
        vibra = GetComponent <Image>();
        vibra.sprite = Vibrat1;

    }
    public void OnClick()
    {

        if (vibra.sprite == Vibrat1)
        {
            PlayerPrefs.SetInt("vibration", 0);
            vibra.sprite = Vibrat2;
            return;
        }
        if (vibra.sprite == Vibrat2)
        {
            PlayerPrefs.SetInt("vibration", 1);
            vibra.sprite = Vibrat1;
            return;
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("vibration") == 1)
            vibra.sprite = Vibrat1;
        else if (PlayerPrefs.GetInt("vibration") != 1)
            vibra.sprite = Vibrat2;
    }
  
}
