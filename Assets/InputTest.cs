using UnityEngine;
using System.Collections;
using System;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var Keys = Enum.GetValues(typeof(KeyCode));
        foreach(KeyCode k in Keys)
        {
            if (Input.GetKeyDown(k))
            {
                Debug.Log(k.ToString());
            }
        }
	}
}
