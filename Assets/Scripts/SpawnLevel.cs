using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    private bool RoomBoosSpawned;
    private bool RoomShopSpawned;
    private bool RoomChestSpawned;
    public int RoomCount;

    public RoomSpawner RSC;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool Timer;
    void Start()
    {
        RoomBoosSpawned = false;
        RoomShopSpawned = false;
        RoomChestSpawned = false;
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
            if (RoomCount < 6)
            {
                RSC.MidleSpawn();
            }
            if ((RoomCount >= 4) && (RoomChestSpawned) && (RoomShopSpawned) && (RoomBoosSpawned))
            {
                RSC.EndSpawn();
            }
            if ((RoomCount >= 6) && (!RoomChestSpawned))
            {
                RSC.ChestSpawn();
                RoomChestSpawned = true;
            }
            else if ((RoomCount >=6) && (!RoomShopSpawned))
            {
                RSC.ShopSpawn();
                RoomShopSpawned = true;
            }
            else if ((RoomCount >= 6) && (!RoomBoosSpawned))
            {
                RSC.BossSpawn();
                RoomBoosSpawned = true;
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
