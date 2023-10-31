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
        Debug.Log("установилось значение анлок левел ");
        Debug.Log("PlayerPrefs level: " + PlayerPrefs.GetInt("level"));


        if (levelUnLock==3)
        {
            PlayerPrefs.DeleteKey("level"); // —брасываем значение "level" в PlayerPrefs
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log("зашли в 1 фор");
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnLock; i++)
        {
            Debug.Log("зашли в 2 фор");
            buttons[i].interactable = true;
        }

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("level") == buttons.Length)
        {
            PlayerPrefs.DeleteKey("level"); // —брасываем значение "level" в PlayerPrefs
            Debug.Log("PlayerPrefs level сброшен.");
            Debug.Log("PlayerPrefs level: " + PlayerPrefs.GetInt("level"));
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll(); // удал€ю из реестра записи

        Start(); // подгружаю кнопки заново
    }



}