using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_material : MonoBehaviour {
    [SerializeField]
    Material material;

    [SerializeField]
    Color color;

	// Use this for initialization
	void Start () {
        ExtensionObject.Setmaterial(this.gameObject, material);
        ExtensionObject.SetmaterialColor(this.gameObject, color);
    }
}
