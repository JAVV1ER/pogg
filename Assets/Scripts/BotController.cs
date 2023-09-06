using Interfaces;
using UnityEngine;

public class BotController : IClockable//: MonoBehaviour
{

    private GameObject _botObject;
    private float _speed = 10f;
    
    public ITarget Target { private get; set; }
    
    public GameObject BotGameObject {set => _botObject = value;}


    public void UpdateTick()
    {
        // Бот ворует скорость Y у мяча
        var racketPos = _botObject.transform.position;
        
        racketPos = Vector2.Lerp(
            racketPos, new Vector2(racketPos.x, Target.Position.y), _speed * Time.deltaTime);
        
        _botObject.transform.position = racketPos;
    }

    
}
