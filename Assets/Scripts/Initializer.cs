using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class Initializer : MonoBehaviour
{
    public Skins _playerCurrentSkin;
    [SerializeField]
    private int _scoreToWin;
    [SerializeField]
    private Transform _playerPlaceholderTransform;
    private GameManager _gameManager;
    
    [SerializeField] 
    private GameObject _playerPrefab;
    private GameObject _playerGameObject;
    private Rigidbody2D _playerRigidbody2D;
    private RacketVariants _playerBuilder;
    private PlayerController _playerController;
    private SpriteRenderer _playerSpriteRenderer;
    private Transform _playerTransform;
    
    private GameObject _botGameObject;
    private BotController _botController;
    
    private BallController _ballController;
    private GameObject _ballGameObject;
    private Rigidbody2D _ballRigidbody2D;
    private SpriteRenderer _ballSpriteRenderer;
    
    private void InitializeGameObjects()
    {
        _ballGameObject = GameObject.FindWithTag("ball");
        _botGameObject = GameObject.FindWithTag("bot");
        _playerGameObject = GameObject.FindWithTag("player");
    }

    private void InitializeGetComponent()
    {
        _ballRigidbody2D = _ballGameObject.GetComponent<Rigidbody2D>();
        _ballSpriteRenderer = _ballGameObject.GetComponent<SpriteRenderer>();
        _ballController = _ballGameObject.GetComponent<BallController>();
        
        _playerRigidbody2D = _playerGameObject.GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = _playerGameObject.GetComponent<SpriteRenderer>();
        _playerTransform = _playerGameObject.GetComponent<Transform>();
            
        _gameManager = GetComponent<GameManager>();
        
    }

    private void SetReferences()
    {
        _botController.Target = _ballController;
        _botController.BotGameObject = _botGameObject;
        
        _playerController.Rigidbody2D = _playerRigidbody2D;
        _playerController.SpriteRenderer = _playerSpriteRenderer;
        _playerController.transform = _playerTransform;
        
        _gameManager.SetActiveManager(true);
        _gameManager.BotController = _botController;
        _gameManager.PlayerController = _playerController;
    }
    
    void CheckReferences()
    {
        if (_botGameObject == null)
            Debug.LogError("Bot не найден");
        if (_ballRigidbody2D == null)
            Debug.LogError("Ball Rb не найден");
        if (_ballGameObject == null)
            Debug.LogError("Ball не найден");
        if (_playerGameObject == null)
            Debug.LogError("Player не найден");
        if (_ballSpriteRenderer == null)
            Debug.LogError("BallSpriteRenderer не найден");
        
        // TODO: Добавить проверку компонентов
    }
    
    private void Instantiate()
    {
        _botController = new BotController();
        _playerGameObject = RacketVariants.ClassicRacket(_playerPrefab, _playerPlaceholderTransform);
        _playerController = new PlayerController();
        
        
    }
    
    void Start()
    {
        Instantiate();
        
        InitializeGameObjects();
        InitializeGetComponent();
        CheckReferences();
        SetReferences();
        
        SubscribeToEvents();
        
        _ballController.Initialize();
        
        //_gameManager.PlayerBuilder = _playerBuilder;
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    private void SubscribeToEvents()
    {
        var score = Score.Instance;
        
        _ballController.OnBotBoundsEnter += score.IncBotScore;
        _ballController.OnPlayerBoundsEnter += score.IncPlayerScore;

        score.OnBotWon += _gameManager.OnBotWon;
        score.OnPlayerWon += _gameManager.OnPlayerWon;
    }

    private void UnsubscribeFromEvents()
    {
        try
        {
            var score = Score.Instance;
            
            _ballController.OnBotBoundsEnter -= score.IncPlayerScore;
            _ballController.OnPlayerBoundsEnter -= score.IncBotScore;
            
            score.OnBotWon -= _gameManager.OnBotWon;
            score.OnPlayerWon -= _gameManager.OnPlayerWon;
        }
        catch (Exception e)
        {
            Debug.LogError($"При попытке отписаться от событий произошла критическая ошибка. Текст: {e.Message}");
        }
    }
}
