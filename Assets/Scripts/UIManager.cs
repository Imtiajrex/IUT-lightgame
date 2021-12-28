using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Slider darknessSlider;
    [SerializeField] private ParticleSystem darknessSliderParticles;
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

        updateSlider((PlayerManager.Instance.darknessMeter) / 100);

        if (PlayerManager.Instance.darknessMeter <= 35f && darknessSliderParticles.isPlaying)
        {
            darknessSliderParticles.Stop();
        }
        else
        {
            if (!darknessSliderParticles.isPlaying)
            {
                darknessSliderParticles.Play();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void updateSlider(float progress)
    {
        darknessSlider.value = progress;
    }
}
