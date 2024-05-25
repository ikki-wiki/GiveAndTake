using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleVerification : MonoBehaviour
{
    public ItemSlot topSlot; // Reference to the top slot of the pyramid
    public shake shake;
    public AudioSource audioSource;
    public AudioSource CompletedLevel;
    public ScoreManager scoreManager;
    private int counter = 0;
    public GameObject PopUpStars;
    public GameObject PopUpNoStar;
    public Text PointsEarned;
    public GameObject PopUpTechinic;
    public GameObject Star;
    public GameObject Star2;
    public GameObject Star3;
    public Text timeText;
    public Text pointsText;
    public GameObject darkerBackground;
    public GameObject Show3Stars;
    public GameObject Show2Stars;
    public GameObject Show1Star;

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
            CompletedLevel.Play();
            if(timeText.IsActive() && pointsText.IsActive())
            {
                Debug.Log(scoreManager.GetScore()+" Scored");
                PlayerProfile.currentProfile.score += scoreManager.GetScore();
                //se a star3 tiver ativa, ativa o popup3stars, se a star2 tiver ativa, ativa o popup2stars, se a star tiver ativa, ativa o popup1star
                if (Star3.activeSelf)
                {            
                    //buscar o PointsEarned e colocar o valor do scoreManager.GetScore() nele, junto com uma frase
                    PointsEarned.text = "Conseguiste ganhar um total de " + scoreManager.GetScore() + " pontos!";
                    darkerBackground.SetActive(true);
                    PopUpStars.SetActive(true);
                    PopUpTechinic.SetActive(true);
                    Show3Stars.SetActive(true);
                    Time.timeScale = 0;
                }
                else if (Star2.activeSelf)
                {
                    PointsEarned.text = "Conseguiste ganhar um total de " + scoreManager.GetScore() + " pontos!";
                    darkerBackground.SetActive(true);
                    PopUpStars.SetActive(true);
                    PopUpTechinic.SetActive(true);
                    Show2Stars.SetActive(true);
                    Time.timeScale = 0;
                }
                else if (Star.activeSelf)
                {
                    PointsEarned.text = "Conseguiste ganhar um total de " + scoreManager.GetScore() + " pontos!";
                    darkerBackground.SetActive(true);
                    PopUpStars.SetActive(true);
                    PopUpTechinic.SetActive(true);
                    Show1Star.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            else
            {
                darkerBackground.SetActive(true);
                PopUpNoStar.SetActive(true);
                PopUpTechinic.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            Debug.Log("Puzzle not solved!");
            shake.StartShake();
            audioSource.Play();
        }
    }
}

