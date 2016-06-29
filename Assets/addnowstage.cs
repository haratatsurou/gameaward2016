using UnityEngine;
using System.Collections;

public class addnowstage : MonoBehaviour {
    void OnLevelWasLoaded() {
        var stagemanager =StageManager.Instance;
        stagemanager.oldstar= stagemanager.nowstage.GetStar;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        this.GetComponent<CreateButton>( ).endINS( );
        print("ロードscene");
        
    }
    void OnEnable() {
        var stagemanager = StageManager.Instance;
        stagemanager.oldstar = stagemanager.nowstage.GetStar;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        this.GetComponent<CreateButton>( ).endINS( );
        for ( int i = 0 ; i < 3 ; i++ )
        {
            StageManager.Instance.nowstage.setitem[i].SET_ITEM_FLAG = false;
        }
    }
}
