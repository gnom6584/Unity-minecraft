using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class TestDLL : MonoBehaviour
{
    static int[] a = new int[5000000];
    private void Start()
    {
        for(int i = 0; i < a.Length;i++)
        {
            a[i] = Random.Range(0, 10000);
        }
    }

}
