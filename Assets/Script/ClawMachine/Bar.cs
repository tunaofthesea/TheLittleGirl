using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public bool activated;
    public bool leftRight;
    public bool stop;
    public bool success;

    public float scale_min;
    public float scale_max;
    public float scaleX;

    public Color color1;
    public Color color2;



    public GameObject clawMachine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scaleX = transform.localScale.x;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (activated)
            {
                stop = true;
            }
        }

        if (activated && stop == false)
        {
            if (leftRight)
            {
                transform.localScale += new Vector3(1, 0, 0) * Time.deltaTime;
                //GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, color1, 1f * Time.deltaTime);
                if (transform.localScale.x >= 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    leftRight = false;
                }
            }
            else
            {
                transform.localScale -= new Vector3(1, 0, 0) * Time.deltaTime;
                //GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, color2, 1f  * Time.deltaTime);
                if (transform.localScale.x <= 0)
                {
                    transform.localScale = new Vector3(0, 1, 1);
                    leftRight = true;
                }
            }
        }
        if (stop == true)
        {
            checkTheScale();
        }


    }

    void checkTheScale()
    {
        if(transform.lossyScale.x >= scale_min && transform.lossyScale.x <= scale_max)
        {
            success = true;
            clawMachine.GetComponent<Clawmachine>().checkBars();
        }
    }

    
}
