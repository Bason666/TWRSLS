using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    // ��� ������� �������
    public string TagForChest;
 







    // �������� ��� ���������
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

   // ���� ��� ��������


    //

    // ������ �����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Chest"))
        {
            other.gameObject.tag = TagForChest;
            
        }


    }
}
