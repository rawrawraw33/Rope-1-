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
        levelUnLock = PlayerPrefs.GetInt("level", 1);
        Debug.Log("установилось значение анлок левел ");
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
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }



}