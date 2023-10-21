using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Скорость движения змейки
    public float turnSpeed = 200f; // Скорость поворота

    private Transform _transform;
    private Vector3 moveDirection = Vector3.forward;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveForward();
        HandleInput();
    }

    private void MoveForward()
    {
        _transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleInput()
    {
        float horizontalInput = 0;

        // Проверяем, работаем ли на сенсорном устройстве (мобильное устройство)
        if (Application.isMobilePlatform)
        {
            // Обрабатываем входные данные для сенсорного устройства
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // Определите, в каком направлении был сделан жест (влево или вправо)
                    float swipeDirection = touch.deltaPosition.x;

                    if (swipeDirection < 0)
                    {
                        // Поворот влево
                        horizontalInput = -1;
                    }
                    else if (swipeDirection > 0)
                    {
                        // Поворот вправо
                        horizontalInput = 1;
                    }
                }
            }
        }
        else
        {
            // Обрабатываем входные данные для ПК
            horizontalInput = Input.GetAxis("Horizontal");
        }

        // Применяем поворот
        _transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
