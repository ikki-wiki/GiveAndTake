using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2Game : MonoBehaviour
{
    int scorePlayer1 = 0;
    int scorePlayer2 = 0;
    public Text scoreTextPlayer1;
    public Text scoreTextPlayer2;
    public Text scoreTextWin1;
    public Text scoreTextWin2;
    public Text scoreTextLose1;
    public Text scoreTextLose2;
    public Text scoreTextDraw1;
    public Text scoreTextDraw2;
    public GameObject popUpWin1;
    public GameObject popUpWin2;
    public GameObject popUpLose1;
    public GameObject popUpLose2;
    public GameObject popUpDraw1;
    public GameObject popUpDraw2;
    int time = 120;
    public Text Timer1;
    public Text Timer2;
    public List<Cartao> cardsPlayer1Direita;
    public List<Cartao> cardsPlayer1Esquerda;
    public List<Cartao> cardsPlayer2Direita;
    public List<Cartao> cardsPlayer2Esquerda;
    public GameObject background;
    public AudioSource audioSource;
    public GameObject popUpTecnico;
    public GameObject bacgroundTecnico;

    private void Start()
    {
        showCards1Direita();

        showCards1Esquerda();

        showCards2Direita();

        showCards2Esquerda();

        InvokeRepeating("UpdateTimer", 1f, 1f);

        audioSource = GetComponent<AudioSource>();
    }

    public void showCards1Direita()
    {
        int randomIndex = Random.Range(0, cardsPlayer1Direita.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer1Direita[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }
    public void showCards1Esquerda()
    {
        int randomIndex = Random.Range(0, cardsPlayer1Esquerda.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer1Esquerda[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    public void showCards2Direita()
    {
        int randomIndex = Random.Range(0, cardsPlayer2Direita.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer2Direita[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);
    }

    public void showCards2Esquerda()
    {
        int randomIndex = Random.Range(0, cardsPlayer2Esquerda.Count);

        // Acessa o objeto na lista usando o índice aleatório.
        Cartao objectToToggle = cardsPlayer2Esquerda[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    private void UpdateTimer()
    {
        // Decrementa o tempo restante.
        time--;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        
        // Atualiza os textos dos temporizadores.             
        Timer1.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //Timer1.text = time.ToString() + " segundos";
        //Timer2.text = time.ToString() + " segundos";

        // Se o tempo acabou, voc� pode adicionar aqui a l�gica para terminar o jogo.
        if (time <= 0)
        {
            // Por exemplo:
            Time.timeScale = 0; // Pausa o jogo.

            audioSource.Play();

            background.SetActive(true);

            if (scorePlayer1 > scorePlayer2)
            {
                scoreTextWin1.text = "A tua equipa fez "+ scorePlayer1.ToString() + " pontos";
                popUpWin1.gameObject.SetActive(true);
                scoreTextLose2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";
                popUpLose2.gameObject.SetActive(true);

            }
            else if (scorePlayer1 < scorePlayer2)
            {
                scoreTextWin2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";
                popUpWin2.gameObject.SetActive(true);
                scoreTextLose1.text = "A tua equipa fez " + scorePlayer1.ToString() + " pontos";
                popUpLose1.gameObject.SetActive(true);

            }
            else
            {
                scoreTextDraw1.text = "A tua equipa fez " + scorePlayer1.ToString() + " pontos";
                popUpDraw1.gameObject.SetActive(true);
                scoreTextDraw2.text = "A tua equipa fez " + scorePlayer2.ToString() + " pontos";
                popUpDraw2.gameObject.SetActive(true);
            }

            bacgroundTecnico.SetActive(true);
            popUpTecnico.SetActive(true);


        }
    }


    public void AddScorePlayer1()
    {
        scorePlayer1++;
        scoreTextPlayer1.text = scorePlayer1.ToString() + " pontos";
    }

    public void AddScorePlayer2()
    {
        scorePlayer2++;
        scoreTextPlayer2.text = scorePlayer2.ToString() + " pontos";
    }
}
