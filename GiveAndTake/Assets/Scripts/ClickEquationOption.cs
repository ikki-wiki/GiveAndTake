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

    public void Finish(GameObject clickedObject)
    {
        if (clickedObject.tag == "Correct")
        {
            Debug.Log("Correct");
            //corrigir depois quando já se tiver o tal display de sucesso/erro
            PlayerProfile.currentProfile.score += scoreManager.GetScore();
            SceneManager.LoadSceneAsync(loadSceneNumber);
        }
        else
        {
            Debug.Log("Incorrect");
            shake.StartShake();
            audioSource.Play();
        }
    }
}
