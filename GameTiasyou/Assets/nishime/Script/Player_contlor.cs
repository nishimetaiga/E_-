using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_contlor : MonoBehaviour
{
    //プレイヤーの変数///////////////////////////////////////////////////////////////////////////////////

    private GameObject boat;     //2dのプレイヤーオブジェクト
    private float Player3d_y;       //3dプレイヤーの高さの座標
    private Transform player_pos;   //プレイヤー位置変更に使う変数
    public float speed;              //プレイヤーの移動速度


    //プレイヤーの横範囲
    public float haba_x;
    public float haba_z;

    //プレイヤー初期値変数
    private float boatinit_z;


    public float rote;         //ボートの回転
    public float rote_speed;   //回転のスピード
    public float rote_max;     //回転の限界値

    GameControl gc;

    private void Start()
    {

        boat = GameObject.Find("Boat_4");

        boatinit_z=boat.transform.position.z;
        //Debug.Log(Playera.name);
        //Debug.Log(Playera.transform.position);

    }



    //プレイヤーコントロール関数
    public void Plyaer_Move()
    {
        bool roteflg = true;
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");



        if (lsh > 0)
        {

            if (rote < rote_max)
            {
                rote += rote_speed;

            }
            if (boat.transform.position.x < haba_x)
            {

                boat.transform.position += new Vector3(1 * speed, 0f, 0f);
            }
            roteflg = false;
        }
        else if (lsh < 0)
        {
            if (rote > -rote_max)
            {
                rote -= rote_speed;

            }
            if (boat.transform.position.x > -haba_x)
            {
                boat.transform.position -= new Vector3(1 * speed, 0f, 0f);
            }
            roteflg = false;
        }
        else if (lsv > 0)
        {
            if (boat.transform.position.z < haba_z + boatinit_z)
            {

                Debug.Log(boatinit_z);
                boat.transform.position += new Vector3(0f, 0f, 1 * speed);
            }

        }
        else if (lsv < 0)
        {
            if (boat.transform.position.z > -haba_z + boatinit_z)
            {

                boat.transform.position -= new Vector3(0f, 0f, 1 * speed);
            }
        }

        if (roteflg == true) {
            if (rote < 0f)
            {
                rote += rote_speed;
            }
            else if (rote > 0)
            {
                rote -= rote_speed;
            }
        }
    
        boat.transform.rotation = Quaternion.Euler(-90, 0f, rote);
    }

    //衝突判定
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "danmaku")
        {
            SceneManager.LoadScene("Result");
            //Destroy(this.gameObject);
        }
    }
    //    //プレイヤー移動
    //    if (lsh > 0)
    //    {

    //        if (Playera.transform.position.x < 74)
    //        {
    //            //2dプレイヤー移動
    //           Playera.transform.position+= new Vector3(speed * gc.uu, 0f, 0f);
    //    if (rote < 10f)
    //    {
    //        rote += rote_speed;
    //    }
    //        }
    //    }
    //    else if (lsh < 0)
    //    {

    //        if (Playera.transform.position.x > -74)
    //        {
    //            //2dプレイヤー移動
    //            Playera.transform.position -= new Vector3(speed * gc.uu, 0f, 0f);


    //            //if (rote > -10f)
    //            //{
    //            //    rote -= rote_speed;
    //            //}
    //        }
    //    }
    //    else
    //    {
    //        if (rote < 0f)
    //        {
    //            rote += rote_speed;
    //        }
    //        else if (rote > 0)
    //        {
    //            rote -= rote_speed;
    //        }

    //    }

    //    //2d側のプレイヤーの位置をコピー
    //    Vector3 Player2d = this.transform.position;

    //    //3d側のプレイヤーの移動
    //    Playera.transform.position = new Vector3(Player2d.x, Player3d_y, Player2d.y);
    //    Playera.transform.rotation = Quaternion.Euler(-90, 0f, rote);
    //}
}
