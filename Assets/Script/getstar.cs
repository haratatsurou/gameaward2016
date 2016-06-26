using UnityEngine;
using System.Collections;
using System;

public class getstar : MonoBehaviour {
    void OnTriggerEnter(Collider rain) {
        if ( rain.tag == "rain" ) {
            Destroy(this.gameObject,0.5f);
        }
    }
    void OnDestroy() {
        try {
            StageManager.Instance.nowstage.GetStar++;
        } catch ( NullReferenceException ) {

        }
    }
}
