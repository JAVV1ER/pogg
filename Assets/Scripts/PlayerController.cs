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
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //ѕолучаем экземпл¤р физического тела при инициализации, потому что будем использовать движение при помощи физики
        //движение через физику будет плавнее и не будет конфликтов с границами
    }
    
    void Update()
    {
        //ввод с клавиатуры идет через оси, так делать правильно
        // можно настраивать в инпут менеджере клавиши
        _moveAxis = new Vector2(0, Input.GetAxis("Vertical"));
        
    }

    void FixedUpdate()
    {
        //фиксед апдейт нужен чтобы просчитывать физику вне зависимости от частоты кадров
        //а так как ¤ делаю движение через физику а не через телепорты то фиксед апдейт уберет разрывы движений при потере кадров
        _rigidbody2D.MovePosition(_rigidbody2D.position + (_moveAxis * (_speed * Time.fixedDeltaTime)));//ну точнее разрывы уберет Time.fixedDeltaTime - эта переменна¤ хранит врем¤ между кадрами

    }
}
