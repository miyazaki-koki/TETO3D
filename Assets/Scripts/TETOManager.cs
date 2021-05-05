using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TETOManager : MonoBehaviour
{
    public GameObject[] _Bloks = new GameObject[7];
    public float set_interval = 0;

    public static int w = 10;
    public static int h = 25;
    public static int z = 10;

    public static Transform[,,] grid = new Transform[w,h,z];

    GameObject pick_up = null;

    public static Vector3 roundVec3(Vector3 v)
    {
        return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
    }

    public static bool insideField(Vector3 v)
    {
        return ((int)v.x >= 0 && (int)v.x < w && (int)v.y >= 0 && (int)v.z >= 0 && v.z < z);
    }

    public static void DeleteSurface(int y)
    {
        for(int u = 0; u < w; u++)
        {
            for(int v = 0; v < z; v++)
            {
                Destroy(grid[u, y, v].gameObject);
                grid[u, y, v] = null;
            }
        }
    }

    public static void DecreaseSurface(int y)
    {
        for (int u = 0; u < w; u++)
        {
            for (int v = 0; v < z; v++)
            {
                if(grid[u, y + 1, v] != null)
                {
                    grid[u, y, v] = grid[u, y + 1, v];
                    grid[u, y + 1, v] = null;
                    grid[u, y, v].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public static void DecreaseSurfacesAbove(int y)
    {
        for(int i = y; i < h; i++)
        {
            DecreaseSurface(i);
        }
    }

    public static bool isSurfaceFull(int y)
    {
        for (int u = 0; u < w; u++)
        {
            for (int v = 0; v < z; v++)
            {
                if (grid[u, y, v] != null) return false;
            }
        }
        return true;
    }

    public static void DeleteFullSurface()
    {
        for (int i = 0; i < h; i++)
        {
            if (isSurfaceFull(i))
            {
                DeleteSurface(i);
                DecreaseSurface(i);
                i--;
            }
        }
    }


    // Use this for initialization
    void Start()
    {
        Generate_Blocks();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pick_up.GetComponent<BlockManager>().enabled)
        {
            Generate_Blocks();
        }
    }

    private void Generate_Blocks()
    {
        int _num = Random.Range(0, _Bloks.Length);
        Vector3 _initialposition = new Vector3(5,20f,05);

        pick_up = Instantiate(_Bloks[0], _initialposition, Quaternion.identity);
        pick_up.GetComponent<BlockManager>().interval = set_interval;
    }

}
