using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScoreManager
{
    
    private static ScoreManager instance;

    private int _scoreBot;
    private int _scorePlayer;
    public int scoreBot
    {
        get => _scoreBot;
        set { _scoreBot = value; }
    }

    public int scorePlayer
    {
        get { return _scorePlayer;}
        set { _scorePlayer = value;}
    }
    

    private TMP_Text _botTMP;
    private TMP_Text _playerTMP;

    public static ScoreManager GetInstance()
    {
        if (instance == null)
        {
            lock (typeof(ScoreManager))
            {
                if (instance == null)
                    instance = new ScoreManager();
            }
        }

        return instance;
    }

    public ScoreManager GetBotScore()
    {
        return this;
    }
    public void IncBotScore()
    {
        scoreBot++;
        BotSetScoreToText();
        Debug.Log("INC bot: " + scoreBot);
    }
    public void IncPlayerScore()
    {
        scorePlayer++;
        PlayerSetScoreToText();
        Debug.Log("INC player: " + scorePlayer);
    }

    public void ClearAllScore()
    {
        scorePlayer = 0;
        PlayerSetScoreToText();
        
        scoreBot = 0;
        BotSetScoreToText();
    }

    private void BotSetScoreToText()
    {
        var botGM = GameObject.FindWithTag("botScore");
        var botTMP = botGM.GetComponent<TMP_Text>();
        botTMP.text = scoreBot.ToString();
    }
    private void PlayerSetScoreToText()
    {
        var playerGM = GameObject.FindWithTag("playerScore");
        var playerTMP = playerGM.GetComponent<TMP_Text>();
        playerTMP.text = scorePlayer.ToString();
    }
    

    
}
