using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodGenerator : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjects = 20;
    public Vector2 spawnArea = new Vector2(10f, 10f);
    public Vector2 spawnRangeX = new Vector2(-5f, 5f); // Диапазон координат X
    public Vector2 spawnRangeZ = new Vector2(-5f, 5f); // Диапазон координат Z

    void Start()
    {
        GenerateObjects();
    }

    void GenerateObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = Random.Range(spawnRangeX.x, spawnRangeX.y);
            float z = Random.Range(spawnRangeZ.x, spawnRangeZ.y);

            Vector3 spawnPosition = new Vector3(x, 0.12f, z);

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }
       private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // Выберите желаемый цвет границ
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea.x, 0.1f, spawnArea.y));
    }
    
}
