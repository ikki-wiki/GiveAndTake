using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class TrianglePuzzleVerify : MonoBehaviour
{
    public ItemSlot slotBlue1;
    public ItemSlot slotBlue2;
    public ItemSlot slotBlue3;

    public ItemSlot slotRed1;
    public ItemSlot slotRed2;
    public ItemSlot slotRed3;
    public AudioSource audioSource;
    public AudioSource CompletedLevel;
    public shake shake;
    public ScoreManager scoreManager;
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

    private void Start()
    {
        // Assign this script as the puzzle verifier for each slot
        slotBlue1.trianglePuzzleVerifier = this;
        slotBlue2.trianglePuzzleVerifier = this;
        slotBlue3.trianglePuzzleVerifier = this;
        slotRed1.trianglePuzzleVerifier = this;
        slotRed2.trianglePuzzleVerifier = this;
        slotRed3.trianglePuzzleVerifier = this;
    }

    // Method to check if all slots are filled
    public void CheckAllSlotsFilled()
    {
        if (AllSlotsFilled())
        {
            VerifyPuzzle();
        }
    }

    // Method to check if all slots have coins
    private bool AllSlotsFilled()
    {
        return slotBlue1.slotValue != 0 &&
               slotBlue2.slotValue != 0 &&
               slotBlue3.slotValue != 0 &&
               slotRed1.slotValue != 0 &&
               slotRed2.slotValue != 0 &&
               slotRed3.slotValue != 0;
    }

    public void VerifyPuzzle()
    {
        bool isCorrect = VerifyTriangle();
        if (isCorrect)
        {
            // Puzzle solved
            Debug.Log("Puzzle solved!");
            if(timeText.IsActive() && pointsText.IsActive())
            {
                Debug.Log(scoreManager.GetScore()+" Scored");
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
            audioSource.Play();
            shake.StartShake();
            Debug.Log("puzzle not solved");
        }
    }

    private bool VerifyTriangle()
    {
        float sideValue = slotRed1.slotValue + slotBlue1.slotValue + slotRed2.slotValue;
        float sideValue2 = slotRed2.slotValue + slotBlue2.slotValue + slotRed3.slotValue;
        float sideValue3 = slotRed3.slotValue + slotBlue3.slotValue + slotRed1.slotValue;

        if (slotBlue1.slotValue == 0 || slotBlue2.slotValue == 0 || slotBlue3.slotValue == 0 || slotRed1.slotValue == 0 || slotRed2.slotValue == 0 || slotRed3.slotValue == 0)
        {
            return false;
        }

        if (sideValue2 == sideValue)
        {
            if (sideValue3 == sideValue)
            {
                PlayerProfile.currentProfile.score += scoreManager.GetScore();
                CompletedLevel.Play();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
