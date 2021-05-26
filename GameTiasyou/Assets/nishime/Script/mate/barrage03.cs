using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrage03 : MonoBehaviour
{
    public GameObject d2;

    private GameObject barrage;
    private GameObject boat;

    public List<GameObject> danmaku03;

    private bool seisei = true;

    public int count=0;

    public int obj_count;
    public int dead_count = 0;

    private bool flg=true;

    private int des;
    public int _des;

    private void Start()
    {
        barrage = GameObject.Find("Barrage");
        boat = GameObject.Find("Boat_4");

       
    }

    //弾幕の処理管理関数
    public void barrage03_control()
    {
        output();
        d3_put();
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
            if (seisei == true)
            {

                //生成
                danmaku03.Add(Instantiate(d2, new Vector3(barrage.transform.position.x, barrage.transform.position.y, barrage.transform.position.z - 50),
                                              Quaternion.Euler(0, 0, 0)));

                obj_count++;
                count++;
            }
            if (count == 500)
            {
                count = 0;
                barrage.GetComponent<Barrage_control>().barrge_flg = true;
            }
            seisei = false;

        }
    }


    public void d3_put()
    {
        for (int i = dead_count; i < obj_count; i++)
        {
            danmaku03[i].GetComponent<b_3>().move();
        }
    }
}
