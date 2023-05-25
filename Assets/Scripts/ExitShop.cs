using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShop : MonoBehaviour
{
    private Shop CS;


    public void Spawned()
    {
        CS = GameObject.Find("Larek").GetComponent<Shop>();
    }


   public void ClickedExit()
    {
       CS.ExitClicked();
    }

}
