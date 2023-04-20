using UnityEngine;

public class S_Room : MonoBehaviour
{

    [SerializeField] private GameObject[] arrayOfSpawner;

    public void SpawnSpawner(Vector2 pos)
    {
        
        GameObject currentSpawner = arrayOfSpawner[Random.Range(0, arrayOfSpawner.Length)];
        Instantiate(currentSpawner, pos, transform.rotation);
        FindObjectOfType<S_Spawner>().SpawnEnnemy();
        Debug.Log("spawn current spawner");
    }
}
