using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayOfEnnemy;
    [SerializeField] private GameObject[] arrayOfSpawnPoint;

    public void SpawnEnnemy()
    {
        int nbEnnemy = Random.Range(1, arrayOfSpawnPoint.Length);

        arrayOfSpawnPoint = GameObject.FindGameObjectsWithTag("Spawn");
        
        while (nbEnnemy > 0) 
        {
            int rand = Random.Range(0, arrayOfEnnemy.Length);
            int randSpawnPoint = Random.Range(0, arrayOfSpawnPoint.Length);
            GameObject currentSpawnPoint = arrayOfSpawnPoint[randSpawnPoint];
            Instantiate(arrayOfEnnemy[rand], currentSpawnPoint.transform.position, transform.rotation);
            nbEnnemy--;
            Destroy(currentSpawnPoint);
            Debug.Log("spawn ennemy");
        }

        Debug.Log("destroy himself");
        Destroy(gameObject);
    }
}
