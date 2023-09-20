using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Скорость движения веревки к еде
    public string foodTag = "Food"; // Тег объектов с едой

    private List<Transform> foodTargets = new List<Transform>(); // Список целей с едой
    private Transform currentFoodTarget; // Текущая цель с едой

    void Start()
    {
        // Находим все объекты с тегом "Food" и добавляем их в список целей
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(foodTag);
        foreach (GameObject foodObject in foodObjects)
        {
            foodTargets.Add(foodObject.transform);
        }

        // Находим ближайший объект с едой
        FindNextFoodTarget();
    }

    void Update()
    {
        if (currentFoodTarget != null)
        {
            // Вычисляем направление к текущей цели с едой
            Vector3 direction = (currentFoodTarget.position - transform.position).normalized;

            // Перемещаем веревку в направлении текущей цели
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Проверяем расстояние до текущей цели
            float distanceToTarget = Vector3.Distance(transform.position, currentFoodTarget.position);
            if (distanceToTarget < 0.1f)
            {
                // Если достигли текущей цели, удаляем ее из списка
                foodTargets.Remove(currentFoodTarget);

                // Находим следующую ближайшую цель с едой
                FindNextFoodTarget();
            }
        }
    }

    void FindNextFoodTarget()
    {
        if (foodTargets.Count > 0)
        {
            // Находим ближайший объект с едой из оставшихся целей
            Transform closestFood = null;
            float closestDistance = Mathf.Infinity;

            foreach (Transform foodTarget in foodTargets)
            {
                float distance = Vector3.Distance(transform.position, foodTarget.position);

                if (distance < closestDistance)
                {
                    closestFood = foodTarget;
                    closestDistance = distance;
                }
            }

            currentFoodTarget = closestFood;
        }
        else
        {
            // Если больше нет объектов с едой, сбрасываем текущую цель
            currentFoodTarget = null;
        }
    }











    public GameObject Part;
    private List<GameObject> segments = new List<GameObject>();

    public RopeSpawn ropeSpawn;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Food"))
        {
            // Уничтожаем объект "Food"
            Destroy(collision.gameObject);

            // Создаем новый сегмент веревки
            GameObject newSegment = Instantiate(Part, transform.position, Quaternion.identity);
            if (segments.Count == 0)

            {
                GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

                //newsegment is a last element so we need prelast element 
                Rigidbody lastSegment = playerObjects[playerObjects.Length - 2].GetComponent<Rigidbody>();
                CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();

                if (newSegmentCharacterJoint != null)
                {

                    newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;

                    // Настроим connectedAnchor по вашим требованиям
                    // Например:
                    newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);
                }

                newSegmentCharacterJoint.connectedBody = lastSegment;
            }

            
            // Настраиваем позицию нового сегмента и компоненты, как вам нужно
            if (segments.Count > 0)
            {
                // Находим последний сегмент в списке сегментов
                GameObject lastSegment = segments[segments.Count - 1];

                // Получаем компонент CharacterJoint на новом сегменте
                CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();

                if (newSegmentCharacterJoint != null)
                {
                    // Получаем компонент Rigidbody на последнем сегменте
                    Rigidbody lastSegmentRigidbody = lastSegment.GetComponent<Rigidbody>();
                    newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;

                    // Настроим connectedAnchor по вашим требованиям
                    // Например:
                    newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);

                    if (lastSegmentRigidbody != null)
                    {
                        // Устанавливаем свойство connectedBody для CharacterJoint
                        newSegmentCharacterJoint.connectedBody = lastSegmentRigidbody;
                    }
                    else
                    {
                        // Если компонент Rigidbody отсутствует на последнем сегменте, нужно обработать этот случай
                        // Можно вывести отладочное сообщение или предпринять другие действия по вашему усмотрению
                    }
                }
                else
                {
                    // Если компонент CharacterJoint отсутствует на новом сегменте, нужно обработать этот случай
                    // Можно вывести отладочное сообщение или предпринять другие действия по вашему усмотрению
                }

                // Присоединяем новый сегмент к предыдущему
                newSegment.GetComponent<CharacterJoint>().connectedBody = lastSegment.GetComponent<Rigidbody>();
            }

            segments.Add(newSegment);
        }
    }
}
