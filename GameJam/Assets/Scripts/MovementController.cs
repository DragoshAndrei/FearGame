using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed = 3.0f;

    private float updateDistance = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateDistance = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x + updateDistance * Input.GetAxisRaw("Horizontal"),
                    transform.position.y + updateDistance * Input.GetAxisRaw("Vertical"), transform.position.z);
	}
}
