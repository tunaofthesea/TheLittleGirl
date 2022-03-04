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

    public bool randIdle_bool;
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
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }


    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            isMoving = true;
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (!jumpingBool)
            {
                //GetComponent<SpriteRenderer>().sprite = right;
                girl.GetComponent<Animator>().SetBool("Right", true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            isMoving = true;
            transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
            if (!jumpingBool)
            {
                //GetComponent<SpriteRenderer>().sprite = left;
                girl.GetComponent<Animator>().SetBool("Left", true);
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

        if(isMoving == false && randIdle_bool == false)
        {
            StartCoroutine(randomIdleTiming());
        }

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
}
