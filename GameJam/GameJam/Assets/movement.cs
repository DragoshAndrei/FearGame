using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public float speed = 3.0f;
	public GameObject flare;
    public int lifePoints = 3;
    public float timeToShoot = 1.0f;

	private float updateDistance = 0.0f;
	private bool hasFlare = true;
    private float tts = 0.0f;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		updateDistance = Time.deltaTime * speed;
		transform.position = new Vector3(transform.position.x + updateDistance * Input.GetAxisRaw("Horizontal"),
			transform.position.y + updateDistance * Input.GetAxisRaw("Vertical"), transform.position.z);

        if(!hasFlare)
        {
            tts += Time.deltaTime;
            if(tts > timeToShoot)
            {
                hasFlare = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && hasFlare)
        {
            GameObject flareShot = Instantiate(flare);
            flareShot.transform.position = transform.position;
            flareShot.transform.rotation = transform.rotation;
            hasFlare = false;
            
        }


    }

    public void ReduseHP()
    {
        lifePoints--;
    }
}
