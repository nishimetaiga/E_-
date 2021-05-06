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

    public bool ba_flg = true;

    private int na = 0;
    public int starat;
    

    // Start is called before the first frame update
    void Start()
    {
        //ボートのオブジェクトのインスペクターのデータ入手
        barrage = GameObject.Find("Barrage");

        barrage_num = Random.Range(0, 5);
        // barrage_num = Random.Range(1);
    }



    public void barrage_wie()
    {



        if (barrge_flg == true)
        {
            

            na++;

            if (na == starat)
            {
                barrge_flg = false;
                barrage_num = Random.Range(0, 5);
                ba_flg = false;
                na = 0;
            }
            
            
        }
        //barrage_num++;
        //Debug.Log();

        switch (barrage_num)
        {
            case 0:
                barrage.GetComponent<barrage01>().barrage01_control();
                break;
            case 1:
                barrage.GetComponent<barrage02>().barrage02_control();
                break;

            case 2:
                barrage.GetComponent<barrage03>().barrage03_control();
                break;

            case 3:
                barrage.GetComponent<barrage04>().barrage04_control();
                break;

            case 4:
                barrage.GetComponent<Bullet4>().AttackControl();
                break;
        }
    }
}
