using UnityEngine;
using System.Collections;

public class startAudio : MonoBehaviour
{

    void Start()
    {
        AudioManager.Instance.PlayBGM("soundofdesignOP");
        this.GetComponent<Animator>().enabled = true;
        InvokeRepeating("loopBGM", AudioManager.Instance.PlayBGMLength("soundofdesignOP")+2, AudioManager.Instance.PlayBGMLength("soundofdesignOP"));
    }
    void loopBGM()
    {
	    Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
