using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{
    public string foodTag = "Food";

    private void Update()
    {
        // ������� ��� �������� � ����� "Food"
        GameObject[] foodObjects = GameObject.FindGameObjectsWithTag(foodTag);

        // ������� ������� � ����������� "Rope" � "RopeEnemy"
        GameObject[] ropeObjects = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("FindGameObjectsWithTag(\"Player1\"");
        GameObject[] ropeEnemyObjects = GameObject.FindGameObjectsWithTag("Player1");


        Debug.Log("// ��������� ������� �������� �� ��������� �������");
        if (foodObjects.Length == 0 && ropeObjects.Length > ropeEnemyObjects.Length)
        {
            Debug.Log("//  ����� �  ������� �������� �� ��������� �������");
            UnlockLevel();
            Debug.Log("UnlockLevel done");
            SceneManager.LoadScene(0); // ����� ��������������, ��� � ��� ���� ����� � �������� 0 ��� �������� ����. ������� ���������� ������ ������ ����.
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", currentLevel + 1);
            PlayerPrefs.Save(); // ��������� ��������� � PlayerPrefs
        }
    }
}
