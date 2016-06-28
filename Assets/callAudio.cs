using UnityEngine;
using System.Collections;

public class callAudio : MonoBehaviour {

	void OnEnable () {
        AudioManager.Instance.PlayBGM("play");
        var bgm=AudioManager.Instance.GetComponent<AudioSource>( );
        bgm.loop = true;
        bgm.volume = 0.2f;
	}

}
