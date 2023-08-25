using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{
    public float speed = 10f;
    private TMP_Text botScore;
    private TMP_Text playerScore;
    public GameObject bot;
    public GameObject player;
    private int botCheck;
    private int playerCheck;
    private Vector2 startSpeed;
    private Rigidbody2D rbBall;
    
    private float[] choice = new float[2] { -50, 50 };
    private IEnumerator coroutine;
    //��� ���� ��� ���������� � ��������� ������
    //���� ��������� ���������� �������� ���������� � ������� �������
    //�� ������ � ������� � ��������� ������ ��������� ����, ����� ����� ���� ������ ��� ���� ��� ������ � �� ����� ������� �����
    void Start()
    {

        rbBall = GetComponent<Rigidbody2D>();
        botScore = bot.GetComponent<TMP_Text>();
        playerScore = player.GetComponent<TMP_Text>();
        botCheck = 0;
        playerCheck = 0;
        coroutine = Respawn();//�������� ���� �� �������, ������� ����� ����� �� ��������� ��������� �������� � ������� ��� ������� ������
        StartCoroutine(coroutine);//�� �� �������
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //� ��������� �� ������ �� ������� � ����� ���������� ����
        //��������� ������� ����� ���� ��, ����� �� ����� ������,�� ��� �� �������� �� ����� ������
        //�� ��� ����� �������� �� ���� �����
        //�� ���� ��� ���� �����, ���-�� �� ������ ��������� ������������
        if (collision.gameObject.tag == "botBorder")
        {
            //��� ��������� �������, ������� � ��������� ��� ��� ��� �����, � ����� ��� ���, �� ����
            
            botCheck += 1;
            //������ ������ � ��������� � �����
            botScore.text = botCheck.ToString();
            //��� ��� ���� ������������ � ��������(���� �� ����) �������� �������� ������� ������ ��� � ������
            StartCoroutine(Respawn());
        }
        if (collision.gameObject.tag == "playerBorder")
        {
            playerCheck += 1;
            playerScore.text = playerCheck.ToString();
            StartCoroutine(Respawn());
        }
    }
    private IEnumerator Respawn()
    {
        //���� �������� ����, ���� ���� ����� ����� ��� �������
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //�������� ���� �������� � ������ ��� � ����
        //�������� �������
        rbBall.velocity = Vector2.zero;
        rbBall.position = Vector2.zero;
        
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
        Random rnd = new Random();
        //� ��������� ����������� (���� ��� �����) ������� ��� �� ��������� ������� ����� � ��������� ������
        //����� ���� ��������� �������������� ��������, �� ��� ����������
        //��� ����� ����� �������� � ��� ����� �������� ���� ������� ����� �������
        startSpeed = new Vector2(choice[rnd.Next(0,2)], 50) * speed;
        rbBall.AddForce(startSpeed);

    }
    
}
