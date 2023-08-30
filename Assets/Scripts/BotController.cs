using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    
    public GameObject ball;
    public float speed = 10f;
    
    private Rigidbody2D _rbBall;
    
    void Start()
    {
        _rbBall = ball.GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        // Бот ворует координату Y у мяча
        transform.position = transform.position + Vector3.ClampMagnitude(new Vector3(0,_rbBall.velocity.y),speed) * Time.fixedDeltaTime;
    }

    
}
