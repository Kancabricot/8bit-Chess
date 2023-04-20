using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class S_Room : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayOfEnnemy;

    public void SpawnEnnemys(Vector2 pos)
    {
        int rand = Random.Range(0, arrayOfEnnemy.Length);

        GameObject room = Instantiate(arrayOfEnnemy[rand], pos, Quaternion.identity);
    }

    
    void Update()
    {
        
    }
}
