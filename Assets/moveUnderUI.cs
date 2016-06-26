using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
public class moveUnderUI : MonoBehaviour {
    public void Down() {
        var DownUI = this.UpdateAsObservable( )
            .Subscribe(_ => {
                var time = Time.deltaTime;
                transform.localPosition -= Vector3.up * time *75f;
            });
        var StopMove = this.UpdateAsObservable( )
            .Where(pos => transform.localPosition.y < -750)
            .FirstOrDefault()
            .Subscribe(_ => {
                DownUI.Dispose( );
            });
    }
    void Start() {
        Down( );
    }
}
