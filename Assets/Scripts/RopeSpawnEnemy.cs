using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawnEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1, 50)]
    int length = 6;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    void Start()
    {
        spawn = true;
    }

    void Update()
    {
        if (reset)
        {
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject tmp in playerObjects)
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length);
        GameObject previousSegment = null; // Переменная для хранения предыдущего сегмента

        for (int x = 0; x < count; x++)
        {
            GameObject tmp;
            tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            tmp.name = parentObject.transform.childCount.ToString();




            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    
                }

                EnemyController script = tmp.AddComponent<EnemyController>();
                RopeCollisionHandlerEnemy collisionHandlerEnemy = tmp.AddComponent<RopeCollisionHandlerEnemy>();
                collisionHandlerEnemy.Part = partPrefab;

                // Проверяем, есть ли скрипт PlayerController
                if (collisionHandlerEnemy != null)
                {
                    // Устанавливаем rotation в ноль
                    tmp.transform.rotation = Quaternion.identity;
                }

                // Сохраняем первый сегмент в переменной previousSegment
                previousSegment = tmp;
            }
            else
            {
                if (previousSegment != null)
                {
                    tmp.GetComponent<CharacterJoint>().connectedBody = previousSegment.GetComponent<Rigidbody>();
                    previousSegment = tmp; // Обновляем previousSegment на текущий сегмент
                }
            }
        }
        if (snapLast)
        {
            if (previousSegment != null)
            {
                parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    // В скрипте RopeSpawnEnemy
    public int GetSegmentCount()
    {
        // Возвращаем количество дочерних объектов (сегментов веревки) у parentObject
        return parentObject.transform.childCount;
    }



}
