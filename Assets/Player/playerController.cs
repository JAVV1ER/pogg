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
        rb = GetComponent<Rigidbody2D>(); //ѕолучаем экземпл¤р физического тела при инициализации, потому что будем использовать движение при помощи физики
        //движение через физику будет плавнее и не будет конфликтов с границами
    }
    
    void Update()
    {
        //ввод с клавиатуры идет через оси, так делать правильно
        // можно настраивать в инпут менеджере клавиши
        moveAxis = new Vector2(0, Input.GetAxis("Horizontal"));
        
    }

    void FixedUpdate()
    {
        //фиксед апдейт нужен чтобы просчитывать физику вне зависимости от частоты кадров
        //а так как ¤ делаю движение через физику а не через телепорты то фиксед апдейт уберет разрывы движений при потере кадров
        rb.MovePosition(rb.position + (moveAxis * speed * Time.fixedDeltaTime));//ну точнее разрывы уберет Time.fixedDeltaTime - эта переменна¤ хранит врем¤ между кадрами

    }
}
