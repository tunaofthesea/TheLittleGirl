using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float Speed;
    public float distanceY;
    public float midAirDistanceY;
    public float distanceYBetween;
    public Vector3 startPos;
    private Vector3 targetpos;
    private Vector3 camStartPos;
    public float thedistance;
    void Start()
    {
        startPos = player.transform.position;
        camStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(player.transform.position.y - startPos.y);
        thedistance = distance;
        if (distance > distanceYBetween)
        {
            targetpos = new Vector3(player.transform.position.x, player.transform.position.y, -10) + new Vector3(0, distanceY, 0);
        }
        else
        {
            //targetpos = new Vector3(player.transform.position.x, camStartPos.y, -10) + new Vector3(0, distanceY, 0);
            targetpos = new Vector3(player.transform.position.x, player.transform.position.y, -10) - new Vector3(0, midAirDistanceY, 0); ;
        }
        transform.position = Vector3.Lerp(transform.position, targetpos, Speed * Time.deltaTime);
        /*if(distance > distanceYBetween)
        {
            distanceY = 0;
        }
        else
        {
            distanceY = 2;
        }*/
    }
}
