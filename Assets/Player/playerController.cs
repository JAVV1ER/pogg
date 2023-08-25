using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    Vector2 moveAxis;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //�������� ��������� ����������� ���� ��� �������������, ������ ��� ����� ������������ �������� ��� ������ ������
        //�������� ����� ������ ����� ������� � �� ����� ���������� � ���������
    }
    
    void Update()
    {
        //���� � ���������� ���� ����� ���, ��� ������ ���������
        // ����� ����������� � ����� ��������� �������
        moveAxis = new Vector2(0, Input.GetAxis("Horizontal"));
        
    }

    void FixedUpdate()
    {
        //������ ������ ����� ����� ������������ ������ ��� ����������� �� ������� ������
        //� ��� ��� � ����� �������� ����� ������ � �� ����� ��������� �� ������ ������ ������ ������� �������� ��� ������ ������
        rb.MovePosition(rb.position + (moveAxis * speed * Time.fixedDeltaTime));//�� ������ ������� ������ Time.fixedDeltaTime - ��� ���������� ������ ����� ����� �������

    }
}
