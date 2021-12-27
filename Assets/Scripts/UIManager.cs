using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]

    private GameObject winScreen;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }
    void Update()
    {
        if (GameManager.Instance.gameover)
        {
            gameOverScreen.SetActive(true);
        }
        if (GameManager.Instance.win)
        {
            winScreen.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Next()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
