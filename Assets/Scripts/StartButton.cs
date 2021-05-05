using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    public GameObject obj;

    void Start()
    {
        
    }

    public void OnClick()
    {
        gameObject.SetActive(false);

        obj.SetActive(true);

    }
}
