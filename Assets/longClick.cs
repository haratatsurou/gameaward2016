using UnityEngine;
using System.Collections;
using UniRx;

public class longClick : MonoBehaviour {

    #region 長押しストリーム
    public Subject<Unit> longClickSubject = new Subject<Unit>( );

    IObservable<Unit> LongClickAsObservable {
        get {
            return longClickSubject.AsObservable( );
        }
    }
    #endregion

    #region 長押しキャンセルストリーム
    public Subject<float> longClickCancelSubject = new Subject<float>( );

    IObservable<float> LongClickCancelAsObservable {
        get {
            return longClickCancelSubject.AsObservable( );
        }
    }

    #endregion

    Coroutine longClickCoroutine;

    void Start() {
        longClickCoroutine = StartCoroutine(LongClickCoroutine(3.0f , longClickSubject , longClickCancelSubject));

        LongClickAsObservable.Subscribe(_ => Debug.Log("長押し"));
        LongClickCancelAsObservable.Subscribe(t => Debug.Log(t + "秒でキャンセル"));

    }

    /// <summary>
    /// 長押し判定コルーチン
    /// </summary>
    public IEnumerator LongClickCoroutine(float threshold , IObserver<Unit> longClickObserver , IObserver<float> longClickCancelObserver) {
        var isLongClicked = false; //長押しのOnNext発行済か
        var count = 0.0f;

        while ( true ) {
            if ( Input.GetMouseButton(0) ) {
                count += Time.deltaTime;
                if ( !isLongClicked && count > threshold ) {
                    isLongClicked = true;
                    longClickObserver.OnNext(Unit.Default);
                }
            } else if ( Input.GetMouseButtonUp(0) ) {
                isLongClicked = false;
                if ( count > 0 ) {
                    longClickCancelObserver.OnNext(count);
                    count = 0;
                }
            }
            yield return null;

        }
    }


    void OnDestroy() {
        if ( longClickCoroutine != null )
            StopCoroutine(longClickCoroutine);
    }
}

