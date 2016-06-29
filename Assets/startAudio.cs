using UnityEngine;
using System.Collections;

public class startAudio : MonoBehaviour
{

    void Start()
    {
        AudioManager.Instance.PlayBGM("intro");
        AudioManager.Instance.GetComponent<AudioSource>( ).loop = true;
        this.GetComponent<Animator>().enabled = true;
        AudioManager.Instance.GetComponent<AudioSource>( ).volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
