﻿using UnityEngine;
using System.Collections;

public class deleate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit(Collider all) {
        Destroy(all.gameObject);
    }
}
