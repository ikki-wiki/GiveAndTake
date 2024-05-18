using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEquation : MonoBehaviour
{
    //tenho 4 lugares definidos como o empty object para dar spawn, e tenho 4 prefabs para spawnar de forma aleatoria em cada lugar e nao pode repetir o prefab colocado, e quero que o prefab tenha uma escala de 55 no x e y
    
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
            newPrefab.GetComponent<SpriteRenderer>().sortingOrder = 1;
            newPrefab.transform.localScale = new Vector3(55, 55, 1);
            newPrefab.SetActive(true);
            List<GameObject> temp = new List<GameObject>(prefabs);
            temp.RemoveAt(randomIndex);
            prefabs = temp.ToArray();
        }
    }
}
