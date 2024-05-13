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
    AudioSource audioSource;


    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        valorAtual = itemSlot.slotValue + itemSlot2.slotValue;
        if (valorAtual == cartaoValor)
        {
            audioSource.Play();
        }
    }

    
}
