using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comparison : MonoBehaviour
{
    public RopeSpawnEnemy ropeSpawnEnemy;
    public RopeSpawn ropeSpawn;

    void Update()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] playerEnemyObjects = GameObject.FindGameObjectsWithTag("Player1");
        // Получаем количество элементов в RopeSpawnEnemy
        int countEnemy = playerEnemyObjects.Length;

        // Получаем количество элементов в RopeSpawn
        int count = playerObjects.Length;



        // Сравниваем количество элементов
        //if (countEnemy > count)
        //{
        //    Debug.Log("RopeSpawnEnemy имеет больше элементов." + count.ToString() + countEnemy.ToString());

        //}
        //else if (countEnemy < count)
        //{
        //    Debug.Log("RopeSpawn имеет больше элементов." + count.ToString() + countEnemy.ToString());
        //}
        //else
        //{
        //    Debug.Log("RopeSpawnEnemy и RopeSpawn имеют одинаковое количество элементов." + count.ToString() + countEnemy.ToString());
        //}
    }
}
