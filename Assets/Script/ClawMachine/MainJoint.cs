using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainJoint : MonoBehaviour
{
    public bool activated;
    public bool deactivate;
    public GameObject leftClaw;
    public GameObject rightClaw;
    public Vector3 startPos;
    public float speed;
    public bool confetti_bool;

    public GameObject confetti;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TeddyBear")
        {
            collision.gameObject.transform.parent = transform;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            deactivate = true;
        }
    }

    void Start()
    {
        startPos = transform.localPosition;
    }


    void Update()
    {
        if(activated == true && deactivate == false)
        {
            transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        else if(deactivate)
        {
            rightClaw.transform.localRotation = new Quaternion(0, 0, 0, 0);
            leftClaw.transform.localRotation = new Quaternion(0, 0, 0, 0);

            if (transform.localPosition.y <= startPos.y)
            {
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
                if(transform.localPosition.y >= startPos.y && !confetti_bool)
                {
                    confetti_bool = true;
                    GameObject go = Instantiate(confetti, transform.localPosition, Quaternion.identity) as GameObject;
                }
            }
        }
    }

    IEnumerator positionClaws()
    {
        yield return null;
        leftClaw.transform.rotation = Quaternion.RotateTowards(leftClaw.transform.rotation, Quaternion.Euler(0, 0, 30), 200 * speed * Time.deltaTime);

    }

}
