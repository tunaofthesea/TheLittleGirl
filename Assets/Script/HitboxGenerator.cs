using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxGenerator : MonoBehaviour
{
    public int hitboxNum;
    public GameObject hitbox;
    public float circleRadius;
    public GameObject[] hitboxes;
    void Start()
    {
        //ScaleFactor = 1f / hitboxNum;
        Vector3 center = transform.position;
        for (int i = 0; i < hitboxNum; i++)
        {

            int a = 360 / hitboxNum * i;
            Vector3 pos = drawCircle(center, circleRadius, a);
            GameObject go = Instantiate(hitbox, pos, Quaternion.identity); ;
            Vector3 target_pos = transform.position; 
            target_pos.x = target_pos.x - go.transform.position.x;
            target_pos.y = target_pos.y - go.transform.position.y;
            float angle = Mathf.Atan2(target_pos.y, target_pos.x) * Mathf.Rad2Deg;
            go.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
            go.transform.parent = transform;
        }
        hitboxes = GameObject.FindGameObjectsWithTag("HitBox");
        GetComponent<CenterRoll>().hitboxes = hitboxes;
    }

    Vector3 drawCircle(Vector3 center, float radius, int a)
    {

        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    void Update()
    {
        
    }

}
