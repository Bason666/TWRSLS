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


    }
    public void TakeDamage(int damage)
    {
        health -= damage;


    }
}
