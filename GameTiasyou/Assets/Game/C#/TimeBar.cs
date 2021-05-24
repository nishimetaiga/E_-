using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    //制限時間変数
    private float time;
    //計算用変数
    private float time2;

    //Slider情報格納変数
    Slider timeSlider;


    void Start()
    {
        //制限時間を格納
        time = 30f;
        //計算用に制限時間を格納
        time2 = time;
        //Slider情報を格納
        timeSlider = GetComponent<Slider>();




        //スライダーの最大値の設定
        timeSlider.maxValue = time;

    }

    // Update is called once per frame
    void Update()
    {
        //時間を引いていく
        time2 -= Time.deltaTime;

        //スライダーの現在値の設定
        timeSlider.value = time2;

        //計算用の時間の数字が0より下になった時にクリアシーンに移動する
        if (time2 < 0)
        {
            SceneManager.LoadScene("Clear");
        }

    }
}
