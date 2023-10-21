using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.2f; 
    public string foodTag = "Food"; // Тег объектов с едой

    private List<Transform> foodTargets = new List<Transform>(); // Список целей с едой
    private Transform currentFoodTarget; // Текущая цель с едой
    private bool shouldChasePlayer = false; // Переменная для решения, следует ли преследовать игрока

    void Start()
    {
        // Обновляем список foodTargets в начале игры
        UpdateFoodTargets();
    }

    void Update()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] playerEnemyObjects = GameObject.FindGameObjectsWithTag("Player1");
        int countEnemy = playerEnemyObjects.Length;
        int count = playerObjects.Length;

        // Проверка, следует ли преследовать игрока
        shouldChasePlayer = countEnemy > count;

        if (shouldChasePlayer)
        {
            FindNextFoodTargetPlayer(); // Если следует преследовать игрока
        }
        else
        {
            FindNextFoodTarget(); // Если следует преследовать цели "Food"
        }

        // Оставшаяся логика для движения
        if (currentFoodTarget != null)
        {
            Vector3 direction = (currentFoodTarget.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            float distanceToTarget = Vector3.Distance(transform.position, currentFoodTarget.position);

            if (distanceToTarget < 0.1f)
            {
                foodTargets.Remove(currentFoodTarget);
            }
        }
    }

    void FindNextFoodTarget()
    {
        if (foodTargets.Count > 0)
        {
            Transform closestFood = null;
            float closestDistance = Mathf.Infinity;

            foreach (Transform foodTarget in foodTargets)
            {
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

            currentFoodTarget = closestFood; // Устанавливаем текущую цель
        }
        else
        {
            currentFoodTarget = null;
        }
    }

    void FindNextFoodTargetPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {
            Transform closestPlayer = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);

                if (distance < closestDistance)
                {
                    closestPlayer = player.transform;
                    closestDistance = distance;
                }
            }

            currentFoodTarget = closestPlayer; // Устанавливаем игрока как цель
        }
        else
        {
            currentFoodTarget = null;
        }
    }

    void UpdateFoodTargets()
    {
        // Находим все объекты с тегом "Food" и обновляем список целей
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(foodTag);
        foodTargets.Clear();

        foreach (GameObject foodObject in foodObjects)
        {
            foodTargets.Add(foodObject.transform);
        }
    }
}
