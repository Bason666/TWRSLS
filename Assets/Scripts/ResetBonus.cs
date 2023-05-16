using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBonus : MonoBehaviour
{
    public void OnClick()
    {
        PlayerPrefs.SetInt("BonusHealth", 0);
        PlayerPrefs.SetInt("BonusSoul", 0);
        PlayerPrefs.SetInt("BonusGold", 0);
        PlayerPrefs.SetInt("BonusSpeed", 0);
        PlayerPrefs.SetInt("experience", 0);
    }
}
