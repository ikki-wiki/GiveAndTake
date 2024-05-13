using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaoTutorial : MonoBehaviour
{
    public ItemSlot itemSlot;
    public ItemSlot itemSlot2;
    public float cartaoValor;
    private float valorAtual;
    public AudioSource audioSource;
    private bool toPlay = false;

    // Update is called once per frame
    void Update()
    {
        valorAtual = itemSlot.slotValue + itemSlot2.slotValue;
        if (valorAtual == cartaoValor && !toPlay)
        {
            audioSource.Play();
            toPlay = true;
        }
        else if (valorAtual != cartaoValor)
        {
            toPlay = false;
        }
    }  
}
