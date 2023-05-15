using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform attackPos;
    public LayerMask igrok;
    public float attackRange;
    private void Start()
    {
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
            coins = PlayerPrefs.GetInt("money");
            coins += 5 + bonus;
            PlayerPrefs.SetInt("money", coins);
            coins = 0;
        }
       
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (timeBtwAttack <= 0)
        {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, igrok);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Player>().ChangeHealth(-enemyDamage);
            }
                timeBtwAttack = startTimeBtwAttack;
        }
        else
            timeBtwAttack -= Time.deltaTime;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;


    }





}
