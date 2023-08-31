using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameCoordinator : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _btnRetry;
    [SerializeField]
    private GameObject _btnExit;

    [SerializeField] 
    private int _scoreToWin = 3;

    
    [Space(10)]
    [SerializeField]
    private GameObject _ballGameObject;
    
    private BallController _ballController;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;
    
    void Start()
    {
        
        Time.timeScale = 1;
        
        _btnExit.SetActive(false);
        _btnRetry.SetActive(false);
        
        _ballController = _ballGameObject.GetComponent<BallController>();

        CheckReferences();
    }

    void CheckReferences()
    {
        
        if (_btnRetry == null)
            Debug.LogError("ButtonRetry не найден");
        if (_btnExit == null)
            Debug.LogError("ButtonExit не найден");
        if (_ballGameObject == null)
            Debug.LogError("Ball не найден");
        if (_ballController == null)
            Debug.LogError("BallController был null");
    }

    void Update()
    {
        if((ScoreManager.GetInstance()._scoreBot == _scoreToWin) || (ScoreManager.GetInstance()._scorePlayer == _scoreToWin))
        {
            ScoreManager.GetInstance().ClearAllScore();
            Time.timeScale = 0;
            _btnExit.SetActive(true);
            _btnRetry.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
