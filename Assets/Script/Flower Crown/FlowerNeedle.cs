using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerNeedle : MonoBehaviour
{
    public GameObject pivot;
    public float CenterMoveSpeed;
    public float yLimit;
    public bool hit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hit)
        {
            if (collision.gameObject.tag == "Center")
            {
                //GetComponent<BoxCollider2D>().enabled = false;
                //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //transform.parent = collision.gameObject.transform;
                hit = true;
                //transform.GetChild(1).transform.parent = null;
                transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "HitBox")
            {
                hit = true;
                //transform.GetChild(1).transform.parent = null;
                //Destroy(transform.GetChild(1).gameObject);
                transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.position = collision.gameObject.transform.position;
                transform.parent = collision.gameObject.transform;
                //StartCoroutine(movetoCenter());
                pivot.GetComponent<CenterRoll>().checkTheHitboxes();
                collision.gameObject.GetComponent<Hitbox>().hitbox_bool = true;
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }
    void Start()
    {
        
    }

    //IEnumerator movetoCenter()
    //{
    //    yield return null;
    //    while(transform.localPosition.y > yLimit)
    //    {
    //        yield return null;
    //        transform.localPosition -= new Vector3(0, 1, 0) * CenterMoveSpeed * Time.deltaTime;
    //        if(transform.localPosition.y <= yLimit)
    //        {
    //            break;
    //        }
    //    }
    //}

    public IEnumerator movetoCenter()
    {
        GameObject go = Instantiate(this.gameObject, transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform.parent;
        go.transform.GetChild(1).gameObject.SetActive(false);
        go.GetComponent<BoxCollider2D>().enabled = false;
        go.GetComponent<FlowerNeedle>().enabled = false;
        //yield return new WaitForSeconds(0.2f);
        transform.localPosition = new Vector2(0, transform.localPosition.y);
        while (transform.localPosition.y >= yLimit)
        {
            yield return null;
            transform.localPosition -= new Vector3(0, 1, 0) * CenterMoveSpeed * Time.deltaTime;
            if (transform.localPosition.y <= yLimit)
            {
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
