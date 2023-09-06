using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Score
{
    public event Action OnPlayerWon;
    public event Action OnBotWon;
    
    private static Score _instance;

    public int scoreToWin {set => _scoreToWin = value;}
    private int _scoreToWin;
    public static Score Instance => _instance ??= new Score();
    
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

    public Score GetBotScore()
    {
        return this;
    }
    public void IncBotScore()
    {
        ScoreBot++;
        BotSetScoreToText();
        Debug.Log("INC bot: " + ScoreBot);
        if(_scoreToWin == ScoreBot) OnBotWon?.Invoke();
        
    }
    public void IncPlayerScore()
    {
        ScorePlayer++;
        PlayerSetScoreToText();
        Debug.Log("INC player: " + ScorePlayer);
        if(_scoreToWin == ScorePlayer) OnPlayerWon?.Invoke();
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
        var gameObject = GameObject.FindWithTag("botScore");
        var botTMP = gameObject.GetComponent<TMP_Text>();
        botTMP.text = ScoreBot.ToString();
    }
    private void PlayerSetScoreToText()
    {
        var gameObject = GameObject.FindWithTag("playerScore");
        var playerTMP = gameObject.GetComponent<TMP_Text>();
        playerTMP.text = ScorePlayer.ToString();
    }
    
}
