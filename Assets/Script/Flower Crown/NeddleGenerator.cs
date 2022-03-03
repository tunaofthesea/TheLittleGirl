using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeddleGenerator : MonoBehaviour
{
    public GameObject center;
    public GameObject flowerNeedle;
    public GameObject canvas;
    public Sprite needle1;
    public Sprite needle2;
    public Sprite needle3;
    public bool actionBool;

    public float shootForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !actionBool)
        {
            StartCoroutine(spawnNeedle_coroutine());
            center.GetComponent<CenterRoll>().flowerCount--;
        }
    }

    IEnumerator spawnNeedle_coroutine()
    {
        actionBool = true;
        spawnNeedle();
        yield return new WaitForSeconds(0.1f);
        actionBool = false;
    }

    void spawnNeedle()
    {
        GameObject go = Instantiate(flowerNeedle, transform.position, Quaternion.identity/*, canvas.transform*/) as GameObject;
        int randInt = Random.Range(0, 3);
        go.GetComponent<Rigidbody2D>().AddForce(Vector3.up * shootForce);
        switch (randInt)
        {
            //case 0:
            //    go.GetComponent<UnityEngine.UI.Image>().sprite = needle1;
            //    break;
            //case 1:
            //    go.GetComponent<UnityEngine.UI.Image>().sprite = needle2;
            //    break;
            //case 2:
            //    go.GetComponent<UnityEngine.UI.Image>().sprite = needle3;
            //    break;

            case 0:
                go.GetComponent<SpriteRenderer>().sprite = needle1;
                break;
            case 1:
                go.GetComponent<SpriteRenderer>().sprite = needle2;
                break;
            case 2:
                go.GetComponent<SpriteRenderer>().sprite = needle3;
                break;
        }

    }
}
