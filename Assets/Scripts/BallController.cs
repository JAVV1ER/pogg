using System.Collections;
using UnityEngine;
using Random = System.Random;

public class BallController : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _bot;
    [SerializeField]
    private GameObject _player;
    
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
    
    private Vector2 _startSpeed;
    private Rigidbody2D _rbBall;
    private SpriteRenderer _ballSpriteRenderer;
    
    void Start()
    {
        _rbBall = GetComponent<Rigidbody2D>();
        _ballSpriteRenderer= GetComponent<SpriteRenderer>();
        
        CheckReferences();
        
        StartCoroutine(RespawnRoutine());
    }

    void CheckReferences()
    {
        if (_bot == null)
            Debug.LogError("Bot не найден");
        if (_player == null)
            Debug.LogError("Player не найден");
        
        // TODO: Добавить проверку компонентов
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("botBorder"))
        {
            ScoreManager.GetInstance().IncBotScore();
            StartCoroutine(RespawnRoutine());
        }
        if (collision.gameObject.CompareTag("playerBorder"))
        {
            ScoreManager.GetInstance().IncPlayerScore();
            StartCoroutine(RespawnRoutine());
        }
    }
    private IEnumerator RespawnRoutine()
    {
        // TODO: Убрать хардкод
        _ballSpriteRenderer.color = _colorBallLocked;
        
        _rbBall.velocity = Vector2.zero;
        _rbBall.position = Vector2.zero;
        
        yield return new WaitForSeconds(_waitBallReady);
        _ballSpriteRenderer.color = _colorBallReadyToGo;
        yield return new WaitForSeconds(_waitBallStandart);
        _ballSpriteRenderer.color = _colorBallStandart;
        
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
        _rbBall.AddRelativeForce(_startSpeed * _speed, ForceMode2D.Force);

    }
    
}
