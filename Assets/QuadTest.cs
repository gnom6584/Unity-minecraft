using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTest : MonoBehaviour
{
    Mesh mesh;
    [SerializeField]
    Material material;
    List<Vector3> vertices =new List<Vector3>();
    List<int> indices = new List<int>();
    List<Vector2> uv = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        mesh = gameObject.AddComponent<MeshFilter>().mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        vertices.Add(new Vector3(-0.5f, -0.5f, 0));
        vertices.Add(new Vector3(0.5f, -0.5f, 0));
        vertices.Add(new Vector3(-0.5f, 0.5f, 0));
        vertices.Add(new Vector3(0.5f, 0.5f, 0));
        Vector3 position = new Vector3(1,0,0);
        vertices.Add(new Vector3(-0.5f, -0.5f, 0)+position);
        vertices.Add(new Vector3(0.5f, -0.5f, 0) + position);
        vertices.Add(new Vector3(-0.5f, 0.5f, 0) + position);
        vertices.Add(new Vector3(0.5f, 0.5f, 0) + position);

        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(1, 0));
        uv.Add(new Vector2(0, 1));
        uv.Add(new Vector2(1, 1));
        uv.Add(new Vector2(0, 0));
        uv.Add(new Vector2(0.5f, 0));
        uv.Add(new Vector2(0, 1));
        uv.Add(new Vector2(0.5f, 1));


        indices.Add(0);
        indices.Add(2);
        indices.Add(7);
        indices.Add(5);
        mesh.SetVertices(vertices);
        mesh.SetIndices(indices.ToArray(), MeshTopology.Quads, 0);
        mesh.SetUVs(0,uv);
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
