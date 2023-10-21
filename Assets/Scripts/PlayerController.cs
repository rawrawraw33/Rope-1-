using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f; // �������� �������� ������
    public float turnSpeed = 200f; // �������� ��������

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

        // ���������, �������� �� �� ��������� ���������� (��������� ����������)
        if (Application.isMobilePlatform)
        {
            // ������������ ������� ������ ��� ���������� ����������
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    // ����������, � ����� ����������� ��� ������ ���� (����� ��� ������)
                    float swipeDirection = touch.deltaPosition.x;

                    if (swipeDirection < 0)
                    {
                        // ������� �����
                        horizontalInput = -1;
                    }
                    else if (swipeDirection > 0)
                    {
                        // ������� ������
                        horizontalInput = 1;
                    }
                }
            }
        }
        else
        {
            // ������������ ������� ������ ��� ��
            horizontalInput = Input.GetAxis("Horizontal");
        }

        // ��������� �������
        _transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
