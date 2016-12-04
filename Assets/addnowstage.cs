using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class addnowstage : MonoBehaviour {
    private CreateButton createbutton;
    void OnEnable() {
        var stagemanager = StageManager.Instance;
        stagemanager.oldstar = stagemanager.nowstage.GetStar;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        createbutton = GameObject.Find("system").GetComponent<CreateButton>( );
        createbutton.endINS( );
        for ( int i = 0 ; i < StageManager.Instance.nowstage.setitem.Length ; i++ )
        {
            StageManager.Instance.nowstage.setitem[i].SET_ITEM_FLAG = false;
        }
        SceneManager.sceneLoaded += hoge;
    }

    private void On(Scene arg0 , LoadSceneMode arg1) {
        throw new System.NotImplementedException( );
    }
    void hoge(Scene hoge2,LoadSceneMode hoge) {
        var stagemanager = StageManager.Instance;
        stagemanager.oldstar = stagemanager.nowstage.GetStar;
        stagemanager.nowstage = stagemanager.stageinfo[stagemanager.NowtheStage( )];
        createbutton.endINS( );
        print("ロードscene="+hoge2.name);

    }
}
