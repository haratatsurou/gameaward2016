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
            .Subscribe(_ => { print("ゴール是よ"); });


    }
    void hoge()
    {
        int i = 0;

        var goal = this.OnTriggerEnterAsObservable()
            .Where(goaltag => goaltag.tag == "rain")
            .Subscribe(_ => {
                i++;
                count.text = i.ToString();
            });
    }
}
