using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject clickedObject;
    public shake shake;
    public AudioSource audioSource;
    public GameObject underline;
    public int loadSceneNumber;

    public void ClickedObject(GameObject clickedObject)
    {
        this.clickedObject = clickedObject;
        underline.SetActive(true);
        underline.transform.position = new Vector3(clickedObject.transform.position.x, clickedObject.transform.position.y - 60, clickedObject.transform.position.z);      
    }

    public void Finish()
    {
        if (clickedObject.tag == "Correct")
        {
            Debug.Log("Correct");
            SceneManager.LoadSceneAsync(loadSceneNumber);
        }
        else
        {
            Debug.Log("Incorrect");
            shake.StartShake();
            audioSource.Play();
            underline.SetActive(false);
        }
    }
}
