using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    Vector2 moveAxis;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0, moveHorizontal);

        rb.AddForce(movement * speed);
    }
    void Update()
    {
        moveAxis = new Vector2(0, Input.GetAxis("Vertical"));
        moveAxis = Vector2.ClampMagnitude(moveAxis, 1);
    }

    void FixedUpdate()
    {
        //Movement();
        rb.MovePosition(rb.position + (moveAxis * speed * Time.fixedDeltaTime));
    }
}
