using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPress : MonoBehaviour
{
    public GameObject pollen;
    public float yDistance;
    public bool coroutineActivated;
    public GameObject player;
    public BoxCollider2D boxCol;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boxCol.enabled = false;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCol.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        boxCol.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(coroutineActivated == false)
        {
            StartCoroutine(spawnPollen());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        coroutineActivated = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnPollen()
    {
        coroutineActivated = true;
        yield return null;
        GameObject pol = Instantiate(pollen, transform.position - new Vector3(0, yDistance, 0), Quaternion.identity) as GameObject;
    }
}
