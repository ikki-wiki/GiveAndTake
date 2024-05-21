using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartao : MonoBehaviour
{
    public ItemSlot itemSlot;
    public ItemSlot itemSlot2;
    public ItemSlot itemSlot3;
    public float cartaoValor;
    private float valorAtual;
    AudioSource audioSource;
    ScoreManager2Game scoreManager2Game;


    // Start is called before the first frame update
    void Awake()
    {
        scoreManager2Game = FindObjectOfType<ScoreManager2Game>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemSlot3 != null)
        {
            valorAtual = itemSlot.slotValue + itemSlot2.slotValue + itemSlot3.slotValue;
        }
        else { 
            valorAtual = itemSlot.slotValue + itemSlot2.slotValue;
        }
        if (valorAtual == cartaoValor)
        {
            Debug.Log("valor correto");
            audioSource.Play();
            if (scoreManager2Game.cardsPlayer1Direita.Contains(this))
            {
                scoreManager2Game.AddScorePlayer1();
                scoreManager2Game.cardsPlayer1Direita.Remove(this);
                scoreManager2Game.showCards1Direita();
            }
            else if (scoreManager2Game.cardsPlayer1Esquerda.Contains(this))
            {
                scoreManager2Game.AddScorePlayer1();
                scoreManager2Game.cardsPlayer1Esquerda.Remove(this);
                scoreManager2Game.showCards1Esquerda();
            }
            else if (scoreManager2Game.cardsPlayer2Esquerda.Contains(this))
            {
                scoreManager2Game.AddScorePlayer2();
                scoreManager2Game.cardsPlayer2Esquerda.Remove(this);
                scoreManager2Game.showCards2Esquerda();
            }
            else if(scoreManager2Game.cardsPlayer2Direita.Contains(this))
            {
                scoreManager2Game.AddScorePlayer2();
                scoreManager2Game.cardsPlayer2Direita.Remove(this);
                scoreManager2Game.showCards2Direita();
            }
            
            Destroy(gameObject);
            Destroy(itemSlot.gameObject);
            Destroy(itemSlot2.gameObject);
            if (itemSlot3 != null) Destroy(itemSlot3.gameObject);
        }
    }

    
}
