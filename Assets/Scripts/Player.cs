using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    // Для ебаного сундука
    public string TagForChest;






    // Основной код персонажа
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }

   // Сюда код анимации


    //

    // Сундук потрогали нахуй
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Chest"))
        {
            other.gameObject.tag = TagForChest;
            Casino();
        }
    }

    // Сундуковое казино
    public void Casino()
    {
        int caz = PlayerPrefs.GetInt("money"); // Получение кеша на руки, чтоб производить математические вычисления
        int opit = PlayerPrefs.GetInt("experience"); // Получение опыта
        int rand = Random.Range(0, 11); // Шанс 0-100% на выпадение лута
        if (rand == 7) // шанс выпадения 10%
        {
            opit += 1;//пока хз сколько опыта
            PlayerPrefs.SetInt("experience", opit);
        }
        else if (rand > 7) // шанс выпадения 30% 
        {
            //на всякий оставлю cas = Random.Range(0, 70); - Казино
            // выдача блядской хилки
        }
        else // Остальные 60%
        {
            caz += 30;
            PlayerPrefs.SetInt("money", caz); // золото
        }
        caz = 0;
        opit = 0;
    } 











}
