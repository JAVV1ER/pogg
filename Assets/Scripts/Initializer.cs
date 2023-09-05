using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine;
using Object = UnityEngine.Object;

public class Initializer : MonoBehaviour
{
    public Skins currentSkin;
    [SerializeField]
    private Transform _playerPlaceholderTransform;
    private IRacketCustomize _iracketCustomize;
    private GameManager _gameManager;
    
    [SerializeField] 
    private GameObject _playerPrefab;
    private GameObject _playerGameObject;
    private Rigidbody2D _playerRigidbody2D;
    
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
        //_playerGameObject = GameObject.FindWithTag("player");
    }

    private void InitializeGetComponent()
    {
        _ballRigidbody2D = _ballGameObject.GetComponent<Rigidbody2D>();
        _ballSpriteRenderer = _ballGameObject.GetComponent<SpriteRenderer>();
        _ballController = _ballGameObject.GetComponent<BallController>();
        _gameManager = GetComponent<GameManager>();
        //_playerRigidbody2D = _playerRigidbody2D.GetComponent<Rigidbody2D>();
    }

    private void SetReferences()
    {
        _botController.RbBall = _ballRigidbody2D;
        _botController.BotGameObject = _botGameObject;

        _ballController.RbBall = _ballRigidbody2D;
        _ballController.BallSpriteRenderer = _ballSpriteRenderer;
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
        _ballController.Initialize();
        
    }
    void Start()
    {
        
        Instantiate();
        //IRacketCustomize racketCustomize = new RacketCustomize();
        //racketCustomize.StartBuild(currentSkin,);
        InitializeGameObjects();
        InitializeGetComponent();
        CheckReferences();
        SetReferences();
        
        
        _gameManager.SetActiveManager(true);
        _gameManager._BotController = _botController;
        






    }
    
    

    
    
}
