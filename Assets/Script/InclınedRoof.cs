using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclınedRoof : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
