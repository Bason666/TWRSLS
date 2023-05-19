using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    public Image button;
    public Sprite sprite1;
    public Sprite sprite2;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    int count = 0;
    public Button knopka;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    private bool mgc;

    void Start()
    {
        button = GameObject.Find("Magic").GetComponent<Image>();

        if (PlayerPrefs.GetInt("BonusSoul") == 2)
        {
            count = 100;
        }
        else if (PlayerPrefs.GetInt("BonusSoul") == 1)
        {
            count = 10;
        }

    }
    public void ZahvatSoulClicked()
    {
        button.sprite = sprite1;
        count++;
        Debug.Log(count);
    }
    public void CastClicked()
    {
        //нулевой
        if ((count == 2) && (button.sprite == sprite1))
        {
            mgc = true;
            button.sprite = sprite2;
            knopka.interactable = false;
            count = 0;
        }
        // 1 уровень
        if ((count == 12) && (button.sprite == sprite1))
        {
            mgc = true;
        }
        if ((count == 13) && (button.sprite == sprite1))
        {
            mgc = true;
            button.sprite = sprite2;
            knopka.interactable = false;
            count = 10;
        }
        // 2 уровень
        if ((count == 102) && (button.sprite == sprite1))
        {
            mgc = true;
        }
        if ((count == 103) && (button.sprite == sprite1))
        {
            mgc = true;
        }
        if ((count == 104) && (button.sprite == sprite1))
        {
            mgc = true;
            button.sprite = sprite2;
            knopka.interactable = false;
            count = 100;
        }
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (mgc == true)
            {

                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                mgc = false;
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
            timeBtwAttack -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
