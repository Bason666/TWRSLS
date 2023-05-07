using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
   public void Vibration_1()
    {
        if (PlayerPrefs.GetInt("vibration") == 1)
            Handheld.Vibrate();
    }
}
