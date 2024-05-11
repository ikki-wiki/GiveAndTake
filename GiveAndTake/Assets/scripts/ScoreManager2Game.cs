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
    int time = 120;
    public Text Timer1;
    public Text Timer2;
    public List<Cartao> cardsPlayer1;
    public List<Cartao> cardsPlayer2;

    private void Start()
    {
        // Chama o m�todo UpdateTimer a cada segundo, ap�s 1 segundo de delay.
        InvokeRepeating("UpdateTimer", 1f, 1f);
        InvokeRepeating("showCards1", 0f, 10f);
        InvokeRepeating("showCards2", 0f, 10f);
    }

    private void showCards1()
    {
        int randomIndex = Random.Range(0, cardsPlayer1.Count);

        // Acessa o objeto na lista usando o �ndice aleat�rio.
        Cartao objectToToggle = cardsPlayer1[randomIndex];

        // Ativa ou desativa o objeto selecionado.
        objectToToggle.gameObject.SetActive(!objectToToggle.gameObject.activeSelf);
        objectToToggle.itemSlot.gameObject.SetActive(!objectToToggle.itemSlot.gameObject.activeSelf);
        objectToToggle.itemSlot2.gameObject.SetActive(!objectToToggle.itemSlot2.gameObject.activeSelf);
        if (objectToToggle.itemSlot3 != null) objectToToggle.itemSlot3.gameObject.SetActive(!objectToToggle.itemSlot3.gameObject.activeSelf);

    }

    private void showCards2()
    {
        int randomIndex = Random.Range(0, cardsPlayer2.Count);

        // Acessa o objeto na lista usando o �ndice aleat�rio.
        Cartao objectToToggle = cardsPlayer2[randomIndex];

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
            // Time.timeScale = 0; // Pausa o jogo.
        }
    }


    public void AddScorePlayer1()
    {
        scorePlayer1++;
        scoreTextPlayer1.text = scorePlayer1.ToString();
    }

    public void AddScorePlayer2()
    {
        scorePlayer2++;
        scoreTextPlayer2.text = scorePlayer2.ToString();
    }
}
