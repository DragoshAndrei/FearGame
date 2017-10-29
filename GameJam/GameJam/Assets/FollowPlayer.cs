using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float speed = 3.0f;
    public float minDistance = 19.0f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.name == "player")
        {
            player.GetComponent<movement>().ReduseHP();
            Debug.Log(player.GetComponent<movement>().lifePoints);
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }
    }

}
