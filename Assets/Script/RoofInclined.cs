using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofInclined : MonoBehaviour
{
    public float angles;
    public bool collision_bool;
    private GameObject collisionGO;
    public float slipSpeed;
    public Vector3 normalScale;
    public float jumpMagnitude;
    public GameObject player;
    public float gravityValue1;
    public float newVelocity;
    public float additionalGravity;

    public Vector2 jumpVector;
    public Vector2 rbVelocity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision_bool = true;
        collisionGO = collision.gameObject;
        collisionGO.GetComponent<Rigidbody2D>().gravityScale = additionalGravity;
        //collisionGO.GetComponent<Rigidbody2D>().velocity += new Vector2(newVelocity, 0);
        collisionGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angles));
        collisionGO.GetComponent<Controller>().enabled = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //collisionGO.transform.parent = null;
        collision_bool = false;
        collisionGO.GetComponent<Rigidbody2D>().gravityScale = gravityValue1;
        collisionGO.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        collisionGO.GetComponent<Controller>().enabled = true;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gravityValue1 = player.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(collision_bool)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddForce();
            }
        }
    }

    void AddForce()
    {
        collisionGO.GetComponent<Rigidbody2D>().AddForce(jumpVector * jumpMagnitude);
    }
}
