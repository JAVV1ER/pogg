using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    private GameObject _bot;
    [SerializeField]
    private float speed = 10f;
    
    private Rigidbody2D _rbBall;
    
    void Start()
    {
        ball = GameObject.FindWithTag("ball");
        _bot = GameObject.FindWithTag("bot");
        _rbBall = ball.GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        // Бот ворует координату Y у мяча
        _bot.transform.position = _bot.transform.position + Vector3.ClampMagnitude(new Vector3(0,_rbBall.velocity.y),speed) * Time.fixedDeltaTime;
    }

    
}
