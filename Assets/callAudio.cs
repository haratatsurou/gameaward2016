using UnityEngine;
using System.Collections;

public class callAudio : MonoBehaviour {

	void Start () {
        AudioManager.Instance.PlayBGM("soundofdesign");
	}

}
