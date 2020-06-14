using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

unsafe public class Chunk : MonoBehaviour
{
    public static Vector3Int size = new Vector3Int(16, 256, 16);
    [SerializeField]
    static int AtlasResolution = 256;
    [SerializeField]
    static int tileResolution = 16;
    [DllImport("VoxelMeshDll", EntryPoint = "GenerateNoise")]
    public static extern void GenerateNoise(float[] a, int x, int y, int z, int heightLimit, float scale, Vector3 offset,float groundScale,float modifer);

    static public Material material;
    static Mesh mesh;
    static List<Vector3> vertices;
    static List<Vector2> uv;
    unsafe static void CreateFace(Vector3 position, byte direction)
    {       
        switch (direction)
        {
            case 0:
                vertices.Add(position + new Vector3(-0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(-0.5f, 0.5f, -0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, -0.5f));
                break;
            case 1:
                vertices.Add(position + new Vector3(-0.5f, -0.5f, 0.5f));
                vertices.Add(position + new Vector3(-0.5f, 0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, -0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, 0.5f));
                break;
            case 2:
                vertices.Add(position + new Vector3(0.5f, -0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, -0.5f));
                break;
            case 3:
                vertices.Add(position + new Vector3(-0.5f, -0.5f, 0.5f));
                vertices.Add(position + new Vector3(-0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(-0.5f, 0.5f, 0.5f));
                vertices.Add(position + new Vector3(-0.5f, 0.5f, -0.5f));
                break;
            case 4:
                vertices.Add(position + new Vector3(-0.5f, 0.5f, -0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, -0.5f));
                vertices.Add(position + new Vector3(-0.5f, 0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, 0.5f, 0.5f));
                break;
            case 5:
                vertices.Add(position + new Vector3(-0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(-0.5f, -0.5f, 0.5f));
                vertices.Add(position + new Vector3(0.5f, -0.5f, -0.5f));
                vertices.Add(position + new Vector3(0.5f, -0.5f, 0.5f));
                break;
        }
        float d = 1f / ((float)AtlasResolution / (tileResolution));
        float offsetx = block.x;
        offsetx *= d;
        float offsety = block.y;
        offsety *= d;
        uv.Add(new Vector2(offsetx, 1f - offsety));
        uv.Add(new Vector2(d + offsetx, 1f - offsety));
        uv.Add(new Vector2(offsetx, 1f - d - offsety));
        uv.Add(new Vector2(offsetx + d, 1f - d - offsety));
    }
    void CreateCube(Vector3 position)
    {
        CreateFace(position, 0);
        CreateFace(position, 1);
        CreateFace(position, 2);
        CreateFace(position, 3);
        CreateFace(position, 4);
        CreateFace(position, 5);
        //    int v = vertices.Count;           
        #region 
        //front
        //indices[i] = 3;
        //i++;
        //indices[i] = 2;
        //i++;
        //indices[i] = 1;
        //i++;
        //indices[i] = 0;
        //i++;
        ////top
        //indices[i] = 4;
        //i++;
        //indices[i] = 5;
        //i++;
        //indices[i] = 2;
        //i++;
        //indices[i] = 3;
        //i++;
        ////right 
        //indices[i] = 2;
        //i++;
        //indices[i] = 5;
        //i++;
        //indices[i] = 6;
        //i++;
        //indices[i] = 1;
        //i++;
        ////left
        //indices[i] = 0;
        //i++;
        //indices[i] = 7;
        //i++;
        //indices[i] = 4;
        //i++;
        //indices[i] = 3;
        //i++;
        ////back
        //indices[i] = 7;
        //i++;
        //indices[i] = 6;
        //i++;
        //indices[i] = 5;
        //i++;
        //indices[i] = 4;
        //i++;
        ////bottom
        //indices[i] = 0;
        //i++;
        //indices[i] = 1;
        //i++;
        //indices[i] = 6;
        //i++;
        //indices[i] = 7;
        //i++;
        #endregion
    }
    [SerializeField]
    static Vector3Int offset;
    static Vector2Int block = new Vector2Int(0, 0);
    public static float[] noise = new float[18 * 258 * 18];
    unsafe void Start()
    {
   
        vertices = null;
        uv = null;
        vertices = new List<Vector3>();
        uv = new List<Vector2>();
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        int xx = (int)transform.position.x + offset.x, xy = (int)transform.position.y + offset.y, xz = (int)transform.position.z + offset.z;
        GenerateNoise(noise, 18, 258, 18, 64, 0.05f, new Vector3(xx - 1, xy - 1, xz - 1),0.01f,5f);
        int mx = size.x, my = size.y, mz = size.z;
        for (int x = 0; x < mx; x++)
        {
            for (int z = 0; z < mz; z++)
            {
                for (int y = 0; y < 70; y++)
                {
                    block.x = 0;
                    block.y = 0;
                    if (y > 60)
                    {
                        block.x = 3;
                        block.y = 0;
                        if (noise[(z + 1) * 18 * 258 + (y + 2) * 18 + (x + 1)] <= 0.4f)
                        {
                            block.x = 1;
                            block.y = 0;
                        }
                    }
                    if (GetNoise(x + 1, y + 1, z + 1) > 0.4f)
                    {
                        if (noise[z * 18 * 258 + (y + 1) * 18 + (x + 1)] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 0);
                        }
                        if (noise[(z + 2) * 18 * 258 + (y + 1) * 18 + (x + 1)] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 1);
                        }
                        if (noise[(z + 1) * 18 * 258 + (y + 1) * 18 + (x + 2)] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 2);
                        }
                        if (noise[(z + 1) * 18 * 258 + (y + 1) * 18 + x] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 3);
                        }
                        if (noise[(z + 1) * 18 * 258 + (y + 2) * 18 + (x + 1)] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 4);
                        }
                        if (noise[(z + 1) * 18 * 258 + y * 18 + (x + 1)] <= 0.4f)
                        {
                            CreateFace(new Vector3(x, y, z), 5);
                        }
                    }
               
                }
            }
        }
        int[] indices = new int[vertices.Count];
        for (int c = 0, i = vertices.Count - 4; i >= 0; i -= 4, c += 4)
        {   
            indices[c] = 2 + i;
            indices[1 + c] = 3 + i;
            indices[2 + c] = 1 + i;
            indices[3 + c] = 0 + i;
        }
        mesh.SetVertices(vertices);
        mesh.SetIndices(indices, MeshTopology.Quads, 0);
        mesh.SetUVs(0, uv);
        mesh.RecalculateNormals();
    //    System.GC.Collect(0, System.GCCollectionMode.Optimized);
      //  System.GC.WaitForPendingFinalizers();
    }


    unsafe float GetNoise(int x, int y, int z)
    {
        return noise[z * 18 * 258 + y * 18 + x];
    }
}