using UnityEngine;
using System.Collections;

public class addnowstage : MonoBehaviour {
    void OnEnable() {
        var stagemanager =StageManager.Instance;
        stagemanager.oldstar= stagemanager.nowstage.GetStar;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        this.GetComponent<CreateButton>( ).endINS( );
        
    }
}
