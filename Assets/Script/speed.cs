using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System;

public class speed : MonoBehaviour
{
    private Button speedbutton;
    private Image speedImage;
    public Sprite image1, iamge2;

    void Start()
    {
        speedbutton = GameObject.Find("UI/Top/speed").GetComponent<Button>();
        speedImage = GameObject.Find("UI/Top/speed").GetComponent<Image>( );
        speedbutton.onClick.AsObservable()
           .Subscribe(_ =>
           {
               var longtap = GameObject.Find("Main Camera").GetComponent<SetRotation>();

               if (Time.timeScale == 1)
               {
                   StageManager.Instance.worldTime = 2;
                   Time.timeScale = StageManager.Instance.worldTime;
                   speedImage.sprite = image1;
                   longtap.longTap = 0.6f;
               }
               else if (Time.timeScale == 2)
               {
                   StageManager.Instance.worldTime = 1;
                   Time.timeScale = StageManager.Instance.worldTime;
                   speedImage.sprite = iamge2;
                   longtap.longTap = 0.3f;
               }
           });
    }
}
