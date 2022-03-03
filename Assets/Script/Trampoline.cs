using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public bool botHit;
    public bool playerOn_bool;
    public GameObject pivot;
    public float Speed;
    private Rigidbody2D rb;
    public GameObject player;
    public bool playerHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerOn_bool = true;
        if(collision.gameObject.tag == "TrampolineBot")
        {
            rb.velocity = Vector3.zero;
            botHit = true;
            player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 800);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerOn_bool = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOn_bool == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pivot.transform.position, Speed * Time.deltaTime);
            if(transform.position == pivot.transform.position)
            {
                playerHit = false;
            }
        }
        if(botHit && playerOn_bool && !playerHit)
        {
            playerHit = true;
            //player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300);
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 300);
            } */
        }
    }
}
