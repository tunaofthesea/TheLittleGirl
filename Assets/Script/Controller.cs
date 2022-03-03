using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isMoving;
    public float speed;
    public Sprite left;
    public Sprite right;
    public Sprite idle;
    public bool jumpingBool;
    private Rigidbody2D rb;
    public float JumpForce;
    private float initialY;
    public int jumpCount;
    public bool doubleJump_activated;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.tag == "Floor")
            {
                //initialY = transform.position.y;
                jumpingBool = false;
                jumpCount = 0;
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            isMoving = true;
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (!jumpingBool)
            {
                GetComponent<SpriteRenderer>().sprite = right;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            isMoving = true;
            transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (!jumpingBool)
            {
                GetComponent<SpriteRenderer>().sprite = left;
            }
        }
        else
        {
            isMoving = false;
            GetComponent<SpriteRenderer>().sprite = idle;
        }

        if (doubleJump_activated)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 1)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpForce);
                jumpingBool = true;
                jumpCount++;
            }
        }
       else
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpingBool == false)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpForce);
                jumpingBool = true;
            }
        }

    }

    void flowerQuest()
    {

    }
}
