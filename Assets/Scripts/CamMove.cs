using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target; // ������ �� ��������� ������, �� ������� ������ ������ �������
    public Vector3 offset = new Vector3(0f, 1f, -1f); // �������� ������ ������������ ������

    void LateUpdate()
    {
        if (target != null)
        {
            // ������������� ������� ������ ���, ����� ��� ������� �� ������� � ������ ��������
            transform.position = target.position + offset;
        }
    }
}

