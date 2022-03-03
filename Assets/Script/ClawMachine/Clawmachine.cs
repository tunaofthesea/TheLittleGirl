using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clawmachine : MonoBehaviour
{
    public GameObject bar1;
    public GameObject bar2;

    public GameObject claw;

    public bool failure_bool;

    void Start()
    {
        activateBar1();
    }

    void Update()
    {
        
    }
    public void checkBars()
    {
        if (bar1.GetComponent<Bar>().activated == true)
        {
            activateBar2();
        }

        if(bar1.GetComponent<Bar>().success == true && bar2.GetComponent<Bar>().success == true)
        {
            moveTheArm();
        }

    }

    public void moveTheArm()
    {
        claw.GetComponent<ClawMovement>().movement = true;
    }
    public void activateBar1()
    {
        bar1.GetComponent<Bar>().activated = true;
    } 
    

    public void activateBar2()
    {
        bar2.GetComponent<Bar>().activated = true;
    }

    public void failure()
    {
        failure_bool = true;

        Camera.main.GetComponent<Animator>().Play("camerakShake");
    }
}
