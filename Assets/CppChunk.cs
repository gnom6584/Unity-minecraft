using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class CppChunk : MonoBehaviour
{
        
    [DllImport("VoxelMeshDll 4", EntryPoint = "CreateChunk")]
    public static extern MeshData CreateChunk(int width, int height, int lenght, float scale, Vector3 offset, int seed);

    public static Material material;
    static Mesh mesh;

    public class MeshData
    {
        public Vector3[] vertices;
        public int[] indices;
        public Vector2[] uv;
    };

    void Start()
    {      
        mesh = gameObject.AddComponent<MeshFilter>().mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;     
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        MeshData data = CreateChunk(18, 258, 18, 0.05f, new Vector3(transform.position.x-1, transform.position.y-1, transform.position.z-1), 1337);
        //int[] a = new int[3];
        //GetVectorsLenght(a);
        //Vector3[] vertices;
        //int[] indices;
        //Vector2[] uv;
        //vertices = new Vector3[a[0]];
        //indices = new int[a[1]];
        //uv = new Vector2[a[2]];
       // GetVectors(vertices, indices, uv);
        //mesh.vertices = vertices;
        //mesh.SetIndices(indices, MeshTopology.Quads, 0);
        //mesh.uv = uv;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
