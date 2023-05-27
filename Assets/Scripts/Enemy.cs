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
    public bool Boss;

    private Animator anim;
    private AddRoom room;

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
        room = GetComponentInParent<AddRoom>();
    }
    
    private void Update()
    {
    

        if (health <= 0)
        {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
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
                if (Boss)
                {
                    int Rand = Random.Range(0, 11);
                    if (Rand == 1)
                    {
                        Debug.Log("Ульта босса");
                        timeBtwAttack = startTimeBtwAttack;
                    }
                    else
                        anim.SetTrigger("EnemyAttack");
                }
                else
                {
                    anim.SetTrigger("EnemyAttack");
                    Debug.Log("Ответка на анимацию");
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
        Debug.Log("Враг атакует");
        timeBtwAttack = startTimeBtwAttack;
        player.GetComponent<Player>().ChangeHealth(-enemyDamage);
    }

    public void AttackBoss()
    {
        timeBtwAttack = startTimeBtwAttack;
        player.GetComponent<Player>().ChangeHealth(-10);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }





}
