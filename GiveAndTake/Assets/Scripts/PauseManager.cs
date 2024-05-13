 using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public Button ResumeButton;
    public Button RestartButton;
    public Button QuitButton;
    public Button CloseButton;

    public GameObject MinigameCanvas;
    public GameObject PauseCanvas;

    void Start()
    {
        ResumeButton.onClick.AddListener(ResumeGame);
        RestartButton.onClick.AddListener(RestartGame);
        QuitButton.onClick.AddListener(QuitGame);
        CloseButton.onClick.AddListener(ResumeGame);

        PauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        VerifyKeyPressed();
    }

    public void VerifyKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                MinigameCanvas.SetActive(true);
                PauseMenu.SetActive(false);
                PauseCanvas.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                MinigameCanvas.SetActive(false);
                PauseMenu.SetActive(true);
                PauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame()
    {
        MinigameCanvas.SetActive(true);
        PauseMenu.SetActive(false);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        PlaySound(ResumeButton);
    }

    public void RestartGame()
    {
        PlaySound(RestartButton);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        PlaySound(QuitButton);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySound(Button button)
    {
        AudioSource audioToPlay = button.GetComponent<AudioSource>();
        audioToPlay.Play();
    }

}
