using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrage01 : MonoBehaviour
{
    public GameObject d1;
    public List<GameObject> danmaku01;

    public GameObject barrage;

    private bool seisei = true;


    private int des;
    public int _des;

    public int obj_count;
    public int count = 0;
    public int dead_count = 0;

    private void Start()
    {
        barrage = GameObject.Find("Barrage");
        obj_count = 0;
    }

    //弾幕の処理管理関数
    public void barrage01_control()
    {
        output();
        d1_put();
        

    }

    public void output()
    {
        if (seisei == false)
        {
            des++;
        }
        
        if (des > _des)
        {
            des = 0;

            seisei = true;
        }

        if (barrage.GetComponent<Barrage_control>().barrge_flg == false)
        {
            if (count == 7)
            {

                count = 0;
                barrage.GetComponent<Barrage_control>().barrge_flg = true;
            }

            if (seisei == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    //生成
                   danmaku01.Add(Instantiate(d1, barrage.transform.position,
                                                  Quaternion.Euler(0, (180 / (10 - Random.Range(0, 3))) * i - 90, 7)));
                    obj_count++;
                   
                }
                seisei = false;
                count++;
            }
        }
    }


    public void d1_put()
    {
        for(int i= dead_count; i < obj_count; i++)
        {
            danmaku01[i].GetComponent<b_1>().move();
        }
    }
}


