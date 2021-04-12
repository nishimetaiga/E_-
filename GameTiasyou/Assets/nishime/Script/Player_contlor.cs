using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_contlor : MonoBehaviour
{

    public float speedxz;           //プレイヤーの横の動きの速さ
    public float tyukan;            //プレイヤーの横の中間地点
    public float haba;              //横の限界値

    public GameObject boat;         //ボートオブジェクト
    public float rote;         //ボートの回転
    public float rote_speed;   //回転のスピード
    public float rote_max;     //回転の限界値

    private void Start()
    {
        tyukan = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        if (lsh < 0)
        {
            if (transform.position.x  >tyukan - haba)
            {

                if (rote < 190f)
                {
                    rote += rote_speed * Time.deltaTime;
                }
                transform.position -= transform.right * speedxz * Time.deltaTime;
            }

        }
        else if(lsh>0)
        {

            if (transform.position.x < tyukan + haba)
            {
                if (rote > 170f)
                {
                    rote -= rote_speed * Time.deltaTime;
                }
                transform.position += transform.right * speedxz * Time.deltaTime;
            }
        }
        else
        {
            if (rote< 180f)
            {
                rote += rote_speed * Time.deltaTime;
            }else if (rote > 180)
            {
                rote -= rote_speed * Time.deltaTime;
            }

        }

        boat.transform.rotation = Quaternion.Euler(-90f, 0f, rote);
    }
}
