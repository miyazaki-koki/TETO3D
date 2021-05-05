using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionObject{

    public static void Setlayer(this GameObject obj, int layer_num, bool set_child = true)
    {
        if (obj == null)
        {
            return;
        }

        obj.layer = layer_num;

        if (!set_child)
        {
            return;
        }

        foreach(Transform ch in obj.transform)
        {
            Setlayer(ch.gameObject, layer_num, set_child);
        }
    }

    public static void Setmaterial(this GameObject obj, Material material, bool set_child = true)
    {
        if (obj == null)
        {
            return;
        }

        if (obj.GetComponent<Renderer>())
        {
            obj.GetComponent<Renderer>().material = material;
        }

        if (!set_child)
        {
            return;
        }

        foreach (Transform ch in obj.transform)
        {
            Setmaterial(ch.gameObject, material, set_child);
        }
    }

    public static void SetmaterialColor(this GameObject obj, Color _color, bool set_child = true)
    {
        if (obj == null)
        {
            return;
        }

        if (obj.GetComponent<Renderer>())
        {
            obj.GetComponent<Renderer>().material.color = _color; //shader named _Color into property
        }

        if (!set_child)
        {
            return;
        }

        foreach(Transform ch in obj.transform)
        {
            SetmaterialColor(ch.gameObject, _color, set_child);
        }

    }

}
