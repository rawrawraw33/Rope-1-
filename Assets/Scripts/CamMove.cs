using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target; // Ссылка на трансформ игрока, за которым камера должна следить
    public Vector3 offset = new Vector3(0f, 1f, -1f); // Смещение камеры относительно игрока

    void LateUpdate()
    {
        if (target != null)
        {
            // Устанавливаем позицию камеры так, чтобы она следила за игроком с учетом смещения
            transform.position = target.position + offset;
        }
    }
}

