using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Top, Bottom, Left, Right, None
    }
    private RoomVariants variants;
    private int rand;
    private int CR;
    public SpawnLevel SLS;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        SLS = GameObject.Find("Rooms").GetComponent<SpawnLevel>();
    }

    private void Update()
    {
        SLS.RoomSpawn();
    }

    public void MidleSpawn()
    {
        
        

            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.MidTopRoom.Length);
                Instantiate(variants.MidTopRoom[rand], transform.position, variants.MidTopRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.MidBotRoom.Length);
                Instantiate(variants.MidBotRoom[rand], transform.position, variants.MidBotRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.MidRightRoom.Length);
                Instantiate(variants.MidRightRoom[rand], transform.position, variants.MidRightRoom[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.MidLiftRoom.Length);
                Instantiate(variants.MidLiftRoom[rand], transform.position, variants.MidLiftRoom[rand].transform.rotation);
            }
            

        
    }
    public void ChestSpawn()
    {
        if (direction == Direction.Top)
            Instantiate(variants.ChestRoom[3], transform.position, variants.ChestRoom[3].transform.rotation);
        else if (direction == Direction.Bottom)
            Instantiate(variants.ChestRoom[0], transform.position, variants.ChestRoom[0].transform.rotation);
        else if (direction == Direction.Right)
            Instantiate(variants.ChestRoom[2], transform.position, variants.ChestRoom[2].transform.rotation);
        else if (direction == Direction.Left)
            Instantiate(variants.ChestRoom[1], transform.position, variants.ChestRoom[1].transform.rotation);
    }
    public void ShopSpawn()
    {
        if (direction == Direction.Top)
            Instantiate(variants.ShopRoom[3], transform.position, variants.ShopRoom[3].transform.rotation);
        else if (direction == Direction.Bottom)
            Instantiate(variants.ShopRoom[0], transform.position, variants.ShopRoom[0].transform.rotation);
        else if (direction == Direction.Right)
            Instantiate(variants.ShopRoom[2], transform.position, variants.ShopRoom[2].transform.rotation);
        else if (direction == Direction.Left)
            Instantiate(variants.ShopRoom[1], transform.position, variants.ShopRoom[1].transform.rotation);
    }
    public void BossSpawn()
    {
        if (direction == Direction.Top)
            Instantiate(variants.BossRoom[0], transform.position, variants.BossRoom[0].transform.rotation);
        else if (direction == Direction.Bottom)
            Instantiate(variants.BossRoom[3], transform.position, variants.BossRoom[3].transform.rotation);
        else if (direction == Direction.Right)
            Instantiate(variants.BossRoom[1], transform.position, variants.BossRoom[1].transform.rotation);
        else if (direction == Direction.Left)
            Instantiate(variants.BossRoom[2], transform.position, variants.BossRoom[2].transform.rotation);
    }

    public void EndSpawn()
    {
        
        
            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.bottomRooms.Length);
                Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
            }
           
    }




    public void Destroy()
    {
        Destroy(gameObject);

    }


   private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPointSpawned"))
        {
            Destroy(gameObject);
       }
    }
}
