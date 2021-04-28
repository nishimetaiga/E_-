using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    //プレイヤーの変数///////////////////////////////////////////////////////////////////////////////////
    private GameObject boat;
    Player_contlor player = new Player_contlor();


    //弾幕変数　
    private GameObject barrage;



    private void Start()
    {
        //ボートのオブジェクトのインスペクターのデータ入手
        boat = GameObject.Find("Boat_4");

        barrage = GameObject.Find("Barrage");
            

    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {

            //プレイヤーコントロール
            boat.GetComponent<Player_contlor>().Plyaer_Move();

            barrage.GetComponent<Barrage_control>().barrage_wie();
        }

    }

}
    
