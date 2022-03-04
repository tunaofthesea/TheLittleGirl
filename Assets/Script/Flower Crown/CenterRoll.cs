using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRoll : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject[] hitboxes;
    public int hitNumber;
    public GameObject confetti;
    private bool stopRotation;
    public int flowerCount;
    public bool coroutine_activated;
    public GameObject mask;
    private bool phase2;
    public GameObject player;
    public float FollowSpeed;
    private bool phase3;
    public GameObject blackFilter;
    public bool flowerDrop_bool;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (stopRotation == false)
        {
            transform.Rotate(0, 0, Time.deltaTime * RotationSpeed, Space.Self);
        }

        else if(stopRotation && phase2)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position + new Vector3(0, 0.6f,0), FollowSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, player.transform.position) < 0.8f)
            {
                phase3 = true;
                phase2 = false;
            }
            transform.Rotate(0, 0, Time.deltaTime * RotationSpeed * 2, Space.Self);
        }
        else if (phase3)
        {
            transform.position = player.transform.position + new Vector3(0, 0.6f, 0);
            transform.Rotate(0, 0, Time.deltaTime * RotationSpeed, Space.Self);
            transform.parent = player.transform;
        }
        if (flowerCount == 0)
        {
            stopRotation = true;
            if (hitNumber > 3)  // if lower than 4 hits, cant pass to the last phase
            {
                if (coroutine_activated == false)
                {
                    StartCoroutine(slowSpawnQue());
                }
            }
            else
            {
                if (flowerDrop_bool == false)
                {
                    dropTheFlowers();
                }
            }
        }
    }

    public void checkTheHitboxes()
    {
        hitNumber = 0;

        for (int i = 0; i < hitboxes.Length; i++)
        {
            if(hitboxes[i].GetComponent<Hitbox>().hitbox_bool == true)
            {
                hitNumber++;
            }

        }
        if(hitNumber == hitboxes.Length - 2) // -1 eklenecek
        {
            GameObject go = Instantiate(confetti, Camera.main.transform.position /*+ new Vector3(0, 0.4f, 0)*/, Quaternion.identity);
            stopRotation = true;
        }

    }

    IEnumerator slowSpawnQue()
    {
        coroutine_activated = true;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < hitboxes.Length; i++)
        {
            if (hitboxes[i].GetComponent<Hitbox>().hitbox_bool == true)
            {
                StartCoroutine(hitboxes[i].transform.GetChild(0).GetComponent<FlowerNeedle>().movetoCenter());
                hitboxes[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 5;
                //hitboxes[i].getcomponent<spriterenderer>().enabled = false;
                yield return new WaitForSeconds(0.2f);
            }
            hitboxes[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        while(mask.transform.localScale.x <= 1)
        {
            mask.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
            if(mask.transform.localScale.x >= 1)
            { break; }
        }
        GameObject go = Instantiate(confetti, transform.position /*+ new Vector3(0, 0.4f, 0)*/, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().Play("CrownScaling");
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.9f);
        blackFilter.GetComponent<Animator>().Play("blackFilter_lighten");
        phase2 = true;
    }

    void dropTheFlowers()
    {
        flowerDrop_bool = true;
        for (int i = 0; i < hitboxes.Length; i++)
        {
            if (hitboxes[i].GetComponent<Hitbox>().hitbox_bool == true)
            {
                hitboxes[i].transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1;
                hitboxes[i].transform.GetChild(0).transform.parent = null;
            }
        }
    }


}
