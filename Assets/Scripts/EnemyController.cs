using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.2f; // Скорость движения веревки к еде
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
        else
        {
            // Если больше нет объектов с едой, сбрасываем текущую цель
            // и продолжаем двигаться в том же направлении, если есть другие цели
            FindNextFoodTarget();
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
                // Проверяем, что foodTarget не равен null, чтобы избежать ошибки
                if (foodTarget != null)
                {
                    float distance = Vector3.Distance(transform.position, foodTarget.position);

                    if (distance < closestDistance)
                    {
                        closestFood = foodTarget;
                        closestDistance = distance;
                    }
                }
            }

            // Добавляем условие для выбора игрока с наибольшим количеством частей
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                int playerSegmentCount = player.transform.childCount;
                if (playerSegmentCount > foodTargets.Count)
                {
                    closestFood = player.transform; // Этот игрок становится целью с едой
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












}
