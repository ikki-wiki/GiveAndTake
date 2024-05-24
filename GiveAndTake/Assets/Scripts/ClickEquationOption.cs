using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ClickEquationOption : MonoBehaviour
{
    public shake shake;
    public AudioSource audioSource;
    public AudioSource CompletedLevel;
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


    public void Finish(GameObject clickedObject)
    {
        if (clickedObject.tag == "Correct")
        {   
            Debug.Log("Correct");
            CompletedLevel.Play();
            if(timeText.IsActive() && pointsText.IsActive())
            {
                Debug.Log(scoreManager.GetScore()+" Scored");
                //corrigir depois quando já se tiver o tal display de sucesso/erro
                //PlayerProfile.currentProfile.score += scoreManager.GetScore();
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
                //corrigir depois quando já se tiver o tal display de sucesso/erro
                //PlayerProfile.currentProfile.score += scoreManager.GetScore();
                darkerBackground.SetActive(true);
                PopUpNoStar.SetActive(true);
                PopUpTechinic.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            Debug.Log("Incorrect");
            shake.StartShake();
            audioSource.Play();
        }
    }
}
