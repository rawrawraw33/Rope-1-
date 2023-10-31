using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int levelUnLock;
    public Button[] buttons;

    void Start()
    {

        Debug.Log("PlayerPrefs level: " + PlayerPrefs.GetInt("level"));
        levelUnLock = PlayerPrefs.GetInt("level", 1);
        Debug.Log("������������ �������� ����� ����� ");
        Debug.Log("PlayerPrefs level: " + PlayerPrefs.GetInt("level"));


        if (levelUnLock==3)
        {
            PlayerPrefs.DeleteKey("level"); // ���������� �������� "level" � PlayerPrefs
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log("����� � 1 ���");
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnLock; i++)
        {
            Debug.Log("����� � 2 ���");
            buttons[i].interactable = true;
        }

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("level") == buttons.Length)
        {
            PlayerPrefs.DeleteKey("level"); // ���������� �������� "level" � PlayerPrefs
            Debug.Log("PlayerPrefs level �������.");
            Debug.Log("PlayerPrefs level: " + PlayerPrefs.GetInt("level"));
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll(); // ������ �� ������� ������

        Start(); // ��������� ������ ������
    }



}