using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volume_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Volume_ON;
    public Sprite Volume_Off;

    public Image volum;
    public AudioSource Musc;
    public bool MuscOn;
    void Start()
    {
        MuscOn = true;
    }
    
    void Update()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            volum.GetComponent<Image>().sprite = Volume_ON;
            Musc.enabled = true;
            MuscOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            volum.GetComponent<Image>().sprite = Volume_Off;
            Musc.enabled = false;
            MuscOn = false;
        }
    }

    public void offSound()
    {
        if (!MuscOn)
        {
            PlayerPrefs.SetInt("music", 0);
        }
        else if (MuscOn)
        {
            PlayerPrefs.SetInt("music", 1);
        }
    }
  

}
