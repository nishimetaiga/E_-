using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrage04 : MonoBehaviour
{
    public GameObject d2;
    public List<GameObject> danmaku04;

    private GameObject barrage;
    private GameObject boat;

    private bool seisei = true;
   

    private int des;
    public int _des;


    public int count=0;

    public int obj_count;
    public int dead_count = 0;

    private void Start()
    {
        barrage = GameObject.Find("Barrage");
        boat = GameObject.Find("Boat_4");

       
    }

    //弾幕の処理管理関数
    public void barrage04_control()
    {
        output();
        d4_put();

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
                danmaku04.Add(Instantiate(d2, new Vector3(barrage.transform.position.x, barrage.transform.position.y, barrage.transform.position.z - 30),
                                              Quaternion.Euler(0, 0, 0)));
                obj_count++;
                count++;

            }
            if (count == 3)
            {
                count = 0;
                barrage.GetComponent<Barrage_control>().barrge_flg = true;
            }
            seisei = false;

        }
    }

    public void d4_put()
    {
        for (int i = dead_count; i < obj_count; i++)
        {
            danmaku04[i].GetComponent<b_4>().move();
        }
    }
}
