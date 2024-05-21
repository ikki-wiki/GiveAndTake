using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleVerification : MonoBehaviour
{
    public ItemSlot topSlot; // Reference to the top slot of the pyramid
    public shake shake;
    public AudioSource audioSource;
    public ScoreManager scoreManager;
    private int counter = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Method to check if all slots are filled
    public void CheckAllSlotsFilled()
    {
        if (AllSlotsFilled(topSlot))
        {
            VerifyPuzzle();
        }
    }

    // Recursive method to check if all slots are filled
    private bool AllSlotsFilled(ItemSlot slot)
    {
        if (slot.slotValue == 0)
        {
            return false;
        }

        foreach (ItemSlot childSlot in slot.childSlots)
        {
            if (!AllSlotsFilled(childSlot))
            {
                return false;
            }
        }
        return true;
    }

    // Recursive function to verify the pyramid structure
    private bool VerifyPyramidStructure(ItemSlot slot)
    {   
        if (slot.slotValue == 0)
        {
            Debug.Log($"Slot {slot.name} is empty.");
            return false;
        }

        float expectedValue = slot.slotValue;
        Debug.Log($"Slot {slot.name} expected value: {expectedValue}");

        float sum = 0;
        foreach (ItemSlot childSlot in slot.childSlots) 
        {
            if (childSlot != null)
            {
                float childValue = childSlot.slotValue;
                Debug.Log($"Child slot {childSlot.name} value: {childValue}");
                sum += childValue; 
            }
        }

        if (slot.childSlots.Count == 0)
        {
            sum = expectedValue; 
        }

        Debug.Log($"Slot {slot.name} sum of child values: {sum}, expected: {expectedValue}");

        if (sum != expectedValue) 
        {
            Debug.Log($"Incorrect placement in slot {slot.name}!");
            return false;
        }

        foreach (ItemSlot childSlot in slot.childSlots)
        {
            if (!VerifyPyramidStructure(childSlot))
            {
                return false;
            }
        }

        return true;
    }

    public void VerifyPuzzle()
    {
        bool isCorrect = VerifyPyramidStructure(topSlot);
        if (isCorrect)
        {
            Debug.Log("Puzzle solved!");
            PlayerProfile.currentProfile.score += scoreManager.GetScore();
            SceneManager.LoadSceneAsync(7);
        }
        else
        {
            Debug.Log("Puzzle not solved!");
            shake.StartShake();
            audioSource.Play();
        }
    }
}

