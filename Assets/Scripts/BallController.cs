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
    // TODO: Убрать Public когда появится ScoreManager
    public int _playerScore;
    public int _botScore;
    
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _bot;
    [SerializeField]
    private GameObject _player;
    
    [Space(20)]
    [SerializeField]
    private Color _colorBallLocked = Color.white;
    [SerializeField]
    private Color _colorBallStandart = Color.white;
    [SerializeField] 
    private Color _colorBallReadyToGo = Color.white;
    
    [Space(20)]
    [SerializeField]
    private float _waitBallReady = 2f;
    [SerializeField]
    private float _waitBallStandart = 1f;
    
    
    
    private TMP_Text _botTMPText;
    private TMP_Text _playerTMPText;
    private Vector2 _startSpeed;
    private Rigidbody2D _rbBall;
    private SpriteRenderer _ballSpriteRenderer;
    private IEnumerator _coroutine;
    
    
    private float[] _choiceX = new float[6] { -50, 50, -40, 40, -60, 60 };
    private float[] _choiceY = new float[6] { -50, 50, -40, 40, -60, 60 };
    
    
    void Start()
    {
        _rbBall = GetComponent<Rigidbody2D>();
        _botTMPText = _bot.GetComponent<TMP_Text>();
        _playerTMPText = _player.GetComponent<TMP_Text>();
        _ballSpriteRenderer= GetComponent<SpriteRenderer>();
        
        CheckReferences();
        
        StartCoroutine(RespawnRoutine());
    }

    void CheckReferences()
    {
        if (_bot == null)
            Debug.LogError("Bot не найден");
        if (_player == null)
            Debug.LogError("Player не найден");
        
        // TODO: Добавить проверку компонентов
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("botBorder"))
        {
            // TODO: Добавить ScoreManager, передать управление очками ему
            _botScore += 1;
            _botTMPText.text = _botScore.ToString();
            
            StartCoroutine(RespawnRoutine());
        }
        if (collision.gameObject.CompareTag("playerBorder"))
        {
            _playerScore += 1;
            _playerTMPText.text = _playerScore.ToString();
            
            StartCoroutine(RespawnRoutine());
        }
    }
    private IEnumerator RespawnRoutine()
    {
        
        // TODO: Переделать рандом
        // TODO: Убрать хардкод
        
        _ballSpriteRenderer.color = Color.red;
        
        _rbBall.velocity = Vector2.zero;
        _rbBall.position = Vector2.zero;
        
        yield return new WaitForSeconds(_waitBallReady);
        _ballSpriteRenderer.color = _colorBallReadyToGo;
        yield return new WaitForSeconds(_waitBallStandart);
        _ballSpriteRenderer.color = _colorBallStandart;
        
        Random rnd = new Random();
        _startSpeed = new Vector2(_choiceX[rnd.Next(0,6)], _choiceY[rnd.Next(0,6)]).normalized * _speed;
        _rbBall.AddForce(_startSpeed);

    }
    
}
