using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;
using UniRx.Triggers;

public class Goal : MonoBehaviour
{
    public int n = 10;
    private Text count;
    void Start()
    {
        count = GameObject.Find("Canvas/Text").GetComponent<Text>();
        CountGoal();
        hoge();
    }
    void CountGoal()
    {
        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain");
        goal
            .Buffer(n)
            .FirstOrDefault()
            .Subscribe(_ => { print("終わり"); });


    }
    void hoge()
    {
        int i = 0;

        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(_ => {
                i++;
                count.text = "触れた回数="+i.ToString()+"回";
            });
    }
}
