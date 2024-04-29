using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject clickedObject;
    public shake shake;
    public AudioSource audioSource;

    public void ClickedObject(GameObject clickedObject)
    {
        this.clickedObject = clickedObject;
    }

    public void Finish()
    {
        if (clickedObject.tag == "Correct")
        {
            Debug.Log("Correct");
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            Debug.Log("Incorrect");
            shake.StartShake();
            audioSource.Play();
        }
    }
}
