using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class sampleload : MonoBehaviour {

	void OnEnable () {
        var button = GameObject.Find("Canvas/1/Text").GetComponent<Text>();
        try {
            button.text = SaveManager.Instance.saveinfo["Stage1"].clear.ToString( );
        } catch (KeyNotFoundException){
            button.text = "";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
