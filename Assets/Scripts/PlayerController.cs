using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    
    private Vector2 _moveAxis;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        _moveAxis = new Vector2(0, Input.GetAxis("Vertical"));
    }

    public void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + (_moveAxis * (_speed * Time.fixedDeltaTime)));
        
    }

    public void SetColor(Color color)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = color;
    }

    public void SetWidth(float width)
    {
        var tmp = gameObject.transform.localScale;
        tmp.x = width;
        gameObject.transform.localScale = tmp;
    }
}
