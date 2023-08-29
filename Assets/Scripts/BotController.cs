using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public GameObject ball;//в редакторе нельзя сразу получить Rb(насколько мне известно) поэтому сначала я получаю GameObject и из него получаю Rb
    public float speed = 10f;
    
    private Rigidbody2D _rbBall;
    
    void Start()
    {
        //тут движение будет телепортами, потому что через физику у меня бот двигался ужасно
        
        _rbBall = ball.GetComponent<Rigidbody2D>();
        //ссылка на шарик, будем двигаться используя его физическую скорость
    }
    void FixedUpdate()
    {
        //двигоаемся телепортом, по другому у меня не работало...
        //ClampMagnitude задает предел повторения движения за шариком, не тоесть скорость(float speed) регулирует не скорость а степень схожести скорости с шариком
        transform.position = transform.position + Vector3.ClampMagnitude(new Vector3(0,_rbBall.velocity.y),speed) * Time.fixedDeltaTime;
        //умножаем на фиксед дельта чтобы плавнее было

    }

    
}
