using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUBE : MonoBehaviour
{
    void Start()
    {
        transform.position += new Vector3(1,0,0);
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(0.01f, 0, 0);
        //    transform.Rotate(1, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= new Vector3(0.01f, 0, 0);
        //    transform.Rotate(-1, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, 0, 0.01F);
        //    transform.Rotate(0, 0, 1);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= new Vector3(0, 0, 0.01F);
        //    transform.Rotate(0, 0, -1);
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 300);
        }
    }
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }
}
