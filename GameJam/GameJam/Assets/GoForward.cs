using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float strength = 50.0f;
    private GameObject player;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("player");

        Vector2 fwd = new Vector3();

        transform.SetPositionAndRotation(player.transform.position, player.transform.rotation);
        transform.GetComponent<Rigidbody2D>().AddForce(transform.right * strength);
	}
	
}
