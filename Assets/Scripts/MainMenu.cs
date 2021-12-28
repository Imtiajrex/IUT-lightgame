using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public void StartGame()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            int activeLevel = PlayerPrefs.GetInt("Level");
            if (activeLevel < SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(activeLevel + 1);
            else
            {
                SceneManager.LoadScene(activeLevel);
            }
        }
        else
        {

            SceneManager.LoadScene(1);
        }
    }
    public void ToggleLevelPanel()
    {
        if (!LevelPanel.gameObject.activeSelf)
            LevelPanel.gameObject.SetActive(true);
        else
            LevelPanel.gameObject.SetActive(false);
    }
    public void ChooseLevel(int levelIndex)
    {
        if (levelIndex == 1) SceneManager.LoadScene(levelIndex);
        if (levelIndex <= PlayerPrefs.GetInt("Level") + 1)
            SceneManager.LoadScene(levelIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
