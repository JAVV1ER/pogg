using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ballController : MonoBehaviour
{
    public float speed = 10f;
    private TMP_Text botScore;
    private TMP_Text playerScore;
    public GameObject bot;
    public GameObject player;
    private int botCheck;
    private int playerCheck;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbBall = GetComponent<Rigidbody2D>();
        Vector2 startSpeed = new Vector2(100, 100) * speed * Time.deltaTime;
        rbBall.AddForce(startSpeed);
        botScore = bot.GetComponent<TMP_Text>();
        playerScore = player.GetComponent<TMP_Text>();
        botCheck = 0;
        playerCheck = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "botBorder")
        {
            botCheck += 1;
            botScore.text = botCheck.ToString();
        }
        if (collision.gameObject.tag == "playerBorder")
        {
            playerCheck += 1;
            playerScore.text = playerCheck.ToString();
        }
    }
}
