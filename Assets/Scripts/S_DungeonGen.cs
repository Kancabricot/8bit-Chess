using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class S_DungeonGen : MonoBehaviour
{
    [SerializeField] private Vector2 playerPosition = Vector2.zero;
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private List<GameObject> roomsgenerate = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int rand = Random.Range(0, rooms.Length);
                string currentRoomName = rooms[rand].name;

                GameObject Room = Instantiate(rooms[rand], new Vector2(i * 12, j * 12), Quaternion.identity);

                Room.name = currentRoomName + " " + i + "_" + j;
                roomsgenerate.Add(Room);

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
        for (int i = 0;i < roomsgenerate.Count;i++)
        {
            if (roomsgenerate[i].name == "Room" + x + "_" + y)
            {
                Debug.Log("PositionPlayer" + "   " + roomsgenerate[i].name);
            }
        }
    }
}
