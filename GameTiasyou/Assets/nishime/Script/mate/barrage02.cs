using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrage02 : MonoBehaviour
{
    public GameObject d2;

    private GameObject barrage;
    private GameObject boat;

    private bool seisei = true;



    private bool flg=true;

    private int des;
    public int _des;

    public int count=0;
    private void Start()
    {
        barrage = GameObject.Find("Barrage");
        boat = GameObject.Find("Boat_4");

       
    }

    //弾幕の処理管理関数
    public void barrage02_control()
    {
        output();
        des++;
        if (des > _des)
        {
            des = 0;

            seisei = true;
        }
    }

    public void output()
    {
        if (barrage.GetComponent<Barrage_control>().barrge_flg == false)
        {
            if (seisei == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    //生成
                    Instantiate(d2, new Vector3((barrage.transform.position.x - 40) + 20 * i, barrage.transform.position.y, barrage.transform.position.z),
                                                  Quaternion.Euler(0, 0, 0));
                }
                seisei = false;
                count++;
            }
            if (count == 5)
            {
                count = 0;
                barrage.GetComponent<Barrage_control>().barrge_flg = true;
            }
            seisei = false;

        }
    }
}
