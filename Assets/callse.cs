using UnityEngine;
using System.Collections;

public class callse : MonoBehaviour {
    public string SeName;
    public string collidrename;
    void OnTriggerEnter(Collider rain) {
        if(rain.tag== collidrename ) {
            AudioManager.Instance.PlaySE(SeName);
        }
    }
    void Start() {
    }
}
