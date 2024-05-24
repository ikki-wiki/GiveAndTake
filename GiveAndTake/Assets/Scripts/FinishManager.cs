 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    public GameObject FinishMenuWin;
    public GameObject FinishMenuLose;
    public Button AdvanceButton;
    public Button RestartButtonWin;
    public Button RestartButtonLose;
    public Button QuitButtonWin;
    public Button QuitButtonLose;
    public string sceneToLoad;

    void Start()
    {
        AdvanceButton.onClick.AddListener(AdvanceLevel);
        RestartButtonWin.onClick.AddListener(RestartGame);
        QuitButtonWin.onClick.AddListener(QuitGame);
        RestartButtonLose.onClick.AddListener(RestartGame);
        QuitButtonLose.onClick.AddListener(QuitGame);

        FinishMenuWin.SetActive(false);
        FinishMenuLose.SetActive(false);

        Time.timeScale = 1;
    }

    public void AdvanceLevel()
    {
        FinishMenuWin.SetActive(false);
        FinishMenuLose.SetActive(false);
        Time.timeScale = 1;
        PlaySound(AdvanceButton);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void RestartGame()
    {
        if (FinishMenuWin.activeSelf)
        {
            PlaySound(RestartButtonWin);
        }
        else
        {
            PlaySound(RestartButtonLose);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        if (FinishMenuWin.activeSelf)
        {
            PlaySound(QuitButtonWin);
        }
        else
        {
            PlaySound(QuitButtonLose);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySound(Button button)
    {
        AudioSource audioToPlay = button.GetComponent<AudioSource>();
        audioToPlay.Play();
    }
}
