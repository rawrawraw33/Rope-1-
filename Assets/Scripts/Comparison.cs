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
        // �������� ���������� ��������� � RopeSpawnEnemy
        int countEnemy = playerEnemyObjects.Length;

        // �������� ���������� ��������� � RopeSpawn
        int count = playerObjects.Length;



        // ���������� ���������� ���������
        //if (countEnemy > count)
        //{
        //    Debug.Log("RopeSpawnEnemy ����� ������ ���������." + count.ToString() + countEnemy.ToString());

        //}
        //else if (countEnemy < count)
        //{
        //    Debug.Log("RopeSpawn ����� ������ ���������." + count.ToString() + countEnemy.ToString());
        //}
        //else
        //{
        //    Debug.Log("RopeSpawnEnemy � RopeSpawn ����� ���������� ���������� ���������." + count.ToString() + countEnemy.ToString());
        //}
    }
}
