using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Player player;
    private Canvas canvas;
    private ExitShop spawn;
    void Start()
    {
        canvas =  GameObject.Find("Shop").GetComponent<Canvas>();
        spawn = GameObject.Find("Shop").GetComponent<ExitShop>();
        spawn.Spawned();
    }

   public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canvas.enabled = true;
    }

    public void HealthClicked()
    {
        if (PlayerPrefs.GetInt("money") >= 50)
        {
          int  x = PlayerPrefs.GetInt("money");
            player.GetComponent<Player>().ChangeHealth(20);
            x -= 50;
            PlayerPrefs.SetInt("money", x);
            x = 0;
        }
    }
    public void ExpClicked()
    {
        if (PlayerPrefs.GetInt("money") >= 10)
        {
         int   x = PlayerPrefs.GetInt("money");
          int  y = PlayerPrefs.GetInt("experience");
            y += 1;
            x -= 10;
            PlayerPrefs.SetInt("money", x);
            PlayerPrefs.SetInt("experience", y);
            y = 0;
            x = 0;
        }
    }
    public void ExitClicked()
    {
        canvas.enabled = false;
    }






    
}
