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

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    private bool mgc;

    void Start()
    {
        button = GameObject.Find("Magic").GetComponent<Image>();
    }
    public void ZahvatSoulClicked()
    {
        button.sprite = sprite1;
        count++;
    }
    public void CastClicked()
    {
        if((count == 2) && (button.sprite == sprite1))
        {
            mgc = true;
            button.sprite = sprite2;
            count = 0;
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
