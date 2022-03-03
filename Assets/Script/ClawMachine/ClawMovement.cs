using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMovement : MonoBehaviour
{
    public bool movement;
    public GameObject target1;
    public bool target1_reached;
    public GameObject target2;
    public bool destination_reached;
    public float ScaleFactor;
    public float moveSpeed;
    private bool wait_bool;
    public GameObject mainJoint;
    public GameObject leftClaw;
    public GameObject rightClaw;
    public GameObject bar1;
    public GameObject bar2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement && destination_reached == false)
        {
            if (target1_reached == false)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target1.transform.position, moveSpeed / 3 * Time.deltaTime);
                if (transform.localScale.x < 1.3f)
                {
                    transform.localScale += new Vector3(1, 1, 0) * Time.deltaTime * ScaleFactor;
                }

                if (transform.localPosition == target1.transform.localPosition)
                {
                    if(wait_bool == false)
                    {
                        bar1.SetActive(false);
                        bar2.SetActive(false);
                        StartCoroutine(waitforArm());
                    }
                }
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target2.transform.position, moveSpeed * Time.deltaTime);
                if (transform.localPosition == target2.transform.localPosition)
                {
                    destination_reached = true;
                }
            }
        }
        else if(destination_reached)
        {
            leftClaw.transform.localRotation = Quaternion.RotateTowards(leftClaw.transform.localRotation, Quaternion.Euler(0, 0, -30), 200 * Time.deltaTime);
            rightClaw.transform.localRotation = Quaternion.RotateTowards(rightClaw.transform.localRotation, Quaternion.Euler(0, 0, 30), 200 * Time.deltaTime);
            mainJoint.GetComponent<MainJoint>().activated = true;
        }

        IEnumerator waitforArm()
        {
            wait_bool = true;
            yield return new WaitForSeconds(0.5f);
            target1_reached = true;
            wait_bool = false;
        }
    }
}
