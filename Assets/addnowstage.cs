using UnityEngine;
using System.Collections;

public class addnowstage : MonoBehaviour {
    void Awake() {
        var stagemanager =StageManager.Instance;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
    }
}
