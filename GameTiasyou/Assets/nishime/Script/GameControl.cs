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

    //pause処理
    private GameObject pose_c;
    private bool flg_button7 = false;

    public int FPS;

    private void Start()
    {


        

        //ボートのオブジェクトのインスペクターのデータ入手
        boat = GameObject.Find("Boat_4");

        barrage = GameObject.Find("Barrage");

        pose_c = GameObject.Find("PauseUI");

        pose_c.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = FPS;
        Debug.Log(Application.targetFrameRate);
        if (Input.GetKeyDown("joystick button 7")&&flg_button7==false)
        {
            pose_c.SetActive(true);

            Time.timeScale = 0;
            flg_button7 = true;
        }
        else
        {
            flg_button7 = false;
        }


        if (Time.timeScale != 0)
        {
            
            //プレイヤーコントロール
            boat.GetComponent<Player_contlor>().Plyaer_Move();

            barrage.GetComponent<Barrage_control>().barrage_wie();

        }
        else if (Time.timeScale == 0)
        {
            pose_c.GetComponent<Pause_Control>().pose_con();
        }

    }

}
    
