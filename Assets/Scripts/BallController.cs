using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class BallController : MonoBehaviour
{
    public int playerCheck;
    public int botCheck;
    
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _bot;
    [SerializeField]
    private GameObject _player;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;
    private Vector2 _startSpeed;
    private Rigidbody2D _rbBall;
    private SpriteRenderer _ballSpriteRenderer;
    private IEnumerator _coroutine;
    private float[] _choiceX = new float[6] { -50, 50, -40, 40, -60, 60 };
    private float[] _choiceY = new float[6] { -50, 50, -40, 40, -60, 60 };
    
    //мяч идет без гравитации с маленькой массой
    //плюс подключен физический материал прыгучести с нулевым трением
    //ну тоесть я добился в редакторе такого состояния шара, чтобы можно было задать ему один раз толчок и он будет прыгать вечно
    void Start()
    {

        _rbBall = GetComponent<Rigidbody2D>();
        _botScore = _bot.GetComponent<TMP_Text>();
        _playerScore = _player.GetComponent<TMP_Text>();
        _ballSpriteRenderer= GetComponent<SpriteRenderer>();
        botCheck = 0;
        playerCheck = 0;
        _coroutine = Respawn();//главного меню не просили, поэтому чтобы сразу не проиграть запускаем корутину в которой мяч ожидает старта
        StartCoroutine(_coroutine);//ну да костыль
        CheckReferences();
    }

    void CheckReferences()
    {
        if (_bot == null)
            Debug.LogError("Bot не найден");
        if (_player == null)
            Debug.LogError("Player не найден");
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //в редакторе на стенах за игроком и ботом закреплены тэги
        //определяю колизию через тэги да, можно по имени искать,но мне не нравится по имени искать
        //да наш мячик отвечает за счет очков
        //ну либо мяч либо стена, кто-то же должен детектить столкновения
        if (collision.gameObject.CompareTag("botBorder"))
        {
            //все перепутал местами, поэтому в редакторе там бот это игрок, а игрок это бот, не суть
            
            botCheck += 1;
            //считаю внутри и записываю в текст
            _botScore.text = botCheck.ToString();
            //так как было столкновение с границей(бота по идее) вызываем корутину которая вернет мяч в начало
            StartCoroutine(Respawn());
        }
        if (collision.gameObject.CompareTag("playerBorder"))
        {
            playerCheck += 1;
            _playerScore.text = playerCheck.ToString();
            StartCoroutine(Respawn());
        }
    }
    private IEnumerator Respawn()
    {
        //надо поменять цвет, чтоб было видно когда мяч полетит
        _ballSpriteRenderer.color = Color.red;
        //обнуляем мячу скорость и ставим его в нули
        //фейковый респавн
        _rbBall.velocity = Vector2.zero;
        _rbBall.position = Vector2.zero;
        
        yield return new WaitForSeconds(2f);
        _ballSpriteRenderer.color = Color.green;
        yield return new WaitForSeconds(1f);
        _ballSpriteRenderer.color = Color.white;
        
        Random rnd = new Random();
        //в случайном направлении (лево или право) швыряем мяч со скоростью которую можно в редакторе задать
        //можно было постоянно контролировать скорость, но так интересней
        //так мячик более физичный и его можно ускорить если ударить низом ракетки
        _startSpeed = new Vector2(_choiceX[rnd.Next(0,6)], _choiceY[rnd.Next(0,6)]) * _speed;
        _rbBall.AddForce(_startSpeed);

    }
    
}
