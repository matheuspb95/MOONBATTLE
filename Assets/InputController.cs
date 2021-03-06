﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    Movement move;
    float x;
    // Use this for initialization
    void Start () {
        move = GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			move.Jump ();
		} else if (Input.GetButton ("Jump")) {
			move.MaintainJump();
		}

        x = Input.GetAxis("Horizontal");
		if (x != 0) {
			move.Walk (x);
			move.SetEmission (true);
		} else {
			move.SetEmission (false);
		}
        if (Input.GetButtonDown("Fire3"))
        {
            //move.Attack();
            move.StartCharge();
        }

        if (Input.GetButtonUp("Fire3"))
        {
            move.Attack();
        }
    }
}
