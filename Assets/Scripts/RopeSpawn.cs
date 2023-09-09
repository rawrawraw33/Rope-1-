using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab, parentObject;
    
    [SerializeField]
    [Range(1, 1000)]
    int length = 5;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    void Start()
    {
        // Устанавливаем spawn в true при старте игры, чтобы создать веревку из одной части
        spawn = true;
        length = 5;
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
        for (int x = 0; x < count; x++)
        {
            GameObject tmp;
            tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            tmp.name = parentObject.transform.childCount.ToString();
            
            // Добавить скрипт RopeCollisionHandler только к первому элементу
            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    PlayerController script = tmp.AddComponent<PlayerController>();
                }
                
                PlayerController moveScript = tmp.AddComponent<PlayerController>();
                moveScript.moveSpeed = 5.0f; // Настройте скорость движения по вашему усмотрению

                // Добавляем скрипт RopeCollisionHandler к первому элементу
                RopeCollisionHandler collisionHandler = tmp.AddComponent<RopeCollisionHandler>();
                collisionHandler.Part = partPrefab; // Устанавливаем префаб сегмента в скрипте RopeCollisionHandler
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
        if (snapLast)
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}