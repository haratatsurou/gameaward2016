using UnityEngine;
using System.Collections;

public class startAudio : MonoBehaviour {

	void Start () {
        AudioManager.Instance.PlayBGM("soundofdesignOP");
        this.GetComponent<Animator>( ).enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
