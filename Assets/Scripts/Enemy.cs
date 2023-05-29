using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float stopTime;
    private Player player;
    int coins;
    int bonus;
    public int enemyDamage;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask igrok;
    public bool Boss;

    [HideInInspector] public bool playerNotInRoom;
    private bool stoped;
    private Animator anim;
    private AddRoom room;
    private NextLevel nl;

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
        nl = GetComponentInParent<NextLevel>();
    }
    
    private void Update()
    {
        if (!playerNotInRoom)
        {
            if (stopTime <= 0)
            {
                stoped = false;
            }
            else
            {
                stoped = true;
            }
        }
        else
        {
            stoped = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            
            if (!Boss)
            {
                coins = PlayerPrefs.GetInt("money");
                coins += 5 + bonus;
                PlayerPrefs.SetInt("money", coins);
                coins = 0;
                room.enemies.Remove(gameObject);
            }
            else
            {
                coins = PlayerPrefs.GetInt("experience");
                coins += 15 ;
                PlayerPrefs.SetInt("experience", coins);
                coins = 0;
                nl.enemies.Remove(gameObject);
            }
        }
       if(!stoped)
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

       if (player.transform.position.x > transform.position.x)
       {
            transform.eulerAngles = new Vector3(0, 180, 0); ;
       }
       else
        {
            transform.eulerAngles = new Vector3(0, 0, 0); ;
        }



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
                        anim.SetTrigger("BossAttack");
                        timeBtwAttack = startTimeBtwAttack;
                    }
                    else
                        anim.SetTrigger("EnemyAttack");
                }
                else
                {
                    timeBtwAttack = startTimeBtwAttack;
                    anim.SetTrigger("EnemyAttack");
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnEnemyAttack()
    {
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
