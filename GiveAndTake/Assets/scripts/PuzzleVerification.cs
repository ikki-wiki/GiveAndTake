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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Recursive function to verify the pyramid structure
    private bool VerifyPyramidStructure(ItemSlot slot)
    {
        // Base case: if the slot is null, return true
        if (slot.slotValue == 0)
        {
            return false;
        }

        // Get the expected value for this slot
        float expectedValue = slot.slotValue;

        // Check if the sum of coins in child slots matches the expected value
        float sum = 0;
        foreach (ItemSlot childSlot in slot.childSlots)
        {
            if (childSlot != null )
            {
                sum += childSlot.CoinValue();
            }
        }

        if(slot.childSlots.Count == 0)
        {
            sum = expectedValue;
        }


        if (sum != expectedValue)
        {
            // Incorrect placement
            Debug.Log("Incorrect placement!");
            return false;
        }

        // Recursively verify child slots
        foreach (ItemSlot childSlot in slot.childSlots)
        {
            if (!VerifyPyramidStructure(childSlot))
            {
                return false;
            }
        }

        // All child slots verified
        return true;
    }

    // Method to start the verification process
    public void VerifyPuzzle()
    {
        bool isCorrect = VerifyPyramidStructure(topSlot);
        if (isCorrect)
        {
            // Puzzle solved
            Debug.Log("Puzzle solved!");
            PlayerProfile.currentProfile.score += scoreManager.GetScore();
            SceneManager.LoadSceneAsync(7);
            // You can add more feedback here if needed
        }
        else
        {
            // Puzzle not solved
            Debug.Log("Puzzle not solved!");
            shake.StartShake();
            audioSource.Play();
        }
    }
}
