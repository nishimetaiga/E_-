using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{

    private float time;

    private float time2;//計算用


    Slider timeSlider;


    // Use this for initialization
    void Start()
    {
        time = 30f;
        time2 = time;
        //timer = GameObject.Find("Time").GetComponent<Text>();

        timeSlider = GetComponent<Slider>();




        //スライダーの最大値の設定
        timeSlider.maxValue = time;

    }

    // Update is called once per frame
    void Update()
    {
        time2 -= Time.deltaTime;

        //timer.text = "Time:" + (time2 > 0f ? time2.ToString("0.00") : "0.00");

        //スライダーの現在値の設定
        timeSlider.value = time2;

    }
}
