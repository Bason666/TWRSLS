using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatistic : MonoBehaviour
{
    public Button Health;
    public Button Speed;
    public Button Soul;
    public Button Gold;

    public Sprite bar;
    public Sprite bar1;
    public Sprite bar2;

    public Image HB;
    public Image SB;
    public Image SoB;
    public Image GB;


    void Start()
    {

        if (PlayerPrefs.GetInt("BonusHealth") == 2)
        {
            Health.interactable = false;
            HB.sprite = bar2;
        }
        else if (PlayerPrefs.GetInt("BonusHealth") == 1)
            HB.sprite = bar1;

        if (PlayerPrefs.GetInt("BonusSpeed") == 2)
        {
            Speed.interactable = false;
            SB.sprite = bar2;
        }
        else if (PlayerPrefs.GetInt("BonusSpeed") == 1)
            SB.sprite = bar1;

        if (PlayerPrefs.GetInt("BonusGold") == 2)
        {
            Gold.interactable = false;
            GB.sprite = bar2;
        }
        else if (PlayerPrefs.GetInt("BonusGold") == 1)
            GB.sprite = bar1;
        if (PlayerPrefs.GetInt("BonusSoul") == 2)
        {
            Soul.interactable = false;
            SoB.sprite = bar2;
        }
        else if (PlayerPrefs.GetInt("BonusSoul") == 1)
            SoB.sprite = bar1;
    }


    public void HealthClicked()
    {
        if (PlayerPrefs.GetInt("experience") > 10)
        {
            Calculator(10);
            if (HB.sprite == bar1)
            {
                Health.interactable = false;
                PlayerPrefs.SetInt("BonusHealth", 2);
                HB.sprite = bar2;
            }
            else if (HB.sprite == bar)
            {
                PlayerPrefs.SetInt("BonusHealth", 1);
                HB.sprite = bar1;
            }
        }
    }
    public void SpeedClicked()
    {
        if (PlayerPrefs.GetInt("experience") > 10)
        {
            Calculator(10);
            if (SB.sprite == bar1)
            {
                Speed.interactable = false;
                PlayerPrefs.SetInt("BonusSpeed", 2);
                SB.sprite = bar2;
            }
            else if (SB.sprite == bar)
            {
                PlayerPrefs.SetInt("BonusSpeed", 1);
                SB.sprite = bar1;
            }
        }

    }
    public void GoldClicked()
    {
        if (PlayerPrefs.GetInt("experience") > 20)
        {
            Calculator(20);
            if (GB.sprite == bar1)
            {
                Gold.interactable = false;
                PlayerPrefs.SetInt("BonusGold", 2);
                GB.sprite = bar2;
            }
            else if (HB.sprite == bar)
            {
                PlayerPrefs.SetInt("BonusGold", 1);
                GB.sprite = bar1;
            }
        }
    }
    public void SoulClicked()
    {
        if (PlayerPrefs.GetInt("experience") > 20)
        {
            Calculator(20);
            if (SoB.sprite == bar1)
            {
                Soul.interactable = false;
                PlayerPrefs.SetInt("BonusSoul", 2);
                SoB.sprite = bar2;
            }
            else if (SoB.sprite == bar)
            {
                PlayerPrefs.SetInt("BonusSoul", 1);
                SoB.sprite = bar1;
            }
        }
    }
    // Update is called once per frame

    private void Calculator(int price)
    {
        int mont = PlayerPrefs.GetInt("experience");
        mont -= price;
        PlayerPrefs.SetInt("experience", mont);
            mont = 0;
    }
    void Update()
    {

    }













}
