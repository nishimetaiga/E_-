using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage_control : MonoBehaviour
{

    //弾幕種類０１
    GameObject barrage;
    barrage01 bar1 = new barrage01();

    //弾幕選定
    public int barrage_num;
    //弾幕終了フラグ
    public bool barrge_flg=true;

    // Start is called before the first frame update
    void Start()
    {
        //ボートのオブジェクトのインスペクターのデータ入手
        barrage = GameObject.Find("Barrage");
    }



    public void barrage_wie()
    {
        switch (barrage_num)
        {
            case 0:
                barrage.GetComponent<barrage01>().barrage01_control();
                break;
        }
    }
}
