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
    public Animator animator;
    // ��� ������� �������
    public string TagForChest;

    // �� ���
    public int health;
    public Image heart5;
    public Image heart4;
    public Image heart3;
    public Image heart2;
    public Image heart1;

    int MaxHealth;
    int ms;
    int gold;
    // �������� ��� ���������
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // ��������
        // ��
        if (PlayerPrefs.GetInt("BonusHealth") == 2)
        {
            MaxHealth = 50;
            health = 50;
        }
        else if (PlayerPrefs.GetInt("BonusHealth") == 1)
        {
            MaxHealth = 40;
            health = 40;
            heart5.enabled = false;
        }
        else
        {
            MaxHealth = 30;
            health = 30;
            heart4.enabled = false;
            heart5.enabled = false; 
        }
        // ��������
        if (PlayerPrefs.GetInt("BonusSpeed") == 2)
            ms = 4;
        else if (PlayerPrefs.GetInt("BonusSpeed") == 1)
            ms = 2;
        else
            ms = 0;
        // �����
        if (PlayerPrefs.GetInt("BonusGold") == 2)
            gold = 10;
        else if (PlayerPrefs.GetInt("BonusGold") == 1)
            gold = 5;
        else
            gold = 0;

    }

    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * (speed + ms);

        if (moveInput.x == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
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
            caz += 30 + gold;
            PlayerPrefs.SetInt("money", caz); // ������
        }
        caz = 0;
        opit = 0;
    }
    // �� ���������
    public void ChangeHealth(int healthValue)
    {
        health += healthValue; // ���������� ����/�������
        if (health > MaxHealth)
            health = MaxHealth;
        // ����������� ��
        if (health < 50)
            heart5.enabled = false;
        else
            heart5.enabled = true;

        if (health < 40)
            heart4.enabled = false;
        else
            heart4.enabled = true;

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
