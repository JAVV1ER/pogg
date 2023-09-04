using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [InspectorName("Player Settings")]
    public Skins currentSkin;
    [SerializeField]
    private Transform _playerPlaceholderTransform;
    private IRacketCustomize _iracketCustomize;
    
    [SerializeField] 
    private GameObject _playerPrefab;
    private GameObject _playerGameObject;
    private Rigidbody2D _playerRigidbody2D;
    
    private GameObject _botGameObject;
    private BotController _botController;
    
    
    private GameObject _ballGameObject;
    private Rigidbody2D _ballRigidbody2D;
    


    private void InittializeGameObjects()
    {
        _ballGameObject = GameObject.FindWithTag("ball");
        _botGameObject = GameObject.FindWithTag("bot");
        //_playerGameObject = GameObject.FindWithTag("player");
    }

    private void InitializeRigidbody()
    {
        _ballRigidbody2D = _ballGameObject.GetComponent<Rigidbody2D>();
        //_playerRigidbody2D = _playerRigidbody2D.GetComponent<Rigidbody2D>();
    }

    private void SetReferences()
    {
        _botController.RbBall = _ballRigidbody2D;
        _botController.BotGameObject = _botGameObject;
    }

    private void Instantiate()
    {
        _botController = new BotController();
    }
    void Start()
    {
        
        //Instantiate();
        IRacketCustomize racketCustomize = new RacketCustomize();
        //racketCustomize.StartBuild(currentSkin,);
        InittializeGameObjects();
        InitializeRigidbody();
        SetReferences();
        




    }

    
    
}
