using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ScoreManager
{
    
    private static ScoreManager instance;

    public int _scoreBot;
    public int _scorePlayer;

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
        _scoreBot++;
        BotSetScoreToText();
        Debug.Log("INC bot: " + _scoreBot);
    }
    public void IncPlayerScore()
    {
        _scorePlayer++;
        PlayerSetScoreToText();
        Debug.Log("INC player: " + _scorePlayer);
    }

    public void ClearAllScore()
    {
        _scorePlayer = 0;
        PlayerSetScoreToText();
        
        _scoreBot = 0;
        BotSetScoreToText();
    }

    private void BotSetScoreToText()
    {
        var botGM = GameObject.FindWithTag("botScore");
        var botTMP = botGM.GetComponent<TMP_Text>();
        botTMP.text = _scoreBot.ToString();
    }
    private void PlayerSetScoreToText()
    {
        var playerGM = GameObject.FindWithTag("playerScore");
        var playerTMP = playerGM.GetComponent<TMP_Text>();
        playerTMP.text = _scorePlayer.ToString();
    }
    

    
}
