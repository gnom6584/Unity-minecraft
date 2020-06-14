using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class balass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "228")
        GameObject.Find("123").GetComponent<Text>().enabled = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
