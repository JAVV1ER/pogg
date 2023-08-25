using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    public GameObject ball;//� ��������� ������ ����� �������� Rb(��������� ��� ��������) ������� ������� � ������� GameObject � �� ���� ������� Rb
    public float speed = 10f;
    
    private Rigidbody2D rbBall;
    
    void Start()
    {
        //��� �������� ����� �����������, ������ ��� ����� ������ � ���� ��� �������� ������
        
        rbBall = ball.GetComponent<Rigidbody2D>();
        //������ �� �����, ����� ��������� ��������� ��� ���������� ��������
    }
    void FixedUpdate()
    {
        //���������� ����������, �� ������� � ���� �� ��������...
        //ClampMagnitude ������ ������ ���������� �������� �� �������, �� ������ ��������(float speed) ���������� �� �������� � ������� �������� �������� � �������
        transform.position = transform.position + Vector3.ClampMagnitude(new Vector3(0,rbBall.velocity.y),speed) * Time.fixedDeltaTime;
        //�������� �� ������ ������ ����� ������� ����

    }

    
}
