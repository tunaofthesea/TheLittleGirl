using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRope : MonoBehaviour
{
    public GameObject swingRope;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < swingRope.transform.childCount; i++) //disables colliders of the ropeModules
            {
                //swingRope.transform.GetChild(i).GetComponent<CircleCollider2D>().enabled = false;
                swingRope.transform.GetChild(i).gameObject.layer = 7;
            }
            transform.parent = null;
            transform.GetComponent<Controller>().enabled = true;
            transform.GetComponent<Controller>().rotatePlayer();
            transform.GetComponent<CircleCollider2D>().enabled = true;
            this.gameObject.AddComponent<Rigidbody2D>();
            this.gameObject.GetComponent<Controller>().rb = GetComponent<Rigidbody2D>();
            this.gameObject.GetComponent<Controller>().rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            GetComponent<Rigidbody2D>().gravityScale = 3;
            GetComponent<Rigidbody2D>().mass = 1;
            GetComponent<Rigidbody2D>().drag = 0;
            GetComponent<Rigidbody2D>().angularDrag = 0;
            GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Extrapolate;
            this.enabled = false;

            // buraya karakteri inclined roof scriptine benzer bir sekilde firlaticak bir function hazirlayabilirsin.
        }
    }

    
}
