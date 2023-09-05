using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScoreManager
{
    
    private static ScoreManager _instance;

    private int _scoreBot;
    private int _scorePlayer;
    public int ScoreBot
    {
        get => _scoreBot;
        set { _scoreBot = value; }
    }

    public int ScorePlayer
    {
        get { return _scorePlayer;}
        set { _scorePlayer = value;}
    }
    

    private TMP_Text _botTMP;
    private TMP_Text _playerTMP;

    public static ScoreManager GetInstance()
    {
        if (_instance == null)
        {
            lock (typeof(ScoreManager))
            {
                if (_instance == null)
                    _instance = new ScoreManager();
            }
        }

        return _instance;
    }

    public ScoreManager GetBotScore()
    {
        return this;
    }
    public void IncBotScore()
    {
        ScoreBot++;
        BotSetScoreToText();
        Debug.Log("INC bot: " + ScoreBot);
    }
    public void IncPlayerScore()
    {
        ScorePlayer++;
        PlayerSetScoreToText();
        Debug.Log("INC player: " + ScorePlayer);
    }

    public void ClearAllScore()
    {
        ScorePlayer = 0;
        PlayerSetScoreToText();
        
        ScoreBot = 0;
        BotSetScoreToText();
    }

    private void BotSetScoreToText()
    {
        var botGM = GameObject.FindWithTag("botScore");
        var botTMP = botGM.GetComponent<TMP_Text>();
        botTMP.text = ScoreBot.ToString();
    }
    private void PlayerSetScoreToText()
    {
        var playerGM = GameObject.FindWithTag("playerScore");
        var playerTMP = playerGM.GetComponent<TMP_Text>();
        playerTMP.text = ScorePlayer.ToString();
    }
    

    
}
