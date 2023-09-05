using Interfaces;
using UnityEngine;

public class BotController : IBotController//: MonoBehaviour
{

    private GameObject _botGameObjectGameObject;
    private Rigidbody2D _rbBall;
    private float _speed = 10f;
    
    
    public GameObject BotGameObject {set => _botGameObjectGameObject = value;}

    public Rigidbody2D RbBall {set => _rbBall = value;}


    public void FixedUpdate()
    {
        // Бот ворует скорость Y у мяча
        _botGameObjectGameObject.transform.position += Vector3.ClampMagnitude(new Vector3(0,_rbBall.velocity.y),_speed)
                                  * Time.fixedDeltaTime;
    }

    
}
