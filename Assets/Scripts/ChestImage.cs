using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestImage : MonoBehaviour
{
    public Sprite dc;
    private SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
        
   
    void Update()
    {
        if(CompareTag("Chest_Destroy"))
        {
            spriteRender.sprite = dc;
        }

    }
}
