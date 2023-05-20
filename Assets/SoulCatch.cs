using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCatch : MonoBehaviour
{
    public Button MagicB;
    private int hp;
    public Sprite texturka1;
    public Sprite texturka2;
    public Image button;

    void Start()
    {
        button = GameObject.Find("Magic").GetComponent<Image>();
    }
    
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
           
        if (collision.gameObject.GetComponent<Enemy>())
        {
            hp = (GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().health);
            if (hp <= 10)
            {
                MagicB.interactable = true;
            }
   
        }
   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if(button.sprite == texturka1)
            { 
                MagicB.interactable = false;
            }
        }
    }

}
