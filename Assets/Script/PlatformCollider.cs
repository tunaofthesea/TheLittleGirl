using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public BoxCollider2D boxCol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCol.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        boxCol.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
