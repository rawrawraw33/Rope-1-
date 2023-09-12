using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollisionHandler : MonoBehaviour
{


    public GameObject Part;
    private List<GameObject> segments = new List<GameObject>();

    public RopeSpawn ropeSpawn;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Food"))
        {
            // Уничтожаем объект "Food"
            Destroy(collision.gameObject);

            // Создаем новый сегмент веревки
            GameObject newSegment = Instantiate(Part, transform.position, Quaternion.identity);
            if (segments.Count == 0)

            {
                GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

                //newsegment is a last element so we need prelast element 
                Rigidbody lastSegment = playerObjects[playerObjects.Length - 2].GetComponent<Rigidbody>();
                CharacterJoint newSegmentCharacterJoint = newSegment.GetComponent<CharacterJoint>();

                if (newSegmentCharacterJoint != null)
                {

                    newSegmentCharacterJoint.autoConfigureConnectedAnchor = false;

                    // Настроим connectedAnchor по вашим требованиям
                    // Например:
                    newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);
                }

                newSegmentCharacterJoint.connectedBody = lastSegment;
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
                    // Например:
                    newSegmentCharacterJoint.connectedAnchor = new Vector3(0.0f, -1.0f, 0.0f);

                    if (lastSegmentRigidbody != null)
                    {
                        // Устанавливаем свойство connectedBody для CharacterJoint
                        newSegmentCharacterJoint.connectedBody = lastSegmentRigidbody;
                    }
                    else
                    {
                        // Если компонент Rigidbody отсутствует на последнем сегменте, нужно обработать этот случай
                        // Можно вывести отладочное сообщение или предпринять другие действия по вашему усмотрению
                    }
                }
                else
                {
                    // Если компонент CharacterJoint отсутствует на новом сегменте, нужно обработать этот случай
                    // Можно вывести отладочное сообщение или предпринять другие действия по вашему усмотрению
                }

                // Присоединяем новый сегмент к предыдущему
                newSegment.GetComponent<CharacterJoint>().connectedBody = lastSegment.GetComponent<Rigidbody>();
            }

            segments.Add(newSegment);
        }
    }
}




