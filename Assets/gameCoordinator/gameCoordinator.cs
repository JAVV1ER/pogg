using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class gameCoordinator : MonoBehaviour
{
    private TMP_Text botScore;
    private TMP_Text playerScore;
    public GameObject bot;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        botScore = bot.GetComponent<TMP_Text>();
        playerScore = player.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if((botScore.text == "7") || (playerScore.text == "7"))
        {
            Debug.Log("WIN");
        }
    }
}
