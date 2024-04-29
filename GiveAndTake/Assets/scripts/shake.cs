using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    public float shakeDuration = 1;
    public bool startShake = false;
    public AnimationCurve curve;


    // Update is called once per frame
    void Update()
    {
        if (startShake)
        {
            StartCoroutine(Shake());
            startShake = false;
        }


    }

    public void StartShake()
    {
        startShake = true;
    }

    public IEnumerator Shake()
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
     
            float strength = curve.Evaluate(elapsed / shakeDuration);
            transform.position = originalPos + Random.insideUnitSphere * strength * 9;

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}
