using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayForMoney : MonoBehaviour
{
    public TMP_Text DisplayMoney;
    public TMP_Text DisplayOpit;
    public TMP_Text DisplayOpitUpgrade;


    void Start()
    {
        PlayerPrefs.SetInt("money", 0);
    }
    void Update()
    {
        DisplayMoney.text = PlayerPrefs.GetInt("money").ToString();
        DisplayOpit.text = PlayerPrefs.GetInt("experience").ToString();
        DisplayOpitUpgrade.text = PlayerPrefs.GetInt("experience").ToString();
    }

}
