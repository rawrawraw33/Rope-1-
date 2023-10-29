using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollisionHandlerEnemy : MonoBehaviour
{


    public GameObject Part;
    private List<GameObject> segments = new List<GameObject>();
    bool isFirstSegmentCreated = false;
    public RopeSpawn ropeSpawn;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);

            if (!isFirstSegmentCreated)
            {
                // Создаем новый сегмент веревки
                GameObject newSegment = Instantiate(Part, transform.position, Quaternion.identity);
                GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player1");

                if (playerObjects.Length >= 2)
                {
                    //newsegment is the last element so we need the prelast element 
                    Rigidbody lastSegment = playerObjects[playerObjects.Length - 2].GetComponent<Rigidbody>();
                    CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();

                    if (newSegmentCharacterJoint != null)
                    {
                        newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;
                        // Настроим connectedAnchor по вашим требованиям
                        newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);
                    }
                    newSegmentCharacterJoint.connectedBody = lastSegment;
                    GameObject ParentElement = GameObject.FindGameObjectWithTag("PlayerParent1");
                    newSegmentCharacterJoint.transform.parent = ParentElement.transform;
                    segments.Add(newSegment);
                    isFirstSegmentCreated = true;
                }
            }
            else if (segments.Count > 0)
            {
                // Находим последний сегмент в списке сегментов
                GameObject lastSegment = segments[segments.Count - 1];
                GameObject newSegment = Instantiate(Part, lastSegment.transform.position, Quaternion.identity);

                // Получаем компонент CharacterJoint на новом сегменте
                CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();
                if (newSegmentCharacterJoint != null)
                {
                    // Получаем компонент Rigidbody на последнем сегменте
                    Rigidbody lastSegmentRigidbody = lastSegment.GetComponent<Rigidbody>();
                    newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;
                    // Настроим connectedAnchor по вашим требованиям
                    newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);

                    if (lastSegmentRigidbody != null)
                    {
                        // Устанавливаем свойство connectedBody для CharacterJoint
                        newSegmentCharacterJoint.connectedBody = lastSegmentRigidbody;
                    }
                    segments.Add(newSegment);
                }

                // Присоединяем новый сегмент к предыдущему
                newSegment.GetComponent<CharacterJoint>().connectedBody = lastSegment.GetComponent<Rigidbody>();

                GameObject ParentElement = GameObject.FindGameObjectWithTag("PlayerParent1");
                newSegmentCharacterJoint.transform.parent = ParentElement.transform;
            }
        }





        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player1");
            GameObject[] playerEnemyObjects = GameObject.FindGameObjectsWithTag("Player");
            // Получаем количество элементов в RopeSpawnEnemy
            int countEnemy = playerEnemyObjects.Length;

            // Получаем количество элементов в RopeSpawn
            int count = playerObjects.Length;

            GameObject ParentElement = GameObject.FindGameObjectWithTag("PlayerParent");

            // Переменная для подсчета удаленных элементов
            int destroyedCount = 0;


            //сравниваем количество элементов

            if (countEnemy > count)
            {
                Debug.Log("RopespawnEnemy имеет больше элементов." + count.ToString() + "/" + countEnemy.ToString());
                

            }
            else if (countEnemy < count)
            {
                Debug.Log("RopeSpawn имеет больше элементов." + count.ToString() + countEnemy.ToString());


                // Проходим по всем объектам с тегом "Player1" и уничтожаем их
                foreach (GameObject playerEnemyObject in playerEnemyObjects)
                {
                    Destroy(playerEnemyObject);
                    destroyedCount++;
                }



                // Теперь убедимся, что дочерние объекты Player1 также уничтожены
                foreach (Transform child in ParentElement.transform)
                {
                    if (child.CompareTag("Player"))
                    {
                        Destroy(child.gameObject);
                        destroyedCount++; // Увеличиваем счетчик удаленных объектов

                    }
                }
                Debug.Log("destroyedCount++ = " + destroyedCount.ToString());

                for (int i = 0; i < destroyedCount; i++)
                {
                    GameObject newSegment = Instantiate(Part, transform.position, Quaternion.identity);
                    // Настройте новые элементы, как вам нужно
                    // ...
                    if (segments.Count == 0)

                    {
                        GameObject[] playerObjectsEnemy = GameObject.FindGameObjectsWithTag("Player1");

                        //newsegment is a last element so we need prelast element 
                        Rigidbody lastSegment = playerObjects[playerObjects.Length - 1].GetComponent<Rigidbody>();
                        CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();

                        if (newSegmentCharacterJoint != null)
                        {

                            newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;

                            // Настроим connectedAnchor по вашим требованиям
                            newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);
                        }

                        newSegmentCharacterJoint.connectedBody = lastSegment;
                        GameObject ParentElementEnemy = GameObject.FindGameObjectWithTag("PlayerParent");
                        newSegmentCharacterJoint.transform.parent = ParentElement.transform;

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

                            newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);

                            if (lastSegmentRigidbody != null)
                            {
                                // Устанавливаем свойство connectedBody для CharacterJoint
                                newSegmentCharacterJoint.connectedBody = lastSegmentRigidbody;
                            }

                        }

                        // Присоединяем новый сегмент к предыдущему
                        newSegment.GetComponent<CharacterJoint>().connectedBody = lastSegment.GetComponent<Rigidbody>();

                        GameObject ParentElementEnemy = GameObject.FindGameObjectWithTag("PlayerParent");
                        newSegmentCharacterJoint.transform.parent = ParentElement.transform;
                    }

                    segments.Add(newSegment);
                }


            }
            else
            {
                Debug.Log("ropespawnenemy и ropespawn имеют одинаковое количество элементов." + count.ToString() + countEnemy.ToString());
            }



        }


    }
}

