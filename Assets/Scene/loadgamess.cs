﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loadgamess : MonoBehaviour {

	void Start () {
        FadeManager.Instance.LoadLevel("StartMenu" , 3f);
	}
	
	void Update () {
	
	}
}
