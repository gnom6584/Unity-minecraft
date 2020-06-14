using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField]
    GameObject chunk;
    [SerializeField]
    public Vector3Int Size = new Vector3Int(16, 256, 16);
    public static Vector3Int size;
    [SerializeField]
    int p = 32;
    [SerializeField]
    ComputeShader compute;
    [SerializeField]
    Material material;
    // Start is called before the first frame update
    void Awake()
    {
        Chunk.material = material;
        CppChunk.material = material;
        ComputeShaderTest.compute = compute;
        size = Size;
        StartCoroutine(Generate());
    }
    float timer;
    bool ready = false;
    void Update()
    {
        if (!ready)
            timer += Time.deltaTime;
        else
        {
            Debug.Log(timer);
            Debug.Log("Record:" + PlayerPrefs.GetFloat("Record"));
            ready = false;
        }
    }
    int chucnkcount;
    IEnumerator Generate()
    {
        int sizex = p * size.x;
        int sizez = p * size.z;
        int sizexd2 = sizex / 2;
        int sizezd2 = sizez / 2;
        for (int x = 0; x < sizex; x += size.x)
        {
            for (int y = 0; y < sizez; y += size.z)
            {         
                Instantiate(chunk, new Vector3(x-sizexd2, -64, y-sizexd2), Quaternion.identity);
                chucnkcount++;                
                yield return null;
            }

        }
        ready = true; Debug.Log(chucnkcount);
        if (timer < PlayerPrefs.GetFloat("Record"))
            PlayerPrefs.SetFloat("Record", timer);
    }
    private void OnDestroy()
    {
        System.GC.Collect();
    }
}
