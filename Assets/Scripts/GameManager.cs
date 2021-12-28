using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool playing = false;
    public bool win = false;
    public bool gameover = false;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void GameOver()
    {
        gameover = true;
    }
    public void Finish()
    {
        win = true;
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Finished!");
    }
}
