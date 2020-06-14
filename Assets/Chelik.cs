using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chelik : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {      
        transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up*Input.GetAxis("Vertical"), Time.deltaTime * 10);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0, 1);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //   GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<Animator>().SetTrigger("123");
        }
    }
}
