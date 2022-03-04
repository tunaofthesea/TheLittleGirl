using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeHold : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            collision.gameObject.GetComponent<Controller>().enabled = false;
            collision.gameObject.GetComponent<PlayerRope>().enabled = true;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            collision.gameObject.transform.parent = this.gameObject.transform;
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
