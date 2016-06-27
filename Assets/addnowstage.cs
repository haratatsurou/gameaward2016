using UnityEngine;
using System.Collections;

public class addnowstage : MonoBehaviour {
    void OnEnable() {
        var stagemanager =StageManager.Instance;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        this.GetComponent<CreateButton>( ).endINS( );
        stagemanager.oldstar= stagemanager.nowstage.GetStar;
    }
}
