using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrianglePuzzleVerify : MonoBehaviour
{
    public ItemSlot slotBlue1;
    public ItemSlot slotBlue2;
    public ItemSlot slotBlue3;

    public ItemSlot slotRed1;
    public ItemSlot slotRed2;
    public ItemSlot slotRed3;

    AudioSource audioSource;

    public shake shake;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public void VerifyPuzzle()
    {
        bool isCorrect = VerifyTriangle();
        if (isCorrect)
        {
            // Puzzle solved
            Debug.Log("Puzzle solved!");
            SceneManager.LoadSceneAsync(1);
            // You can add more feedback here if needed
        }
        else
        {
            audioSource.Play();
            shake.StartShake();
            Debug.Log("puzzle not solved");
        }
    }

    private bool VerifyTriangle()
    {
        if(slotBlue1.slotValue == 0 || slotBlue2.slotValue == 0 || slotBlue3.slotValue == 0 || slotRed1.slotValue == 0 || slotRed2.slotValue == 0 || slotRed3.slotValue == 0)
        {

            return false;
        }

        if((slotBlue1.slotValue == slotBlue2.slotValue && slotBlue2.slotValue ==  slotBlue3.slotValue && slotBlue1.slotValue == slotBlue3.slotValue) && ( slotRed1.slotValue == slotRed2.slotValue && slotRed2.slotValue == slotRed3.slotValue && slotRed1.slotValue == slotRed3.slotValue) )
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
