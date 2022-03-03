using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerItem : MonoBehaviour
{
    public GameObject flowerGame;
    public bool trigger_bool;
    public bool coroutine_bool;
    public GameObject blackFilter;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            trigger_bool = true;
            /*if(!flowerGame.activeInHierarchy)
            {
                flowerGame.SetActive(true);
            }*/
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger_bool = false;
        /*if(flowerGame.activeInHierarchy)
        flowerGame.SetActive(false);*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger_bool == true && Input.GetKeyDown(KeyCode.E) && coroutine_bool == false)
        {
            StartCoroutine(startLock());
            if (!flowerGame.activeInHierarchy)
            {
                flowerGame.SetActive(true);
                blackFilter.GetComponent<Animator>().Play("blackFilter_darken");
            }
            else
            {
                flowerGame.SetActive(false);
                blackFilter.GetComponent<Animator>().Play("blackFilter_lighten");
            }
        }
    }

    IEnumerator startLock()
    {
        coroutine_bool = true;
        yield return new WaitForSeconds(0.4f);
        coroutine_bool = false;
    }
}
