using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNewRoom : MonoBehaviour {

    public GameObject gameManager;
    public GameObject player;
    public GameObject room;
    private void OnTriggerEnter2D()
    {
        int x = gameManager.GetComponent<GenerateRooms>().verticalRoomIndex;
        int y = gameManager.GetComponent<GenerateRooms>().horizontalRoomIndex;
        Transform mainRoomTransform = transform.parent.parent;
        Transform newRoomTransform = mainRoomTransform.transform;
        float offsetOne = 0.0f;
        float offsetTwo = 0.0f;
        if (transform.name == "DoorE")
        {
            x--;
            offsetOne = 52.0f;
            offsetTwo = 14.0f;
        }
        else if (transform.name == "DoorW")
        {
            x++;
            offsetOne = 13.0f;
            offsetTwo = 14.0f;
        }
        else if (transform.name == "DoorS")
        {
            y++;
            offsetOne = 33.0f;
            offsetTwo = 33.0f;
        }
        else if (transform.name == "DoorN")
        {
            y--;
            offsetOne = 33.0f;
            offsetTwo = -4.0f;
        }

        Vector2 spriteSize = mainRoomTransform.GetChild(3).GetChild(0).GetComponent<BoxCollider2D>().size;
        player.transform.position = new Vector3(offsetOne, offsetTwo, player.transform.position.z);
        GameObject newRoom = Instantiate(room, newRoomTransform);
        newRoom.transform.parent = null;
        newRoom.name = "Room";
        GameObject enemyPool = GameObject.Find("enemies");
        Destroy(enemyPool);
        Destroy(transform.parent.parent.gameObject);
    }

    //private void OnTriggerEnter2D()
    //{
    //    int x =  gameManager.GetComponent<GenerateRooms>().verticalRoomIndex;
    //    int y =  gameManager.GetComponent<GenerateRooms>().horizontalRoomIndex;
    //    Transform mainRoomTransform = transform.parent.parent;
    //    Transform newRoomTransform = mainRoomTransform.transform;
    //    float offsetOne = gameManager.GetComponent<GenerateRooms>().roomOffset;
    //    float offsetTwo = gameManager.GetComponent<GenerateRooms>().roomOffset;
    //    if (transform.name =="DoorE")
    //    {
    //        x--;
    //    }
    //    else if(transform.name == "DooW")
    //    {
    //        x++;
    //    }
    //    else if(transform.name == "DoorN")
    //    {
    //        y++;
    //    }
    //    else if(transform.name == "DoorS")
    //    {
    //        y--;
    //    }

    //    Vector2 spriteSize = mainRoomTransform.GetChild(3).GetChild(0).GetComponent<BoxCollider2D>().size;


    //    float valOne = mainRoomTransform.GetChild(3).GetChild(0).localScale.x * 2 * spriteSize.x * x * offsetOne;
    //    float valTwo = spriteSize.y * 2 * mainRoomTransform.GetChild(3).GetChild(0).localScale.y * y * offsetTwo;

    //    newRoomTransform.position = new Vector3(mainRoomTransform.position.x + valOne,
    //        mainRoomTransform.position.y + valTwo, mainRoomTransform.position.z);
    //    gameManager.GetComponent<GenerateRooms>().SetNewIndexes(x, y);
    //    Vector3 fckingBugsMan = mainRoomTransform.position;
    //    GameObject newRoom = Instantiate(room, newRoomTransform);
    //    newRoom.transform.parent = null;
    //    newRoom.name = "Room";
    //    newRoom.transform.Translate(-fckingBugsMan);
    //    Destroy(transform.parent.parent.gameObject);
    //}
}
