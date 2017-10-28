using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNewRoom : MonoBehaviour {

    public GameObject gameManager;
    public GameObject room;

    private void OnTriggerEnter2D()
    {
        int x = 0;//gameManager.GetComponent<GenerateRooms>().verticalRoomIndex;
        int y = 0;//gameManager.GetComponent<GenerateRooms>().horizontalRoomIndex;
        Transform mainRoomTransform = transform.parent.parent;
        Debug.Log("I touched the door!");
        Transform newRoomTransform = mainRoomTransform.transform;
        if(transform.name =="DoorW")
        {
            x--;
        }
        else if(transform.name == "DoorE")
        {
            x++;
        }
        else if(transform.name == "DoorN")
        {
            y++;
        }
        else if(transform.name == "DoorS")
        {
            y--;
        }

        Vector2 spriteSize = mainRoomTransform.GetChild(0).GetComponent<BoxCollider2D>().size;

        float valOne = mainRoomTransform.GetChild(0).localScale.x * spriteSize.x * x * gameManager.GetComponent<GenerateRooms>().roomOffset;
        float valTwo = spriteSize.y * mainRoomTransform.GetChild(0).localScale.y * y * gameManager.GetComponent<GenerateRooms>().roomOffset;

        newRoomTransform.position = new Vector3(mainRoomTransform.position.x + valOne,
            mainRoomTransform.position.y + valTwo, mainRoomTransform.position.z);
        gameManager.GetComponent<GenerateRooms>().SetNewIndexes(x, y);
        Vector3 fckingBugsMan = mainRoomTransform.position;
        GameObject newRoom = Instantiate(room, newRoomTransform);
        newRoom.transform.parent = null;
        newRoom.name = "Room";
        newRoom.transform.Translate(-fckingBugsMan);
        Destroy(transform.parent.parent.gameObject);
    }
}
