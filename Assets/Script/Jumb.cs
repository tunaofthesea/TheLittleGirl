using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumb : MonoBehaviour
{
    public bool collision_bool;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision_bool == false)
        {
            GetComponent<Animator>().Play("PlatformReaction");
            collision_bool = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision_bool = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
