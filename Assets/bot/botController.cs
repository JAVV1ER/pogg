using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
    public GameObject ball;
    public float speed = 10f;
    private Rigidbody2D rb;
    private Rigidbody2D rbBall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbBall = ball.GetComponent<Rigidbody2D>();
    }
    private void Movement()
    {
        //if(ball.transform.position.x != 110)
        //{
        //    float moveHorizontal = ball.transform.position.y;
        //    Vector2 movement = new Vector2(0, moveHorizontal);

        //    rb.AddForce(movement * speed);
        //}
        //if(ball.transform.position.y > 1)
        //{
        //    transform.Translate(new Vector3(0, 0.1f * speed, 0));
        //}
        //else if(ball.transform.position.y < 0)
        //{
        //    transform.Translate(new Vector3(0, -0.1f * speed, 0));
        //}

        //Vector2 moveY = Vector2.ClampMagnitude(new Vector2(0,ball.transform.position.y), 1);
        rb.MovePosition((new Vector2(0, ball.transform.position.y) * 40 * speed * Time.fixedDeltaTime));

    }

    void FixedUpdate()
    {
        Movement();
    }
}
