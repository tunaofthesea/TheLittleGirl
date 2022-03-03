using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerUI : MonoBehaviour
{
    public GameObject textObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void objectTextAdd()
    {
        int count = System.Convert.ToInt32(textObject.GetComponent<TextMeshProUGUI>().text);
        count++;
        textObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(count);
    }
}
