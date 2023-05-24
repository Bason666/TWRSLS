using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public bool RoomBoosSpawned;
    public bool RoomShopSpawned;
    public int RoomCount;

    public RoomSpawner RSC;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool Timer;
    void Start()
    {
        RoomBoosSpawned = false;
        RoomShopSpawned = false;
        RoomCount = 0;
    }
    public void CountsRoom(int variable)
    {
        RoomCount += variable;
    }
   public void RoomSpawn()
    {
        if (Timer == true)
        {
           
            RSC = GameObject.FindWithTag("RoomPoint").GetComponent<RoomSpawner>();
            if (RoomCount < 4)
            {
                RSC.MidleSpawn();
            }
            if (RoomCount >= 4)
            {
                RSC.EndSpawn();
            }

            Timer = false;
            CountsRoom(1);
            RSC.Destroy();



        }
    }
    public void Update()
    {
       if (timeBtwAttack <= 0)
       {
            Timer = true;
            timeBtwAttack = startTimeBtwAttack;
       }
        else
            timeBtwAttack -= Time.deltaTime;
    }
}
