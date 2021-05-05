using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    [HideInInspector]
    public float interval = 0;

    [SerializeField]
    private float offset_x = 0;
    [SerializeField]
    private float offset_y = 0;
    [SerializeField]
    private float offset_z = 0;

    float time;

    private bool isValidField()
    {
        foreach(Transform child in transform)
        {
            Vector3 v = TETOManager.roundVec3(child.position);
            Debug.Log(child.position);

            if (!TETOManager.insideField(v)) return false;

            if (TETOManager.grid[(int)v.x, (int)v.y, (int)v.z] != null &&
                TETOManager.grid[(int)v.x, (int)v.y, (int)v.z].parent != transform) return false;
        }

        return true;
    }

    private void UpdateGrid()
    {
        for (int z = 0; z < TETOManager.z; ++z)
            for (int y = 0; y < TETOManager.h; ++y)
                for (int x = 0; x < TETOManager.w; ++x)
                    if (TETOManager.grid[x, y, z] != null)
                        if (TETOManager.grid[x, y, z].parent == transform)
                            TETOManager.grid[x, y, z] = null;

        foreach (Transform child in transform)
        {
            Vector3 v = TETOManager.roundVec3(child.position);
            TETOManager.grid[(int)v.x, (int)v.y, (int)v.z] = child;
        }
    }


    void Start()
    {
        time = 0;
    }

    void Update()
    {
        //up/down/left/right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-1, 0, 0);
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, 1);
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 0, -1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, 0, -1);
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 0, 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(0, 0, 1));
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(0, 0, -1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(-1, 0, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(0, 0, -1));
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(0, 0, 1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(-1, 0, 0));
            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.AngleAxis(90f, new Vector3(1, 0, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || (Time.time - time >= 1))
        {
            gameObject.transform.position += new Vector3(0, -1, 0);

            if (isValidField())
            {
                UpdateGrid();
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 1, 0);

                //ライン判定処理

                //次のブロック生成

                enabled = false;

            }

            time = Time.time;
        }
    }
	
}
