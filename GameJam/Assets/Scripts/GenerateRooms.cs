using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour {

    public int verticalRoomIndex = 0;
    public int horizontalRoomIndex = 0;
    public float roomOffset = 0.7f;

    public void SetNewIndexes(int x, int y)
    {
        verticalRoomIndex = x;
        horizontalRoomIndex = y;
    }
}
