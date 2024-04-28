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
            Debug.Log("puzzle not solved");
        }
    }

    private bool VerifyTriangle()
    {
        if(slotBlue1 == null || slotBlue2 == null || slotBlue3 == null || slotRed1 == null || slotRed2 == null || slotRed3 == null)
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
