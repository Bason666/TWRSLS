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
    // ��� ������� �������
    public string TagForChest;

    // �� ���
    public int health;
    public Image heart5;
    public Image heart4;
    public Image heart3;
    public Image heart2;
    public Image heart1;


    // �������� ��� ���������
    void Start()
    {
        PlayerPrefs.SetInt("MaxHealth", 0);
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
        // ����������� ��
        if ((health < 50) || (PlayerPrefs.GetInt("MaxHealth") == 2))
            heart5.enabled = false;
        else
            heart5.enabled = true;

        if ((health < 40) || (PlayerPrefs.GetInt("MaxHealth") == 1))
            heart4.enabled = false;
        else
            heart4.enabled = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }

    // ���� ��� ��������


    //

    // ������ ��������� �����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chest"))
        {
            other.gameObject.tag = TagForChest;
            Casino();
        }
    }

    // ���������� ������
    public void Casino()
    {
        int caz = PlayerPrefs.GetInt("money"); // ��������� ���� �� ����, ���� ����������� �������������� ����������
        int opit = PlayerPrefs.GetInt("experience"); // ��������� �����
        int rand = Random.Range(0, 11); // ���� 0-100% �� ��������� ����
        if (rand == 7) // ���� ��������� 10%
        {
            opit += 10;
            PlayerPrefs.SetInt("experience", opit);
        }
        else if (rand > 7) // ���� ��������� 30% 
        {
            ChangeHealth(20);
        }
        else // ��������� 60%
        {
            caz += 30;
            PlayerPrefs.SetInt("money", caz); // ������
        }
        caz = 0;
        opit = 0;
    }
    // �� ���������
    public void ChangeHealth(int healthValue)
    {
        health += healthValue; // ���������� ����/�������

        // ����������� ��
        if (health < 30)
            heart3.enabled = false;
        else
            heart3.enabled = true;

        if (health < 20)
            heart2.enabled = false;
        else
            heart2.enabled = true;

        if (health < 10)
            heart1.enabled = false;
        else
            heart1.enabled = true;
        
        
        
    }










}
