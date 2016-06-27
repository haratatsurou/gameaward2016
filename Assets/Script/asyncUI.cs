using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class asyncUI : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
   public IEnumerator LoadScene() {

        AsyncOperation async = SceneManager.LoadSceneAsync(StageManager.Instance.nowstage.Reset_Scene_Name, LoadSceneMode.Single);
        AsyncOperation asyncUI = SceneManager.LoadSceneAsync("SetUI",LoadSceneMode.Additive);
        async.allowSceneActivation = false;    // シーン遷移をしない
        asyncUI.allowSceneActivation = false;
        while ( async.progress < 0.9f) {
            yield return new WaitForEndOfFrame( );
        }



        yield return new WaitForSeconds(1);

        async.allowSceneActivation = true;    // シーン遷移許可
        asyncUI.allowSceneActivation = true;

    }
}
