using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : IClockable//: MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    
    private GameManager _gameManager;
    private Vector2 _moveAxis;
    public Rigidbody2D Rigidbody2D {set => _rigidbody2D = value;}
    private Rigidbody2D _rigidbody2D;
    
    public SpriteRenderer SpriteRenderer {set => _spriteRenderer = value;}
    private SpriteRenderer _spriteRenderer;

    public Transform transform {set => _transform = value;}
    private Transform _transform;
    
    public void UpdateTick()
    {
        _moveAxis = new Vector2(0, Input.GetAxis("Vertical"));
        _rigidbody2D.MovePosition(_rigidbody2D.position + (_moveAxis * (_speed * Time.fixedDeltaTime)));
    }

    public void SetColor(Color color) { _spriteRenderer.color = color; }

    public void SetWidth(float width)
    {
        var tmp = _transform.localScale;
        tmp.x = width;
        _transform.localScale = tmp;
    }
}
