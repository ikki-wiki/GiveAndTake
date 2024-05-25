using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEquation : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomPrefab();    
    }

    private void SpawnRandomPrefab()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, prefabs.Length);
            GameObject randomPrefab = prefabs[randomIndex];
            GameObject spawnPoint = spawnPoints[i];
            GameObject newPrefab = Instantiate(randomPrefab, spawnPoint.transform.position, Quaternion.identity);
            newPrefab.transform.localScale = new Vector3(4, 1, 1);
            newPrefab.SetActive(true);
            newPrefab.transform.SetParent(spawnPoint.transform);
            List<GameObject> temp = new List<GameObject>(prefabs);
            temp.RemoveAt(randomIndex);
            prefabs = temp.ToArray();
        }
    }
}
