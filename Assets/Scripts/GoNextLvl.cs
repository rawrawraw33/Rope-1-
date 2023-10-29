using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{
    public string foodTag = "Food";

    private void Update()
    {
        // Находим все элементы с тегом "Food"
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(foodTag);

        // Находим объекты с компонентом "Rope" и "RopeEnemy"
        GameObject[] ropeObjects = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("FindGameObjectsWithTag(\"Player1\"");
        GameObject[] ropeEnemyObjects = GameObject.FindGameObjectsWithTag("Player1");


        Debug.Log("// Проверяем условие перехода на следующий уровень");
        if (foodObjects.Length == 0 && ropeObjects.Length > ropeEnemyObjects.Length)
        {
            Debug.Log("//  зашли в  условие перехода на следующий уровень");
            UnlockLevel();
            Debug.Log("UnlockLevel done");
            SceneManager.LoadScene(0); // Здесь предполагается, что у вас есть сцена с индексом 0 для главного меню. Укажите правильный индекс вашего меню.
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", currentLevel + 1);
            PlayerPrefs.Save(); // Сохраняем изменения в PlayerPrefs
        }
    }
}
