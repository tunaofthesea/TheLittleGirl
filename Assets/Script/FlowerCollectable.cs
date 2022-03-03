using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollectable : MonoBehaviour
{
    public bool trigger_bool;
    public GameObject flowerUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            trigger_bool = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger_bool = false;
    }
    void Start()
    {
        flowerUI = GameObject.FindGameObjectWithTag("FlowerUI");
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger_bool == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                flowerUI.GetComponent<FlowerUI>().objectTextAdd();
                Destroy(this.gameObject);
            }
        }
    }
}
