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
        //��� ������ ������ ���������� ����� �����
        Time.timeScale = 1;
        //������ ������� � ����� ������ ��� ������ ������
        //��� ����� ����� ��� ����� ��� �������� �� ���������
        btnExit.SetActive(false);
        btnRetry.SetActive(false);
    }

    
    void Update()
    {
        if((botScore.text == "7") || (playerScore.text == "7"))
        {
            //��������� ���� ����-�� �� ������ 7 �����
            //���� ���-�� ����� �� ������������� �����, ����� ���� �� ������ � ���� ����
            Time.timeScale = 0;
            //���������� ������
            btnExit.SetActive(true);
            btnRetry.SetActive(true);
        }
    }
    //��� ������� ��������� � ������� � ���������
    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
