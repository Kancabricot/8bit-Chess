using System.Collections.Generic;
using UnityEngine;

public class S_DungeonGen : MonoBehaviour
{
    [SerializeField] private Vector2 playerPosition = Vector2.zero;
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private List<GameObject> roomsgenerate = new List<GameObject>();
    [SerializeField] private GameObject bossRoom;

    void Start()
    {
        bool bossRoomIsPlaced = false;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(bossRoomIsPlaced == false && Random.Range(0, 32) == 1)
                {
                    GameObject roomBoss = Instantiate(bossRoom, new Vector2(i * 12, j * 12), Quaternion.identity);

                    roomBoss.name = i + "_" + j;
                    roomsgenerate.Add(roomBoss);

                    bossRoomIsPlaced = true;
                }
                else
                {
                    int rand = Random.Range(0, rooms.Length);
                    //string currentRoomName = rooms[rand].name;

                    GameObject room = Instantiate(rooms[rand], new Vector2(i * 12, j * 12), Quaternion.identity);

                    room.name = i + "_" + j;
                    roomsgenerate.Add(room);
                }
                
            }
            
        }

        if (bossRoomIsPlaced == false) 
        {
            int randx = Random.Range(0, 7);
            int randy = Random.Range(0, 7);

            for (int i = 0; i < roomsgenerate.Count; i++)
            {
                if (roomsgenerate[i].name == randx + "_" + randy)
                {
                    roomsgenerate[i] = null;

                    break;
                }
            }

            GameObject roomBoss = Instantiate(bossRoom, new Vector2(randx * 12, randy * 12), Quaternion.identity);

            roomBoss.name = randx + "_" + randy;
            roomsgenerate.Add(roomBoss);
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
            if (roomsgenerate[i].name == x + "_" + y)
            {
                string nameNewRoom = roomsgenerate[i].name;
               
                FindObjectOfType<S_PlayerScript>().TPRoom(roomsgenerate[i].transform.position);
                FindObjectOfType<S_Room>().SpawnSpawner(roomsgenerate[i].transform.position);
                //roomsgenerate[i].gam

                break;
            }
        }
    }
}
