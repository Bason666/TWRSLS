using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCreep : MonoBehaviour
{
    public int health;
    public float speed;
    private Player player;
   
    private void Start()
    {
        player = FindObjectOfType<Player>();

    }
    
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

       

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


    }
}
