using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform cube;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(cube.transform.position, transform.position) > 3)
        {
            transform.position = Vector3.Lerp(transform.position, cube.transform.position, Time.deltaTime);
        }
        transform.forward = cube.transform.position- transform.position;
    }
    
    
}
