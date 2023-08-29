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
    private GameObject _player;
    [SerializeField]
    private GameObject _btnRetry;
    [SerializeField]
    private GameObject _btnExit;
    [SerializeField]
    private GameObject _bot;

    [Space(10)]
    [SerializeField]
    private GameObject _ballObject;
    
    private BallController _togetherScoreCheck;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;
    
    void Start()
    {
        //при старте уровня возвращаем время назад
        Time.timeScale = 1;
        
        //кнопки рестарт и выход скрыты при старте уровня
        //это нужно чтобы они вдруг при рестарте не появились
        _btnExit.SetActive(false);
        _btnRetry.SetActive(false);
        
        _togetherScoreCheck = _ballObject.GetComponent<BallController>();

        CheckReferences();
    }

    void CheckReferences()
    {
        if (_player == null)
            Debug.LogError("Player не найден");
        if (_btnRetry == null)
            Debug.LogError("ButtonRetry не найден");
        if (_btnExit == null)
            Debug.LogError("ButtonExit не найден");
        if (_bot == null)
            Debug.LogError("Bot не найден");
        if (_ballObject == null)
            Debug.LogError("Ball не найден");
        if (_togetherScoreCheck == null)
            Debug.LogError("BallController был null");
    }

    
    void Update()
    {
        if((_togetherScoreCheck.botCheck == 7) || (_togetherScoreCheck.playerCheck == 7))
        {
            //мониторим пока като-то не забьет 7 очков
            //если кто-то забил то останавливаем время, чтобы игра не играла в саму себя
            Time.timeScale = 0;
            
            //показываем кнопки
            _btnExit.SetActive(true);
            _btnRetry.SetActive(true);
        }
    }
    //эти функции привязаны к кнопкам в редакторе
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
