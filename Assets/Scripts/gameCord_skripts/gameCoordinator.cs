using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class gameCoordinator : MonoBehaviour
{
    public GameObject bot;
    public GameObject player;
    public GameObject btnRetry;
    public GameObject btnExit;
    
    private TMP_Text _botScore;
    private TMP_Text _playerScore;
    private ballController _togetherScoreCheck;
    
    void Start()
    {
        //при старте уровня возвращаем время назад
        Time.timeScale = 1;
        //кнопки рестарт и выход скрыты при старте уровня
        //это нужно чтобы они вдруг при рестарте не появились
        btnExit.SetActive(false);
        btnRetry.SetActive(false);
        _togetherScoreCheck = GetComponent<ballController>();
        
    }

    
    void Update()
    {
        if((_togetherScoreCheck.botCheck == 7) || (_togetherScoreCheck.playerCheck == 7))
        {
            //мониторим пока като-то не забьет 7 очков
            //если кто-то забил то останавливаем время, чтобы игра не играла в саму себя
            Time.timeScale = 0;
            //показываем кнопки
            btnExit.SetActive(true);
            btnRetry.SetActive(true);
        }
    }
    //эти функции привязаны к кнопкам в редакторе
    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
