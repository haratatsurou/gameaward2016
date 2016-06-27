using UnityEngine;
using System.Collections;

public class callAudio : MonoBehaviour {

	void OnEnable () {
        AudioManager.Instance.PlayBGM("soundofdesign");
        AudioManager.Instance.GetComponent<AudioSource>( ).loop = true;
	}

}
