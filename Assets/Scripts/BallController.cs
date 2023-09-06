using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Random = System.Random;

public class BallController : MonoBehaviour, ITarget
{
    [SerializeField]
    private float _speed = 10f;
    
    [Space(20)]
    [SerializeField]
    private Color _colorBallLocked = Color.white;
    [SerializeField]
    private Color _colorBallStandart = Color.white;
    [SerializeField] 
    private Color _colorBallReadyToGo = Color.white;
    
    [Space(20)]
    [SerializeField]
    private float _waitBallReady = 2f;
    [SerializeField]
    private float _waitBallStandart = 1f;

    public Vector2 Position
    {
        get
        {
            if (_rb.velocity.x < 0) return Vector2.zero;
            
            return this.transform.position;
        }
    }
    public event Action OnBotBoundsEnter;
    public event Action OnPlayerBoundsEnter;
    
    private Vector2 _startSpeed;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    public void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (_rb == null || _spriteRenderer == null)
            throw new NullReferenceException("Компоненты Ball были null");
        
        StartCoroutine(RespawnRoutine());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("botBorder"))
        {
            OnBotBoundsEnter?.Invoke();
            StartCoroutine(RespawnRoutine());
        }
        else if (collision.gameObject.CompareTag("playerBorder"))
        {
            OnPlayerBoundsEnter?.Invoke();
            StartCoroutine(RespawnRoutine());
        }
            
    }
    
    private IEnumerator RespawnRoutine()
    {
        // TODO: Убрать хардкод
        _spriteRenderer.color = _colorBallLocked;
        
        _rb.velocity = Vector2.zero;
        _rb.position = Vector2.zero;
        
        yield return new WaitForSeconds(_waitBallReady);
        _spriteRenderer.color = _colorBallReadyToGo;
        yield return new WaitForSeconds(_waitBallStandart);
        _spriteRenderer.color = _colorBallStandart;
        
        Random rnd = new Random();
        // TODO: Переделать рандом
        // _startSpeed = new Vector2(
        //         (float)rnd.NextDouble()/2,
        //         (float)rnd.NextDouble()/2)
        //     .normalized;
        _startSpeed = new Vector2()
        {
            x = (float)rnd.NextDouble()/2,
            y = (float)rnd.NextDouble()/2
        }.normalized;
        Debug.Log(_startSpeed);
        Debug.Log(_startSpeed*2);
        _rb.AddRelativeForce(_startSpeed * _speed, ForceMode2D.Force);
    }
}
