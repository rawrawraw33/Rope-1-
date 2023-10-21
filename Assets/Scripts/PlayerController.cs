using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Скорость движения змейки
    public float turnSpeed = 200f; //  скорость поворота

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
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            // Повернуть влево
            _transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0)
        {
            // Повернуть вправо
            _transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
