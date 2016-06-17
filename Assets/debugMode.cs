using UnityEngine;
using System.Collections;

public class debugMode : MonoBehaviour {
#if UNITY_EDITOR
    void Start() {
        UnityEngine.SceneManagement.SceneManager.UnloadScene("SetUI");

    }
#endif
    // Use this for initialization


    // Update is called once per frame
    void Update() {

    }
}
