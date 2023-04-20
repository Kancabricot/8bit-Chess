using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class S_DungeonGen : MonoBehaviour
{
    [SerializeField] private Vector2 playerPosition = Vector2.zero;
    [SerializeField] private GameObject square;
    [SerializeField] private List<GameObject> Rooms = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                
                GameObject Room = Instantiate(square, new Vector2(i, j), Quaternion.identity);
                Room.name = "Room" + i + "_" + j;
                Rooms.Add(Room);

            }
            
        }

        playerPosition = new Vector2(Random.Range(0,7), Random.Range(0, 7));
        
        PlacePlayerOnMap(playerPosition.x, playerPosition.y);

    }

    void Update()
    {
        
    }

    private void PlacePlayerOnMap(float x, float y)
    {
        for (int i = 0;i < Rooms.Count;i++)
        {
            if (Rooms[i].name == "Room" + x + "_" + y)
            {
                Debug.Log("PositionPlayer" + "   " + Rooms[i].name);
            }
        }
    }
}
