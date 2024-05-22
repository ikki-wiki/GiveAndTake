using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public shake shake;
    public AudioSource audioSource;
    public int loadSceneNumber;
    public ScoreManager scoreManager;
    public GameObject PopUp3Stars;
    public GameObject PopUp2Stars;
    public GameObject PopUp1Star;
    public GameObject PopUpTechinic;
    public GameObject Star;
    public GameObject Star2;
    public GameObject Star3;


    public void Finish(GameObject clickedObject)
    {
        if (clickedObject.tag == "Correct")
        {
            Debug.Log("Correct");
            //corrigir depois quando já se tiver o tal display de sucesso/erro
            PlayerProfile.currentProfile.score += scoreManager.GetScore();
            //se a star3 tiver ativa, ativa o popup3stars, se a star2 tiver ativa, ativa o popup2stars, se a star tiver ativa, ativa o popup1star
            if (Star3.activeSelf)
            {
                //Time.timeScale = 0;
                PopUp3Stars.SetActive(true);
                PopUpTechinic.SetActive(true);
            }
            else if (Star2.activeSelf)
            {
                PopUp2Stars.SetActive(true);
                PopUpTechinic.SetActive(true);
            }
            else if (Star.activeSelf)
            {
                PopUp1Star.SetActive(true);
                PopUpTechinic.SetActive(true);
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
