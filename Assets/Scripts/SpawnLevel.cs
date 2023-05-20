using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public bool RoomBoosSpawned;
    public bool RoomShopSpawned;
    public int RoomCount;

    public RoomSpawner RSC;


    void Start()
    {
        RoomBoosSpawned = false;
        RoomShopSpawned = false;
        RoomCount = 0;
        PlayerPrefs.SetInt("RC", 0);
        Debug.Log("намскхк");
    }
    public void CountsRoom(int variable)
    {
        RoomCount += variable;
        //  RSC.CountRoom(RoomCount);
        PlayerPrefs.SetInt("RC", RoomCount);
    }
  //  private void Update()
  //  {
    //   if (RoomCount != 4)
      //  {
     //       RSC = GameObject.Find("Spawnpoint").GetComponent<RoomSpawner>();
     //   }
  //  }

}
