using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    public static ComputeShader compute;
    public static ComputeBuffer result;
    public static void GetNoise(int x,int y, int z, int scale)
    {  
        result = new ComputeBuffer(18 * 258 * 18, 4);
        Vector4 offsetxyzScale = new Vector4(x, y, z, scale);
        int kernel = compute.FindKernel("CSMain");      
        compute.SetBuffer(kernel, "Result",result);
        compute.SetVector("offsetScale", offsetxyzScale);
        compute.Dispatch(kernel, 2, 43, 2);           
        result.GetData(Chunk.noise);
        result.Release();
    }
}
