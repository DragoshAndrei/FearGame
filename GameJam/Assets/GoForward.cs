using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float strength = 50.0f;

    // Use this for initialization
    void Start () {

        Vector2 fwd = new Vector3();


        transform.GetComponent<Rigidbody2D>().AddForce(transform.right * strength);
	}
	
}
