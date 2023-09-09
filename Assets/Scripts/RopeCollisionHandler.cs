using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollisionHandler : MonoBehaviour
{
    public GameObject Part; // Префаб сегмента веревки
    private List<GameObject> segments = new List<GameObject>(); // Список сегментов

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            // Добавить новый сегмент веревке
            AddSegment();

            // Удалить объект Food
            Destroy(collision.gameObject);
        }
    }

    private void AddSegment()
    {
        // Создать новый сегмент на месте последнего сегмента (или начальной позиции веревки)
        Vector3 spawnPosition = segments.Count > 0 ? segments[segments.Count - 1].transform.position : transform.position;
        GameObject newSegment = Instantiate(Part, spawnPosition, Quaternion.identity);
        
        // Добавить сегмент в список и установить ссылки на предыдущий сегмент
        segments.Add(newSegment);

        // Можно также применить логику для добавления сегментов в конец веревки и их удаления с начала при достижении определенной длины
    }
    
}