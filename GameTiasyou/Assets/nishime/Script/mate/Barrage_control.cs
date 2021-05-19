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
    public int backup_num;
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
     //barrage_num = 4;
        backup_num = barrage_num;
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
                barrage_num = 4;
                
                //if (barrage_num == backup_num)
                //{
                //    backup_num = barrage_num;
                //}
                //barrage_num = 3;
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


        if (barrage_num != backup_num)
        {
            switch (backup_num)
            {
                case 0:
                    barrage.GetComponent<barrage01>().d1_put();
                    break;
                case 1:
                    barrage.GetComponent<barrage02>().d2_put();
                    break;

                case 2:
                    barrage.GetComponent<barrage03>().d3_put();
                    break;

                case 3:
                    barrage.GetComponent<barrage04>().d4_put();
                    break;

                case 4:
                    barrage.GetComponent<Bullet4>().AttackControl();
                    break;

            }
        }
    }
}
