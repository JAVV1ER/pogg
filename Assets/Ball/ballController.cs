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
    //мяч идет без гравитации с маленькой массой
    //плюс подключен физический материал прыгучести с нулевым трением
    //ну тоесть я добился в редакторе такого состояния шара, чтобы можно было задать ему один раз толчок и он будет прыгать вечно
    void Start()
    {

        rbBall = GetComponent<Rigidbody2D>();
        botScore = bot.GetComponent<TMP_Text>();
        playerScore = player.GetComponent<TMP_Text>();
        botCheck = 0;
        playerCheck = 0;
        coroutine = Respawn();//главного меню не просили, поэтому чтобы сразу не проиграть запускаем корутину в которой мяч ожидает старта
        StartCoroutine(coroutine);//ну да костыль
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //в редакторе на стенах за игроком и ботом закреплены тэги
        //определяю колизию через тэги да, можно по имени искать,но мне не нравится по имени искать
        //да наш мячик отвечает за счет очков
        //ну либо мяч либо стена, кто-то же должен детектить столкновения
        if (collision.gameObject.tag == "botBorder")
        {
            //все перепутал местами, поэтому в редакторе там бот это игрок, а игрок это бот, не суть
            
            botCheck += 1;
            //считаю внутри и записываю в текст
            botScore.text = botCheck.ToString();
            //так как было столкновение с границей(бота по идее) вызываем корутину которая вернет мяч в начало
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
        //надо поменять цвет, чтоб было видно когда мяч полетит
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //обнуляем мячу скорость и ставим его в нули
        //фейковый респавн
        rbBall.velocity = Vector2.zero;
        rbBall.position = Vector2.zero;
        
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
        Random rnd = new Random();
        //в случайном направлении (лево или право) швыряем мяч со скоростью которую можно в редакторе задать
        //можно было постоянно контролировать скорость, но так интересней
        //так мячик более физичный и его можно ускорить если ударить низом ракетки
        startSpeed = new Vector2(choice[rnd.Next(0,2)], 50) * speed;
        rbBall.AddForce(startSpeed);

    }
    
}
