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
    public Rigidbody2D rb;
    public float JumpForce;
    private float initialY;
    public int jumpCount;
    public bool doubleJump_activated;
    public GameObject girl;
    public bool flipped;

    public bool airHold_bool;

    public bool randIdle_bool;

    public Vector2 rb_velocity;
    public Vector2 initialVelocity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.tag == "Floor")
            {
                //initialY = transform.position.y;
                jumpingBool = false;
                girl.GetComponent<Animator>().SetBool("Jump", false);
                if (girl.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("girl_Jump"))
                {
                    girl.GetComponent<Animator>().Play("girl_Idle");
                }
                jumpCount = 0;
                airHold_bool = false;
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }


    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            isMoving = true;
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            girl.GetComponent<SpriteRenderer>().flipX = false;
            if (!jumpingBool)
            {
                //GetComponent<SpriteRenderer>().sprite = right;
                //girl.GetComponent<SpriteRenderer>().flipX = false;
                girl.GetComponent<Animator>().SetBool("Right", true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            isMoving = true;
            transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
            girl.GetComponent<SpriteRenderer>().flipX = true;
            if (!jumpingBool)
            {
                //GetComponent<SpriteRenderer>().sprite = left;
                //girl.GetComponent<SpriteRenderer>().flipX = true;
                girl.GetComponent<Animator>().SetBool("Right", true);
            }
        }
        else
        {
            isMoving = false;
            girl.GetComponent<Animator>().SetBool("Right", false);
            girl.GetComponent<Animator>().SetBool("Left", false);
            //GetComponent<SpriteRenderer>().sprite = idle;
        }

        if (doubleJump_activated)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 1)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpForce);
                jumpingBool = true;
                jumpCount++;
                //girl.GetComponent<Animator>().Play("girl_Idle");
                //girl.GetComponent<Animator>().SetBool("Jump", true);
                girl.GetComponent<Animator>().Play("girl_Idle");
                girl.GetComponent<Animator>().SetBool("Jump", true);

            }
        }
       else
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpingBool == false)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * JumpForce);
                jumpingBool = true;
                //girl.GetComponent<Animator>().SetBool("Jump", true);
            }
        }

        if(isMoving == false && randIdle_bool == false)
        {
            StartCoroutine(randomIdleTiming());
        }
       /* if(rb.velocity.x < 0 && flipped == false)
        {
            girl.GetComponent<SpriteRenderer>().flipX = true;
            flipped = true;
        }*/
       if(jumpingBool == true)
        {
            if (rb.velocity.y < 0 && !airHold_bool)
            {
                initialVelocity = rb.velocity;
                StartCoroutine(holdOnAir());
            }
        }
        rb_velocity = rb.velocity;

    }

    void flowerQuest()
    {
    }
    public void rotatePlayer()
    {
        StartCoroutine(rotatePlayer_coroutine());
        StartCoroutine(activateCollider());
    }
    IEnumerator rotatePlayer_coroutine()
    {
        yield return null;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    IEnumerator activateCollider()
    {
        randIdle_bool = true;
        yield return new WaitForSeconds(0.2f);
        transform.GetComponent<CircleCollider2D>().enabled = true;
        randIdle_bool = false;
    }

    IEnumerator randomIdleTiming()
    {
        randIdle_bool = true;
        girl.GetComponent<Animator>().Play("girl_randomIdle");
        float randomFloat = Random.Range(5f, 9f);
        yield return new WaitForSeconds(randomFloat);
        randIdle_bool = false;

    }

    IEnumerator holdOnAir()
    {
        airHold_bool = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(0.1f);
        //rb.velocity = initialVelocity;
        GetComponent<Rigidbody2D>().gravityScale = 3;

    }
}
