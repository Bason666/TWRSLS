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
    private bool spawned = false;
    private float waitTime = 4f;
    private int CR;

    public SpawnLevel SLS;

    private void Start()
    {
        
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        SLS = GameObject.Find("Rooms").GetComponent<SpawnLevel>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 3f);
        Invoke("Started", 2f);
        Started();
        Debug.Log(CR);
    }

    private void Started()
    {
        CR = PlayerPrefs.GetInt("RC");
    }
   // public void CountRoom(int RoomCount)
  //  {
  //      CR = Player;
  //      Debug.Log("Ответ пришел");
  //  }


    public void Spawn()
    {

        if (!spawned)
        {
            if (CR <= 4)   // Первое кольцо
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
                SLS.CountsRoom(1);
           }

            if (CR > 4) // Третье кольцо
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
            spawned = true;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
