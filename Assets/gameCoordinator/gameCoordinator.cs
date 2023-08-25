using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class gameCoordinator : MonoBehaviour
{
    private TMP_Text botScore;
    private TMP_Text playerScore;
    public GameObject bot;
    public GameObject player;
    public GameObject btnRetry;
    public GameObject btnExit;
    
    void Start()
    {
        botScore = bot.GetComponent<TMP_Text>();
        playerScore = player.GetComponent<TMP_Text>();
        //при старте уровня возвращаем время назад
        Time.timeScale = 1;
        //кнопки рестарт и выход скрыты при старте уровня
        //это нужно чтобы они вдруг при рестарте не появились
        btnExit.SetActive(false);
        btnRetry.SetActive(false);
    }

    
    void Update()
    {
        if((botScore.text == "7") || (playerScore.text == "7"))
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
