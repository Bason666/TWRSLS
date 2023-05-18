using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Player player;
    int coins;
    int bonus;
    public int enemyDamage;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask igrok;
    public float attackRangeEnemy;
    public bool Boss;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        if (PlayerPrefs.GetInt("BonusGold") == 2)
            bonus = 2;
        else if (PlayerPrefs.GetInt("BonusGold") == 1)
            bonus = 1;
        else
            bonus = 0;

    }
    
    private void Update()
    {
    

        if (health <= 0)
        {
            Destroy(gameObject);
            if (!Boss)
            {
                coins = PlayerPrefs.GetInt("money");
                coins += 5 + bonus;
                PlayerPrefs.SetInt("money", coins);
                coins = 0;
            }
            else
            {
                coins = PlayerPrefs.GetInt("experience");
                coins += 15 ;
                PlayerPrefs.SetInt("experience", coins);
                coins = 0;
            }
        }
       
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("EnemyAttack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        player.GetComponent<Player>().ChangeHealth(-enemyDamage);
       // player.health -= enemyDamage;
        timeBtwAttack = startTimeBtwAttack;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }





}
