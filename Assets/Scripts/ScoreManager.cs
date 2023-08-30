using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScoreManager
{
    public static ScoreManager Instance
    {
        get
        {
            return _instance;
            
            
        }
        set
        {
            if (_instance == null) _instance = value;
            else throw new ArgumentException();
        }
    }

    private static ScoreManager _instance;

    public int scoreBot;
    public int scorePlayer;

    
    public void IncBot()
    {
        scoreBot++;
        Debug.Log(scoreBot);
    }
    public void IncPlayer()
    {
        scorePlayer++;
        Debug.Log(scorePlayer);
    }
}
