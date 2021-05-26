using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_contlor : MonoBehaviour
{
    //プレイヤーの変数///////////////////////////////////////////////////////////////////////////////////

    private GameObject boat;     //2dのプレイヤーオブジェクト
    public GameObject[] Splash;  //水しぶき

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


    EffectedCollision effect;   // 爆発時のエフェクトを取り扱います


    GameControl gc;

    private void Start()
    {

        boat = GameObject.Find("Boat_4");
        Splash[0] = GameObject.Find("Splash01");
        Splash[1] = GameObject.Find("Splash02");
        Splash[2] = GameObject.Find("Splash03");

        effect = this.transform.GetComponent<EffectedCollision>();

        boatinit_z = boat.transform.position.z;
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

        if (roteflg == true)
        {
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
            boat.GetComponent<MeshRenderer>().enabled = false;
            Splash[0].GetComponent<ParticleSystem>().Stop();
            Splash[1].GetComponent<ParticleSystem>().Stop();
            Splash[2].GetComponent<ParticleSystem>().Stop();


            //Destroy(this.gameObject);

            // 爆発のエフェクトとSEを実行
            effect.GenerateExprosion();

            // リザルトシーンへ移動
            Invoke(nameof(GoResultScene), 1.2f);
        }
    }

    /// <summary>
    ///  リザルトシーンへ移動
    /// </summary>
    private void GoResultScene()
    {
        effect.InintExpflg();
        SceneManager.LoadScene("Result");
    }

}