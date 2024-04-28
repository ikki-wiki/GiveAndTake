using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {

    }

    public void CliqueEvento()
    {
        if (gameObject.tag == "Wrong")
        {
            Debug.Log("Wrong option");
        }
        else
        {
            Debug.Log("Right option");
        }
    }
}
