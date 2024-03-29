using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vorota : MonoBehaviour
{
    private bool db;
    public Animator anim;
    public Sprite dver2;
    private SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        db = false;
    }


   public void BossDead(bool x)
    {
        db = x;
        if (db)
        {
            spriteRender.sprite = dver2;
            anim.SetTrigger("BossDead");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) && db)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
