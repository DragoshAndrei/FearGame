using UnityEngine;

public class MovementController : MonoBehaviour {
    
    public float speed = 3.0f;
    public GameObject flare;

    private float updateDistance = 0.0f;
    private LayerMask layerMask;
    private bool hasFlare = true;
    

    // Use this for initialization
    void Awake()
    {
        layerMask = LayerMask.GetMask("Floor");

    }

    // Update is called once per frame
    void Update()
    {
        
        updateDistance = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x + updateDistance * Input.GetAxisRaw("Horizontal"),
                    transform.position.y + updateDistance * Input.GetAxisRaw("Vertical"), transform.position.z);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        Vector2 fwd = new Vector3();

        //Debug.Log(Input.mousePosition);

        float camRayLength = 100;

        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, layerMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            transform.GetComponent<Rigidbody2D>().MoveRotation(newRotatation.y);

        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && hasFlare)
        {
            GameObject flareShot = Instantiate(flare);
            flareShot.transform.position = transform.position;
            flareShot.transform.rotation = transform.rotation;
            hasFlare = false;
        }

        //Debug.Log(transform.rotation.z);

    }
}
