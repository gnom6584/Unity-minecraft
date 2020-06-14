using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landshaft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] mas = mesh.vertices;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            mas[i] += new Vector3(0,Random.Range(0,10)/10f,0);
        }
        mesh.vertices = mas;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
