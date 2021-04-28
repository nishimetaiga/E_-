using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrage01 : MonoBehaviour
{

    public GameObject[] danmakutype3d;  //インスタンス化する3dの弾幕データ

    public GameObject barrage;

    private bool[] barrage_flg = new bool[6] { true, false, false, false, false, false };      //弾幕コントロールフラグ

    private bool[] instans_flg = new bool[6] { true, true, true, true, true, true };    //生成するフラグ
    private bool[] instans_flg_back = new bool[6] { true, true, true, true, true, true };   //最初に生成された弾幕にくっつく弾幕の生成するフラグ

    private bool[] moveflg = new bool[6] { true, true, true, true, true, true };  //移動フラグ

    private bool init_flg = false;

    [Header("くっついている弾幕を生成する位置")]
    public float barrage_x;
    [Header("消す位置")]
    public float _barrage_x;

    //次の列の弾幕の生成距離
    public float b_x;

    //弾幕のスピード
    public float speed;

    //弾幕合計
    public int[] total;

    //最初の弾幕
    public GameObject[] attack01;


    //最初の弾幕の後ろにくっつける弾幕
    public GameObject[] attack01_back;



    //最初の弾幕
    private GameObject[] attack02;
    //最初の弾幕の後ろにくっつける弾幕
    private GameObject[] attack02_back;

    //弾幕生成hennsuu
    //最初の弾幕
    private GameObject[] attack03;
    //最初の弾幕の後ろにくっつける弾幕
    private GameObject[] attack03_back;

    //弾幕生成hennsuu
    //最初の弾幕
    private GameObject[] attack04;
    //最初の弾幕の後ろにくっつける弾幕
    private GameObject[] attack04_back;

    //弾幕生成hennsuu
    //最初の弾幕
    private GameObject[] attack05;
    //最初の弾幕の後ろにくっつける弾幕
    private GameObject[] attack05_back;

    //弾幕生成hennsuu
    //最初の弾幕
    private GameObject[] attack06;
    //最初の弾幕の後ろにくっつける弾幕
    private GameObject[] attack06_back;

    [Header("弾幕の列の種類の最大要素")]
    public int total_Nuber;
    [Header("弾幕の列の弾幕の最大要素数")]
    public int total_count;



    //totalの要素数
    public int Number;



    private void Start()
    {
        barrage= GameObject.Find("Barrage");

        attack01 = new GameObject[total[0]];
        attack01_back = new GameObject[total[0]];

        attack03 = new GameObject[total[0]];
        attack03_back = new GameObject[total[0]];

        attack05 = new GameObject[total[0]];
        attack05_back = new GameObject[total[0]];

        attack02 = new GameObject[total[1]];
        attack02_back = new GameObject[total[1]];

        attack04 = new GameObject[total[1]];
        attack04_back = new GameObject[total[1]];

        attack06 = new GameObject[total[1]];
        attack06_back = new GameObject[total[1]];


        Number = 0;


    }
    //弾幕の処理管理関数
    public void barrage01_control()
    {
        if (barrage_flg[0] == true)
        {
            //弾幕生成
            barrage01_Output();
            //弾幕移動
            barrage01_Move();
        }
        if (barrage_flg[1] == true)
        {
            //弾幕生成
            barrage02_Output();
            //弾幕移動
            barrage02_Move();
        }

        if (barrage_flg[2] == true)
        {
            //弾幕生成
            barrage03_Output();
            //弾幕移動
            barrage03_Move();
        }

        if (barrage_flg[3] == true)
        {
            //弾幕生成
            barrage04_Output();
            //弾幕移動
            barrage04_Move();
        }

        if (barrage_flg[4] == true)
        {
            //弾幕生成
            barrage05_Output();
            //弾幕移動
            barrage05_Move();
        }

        if (barrage_flg[5] == true)
        {
            //弾幕生成
            barrage06_Output();
            //弾幕移動
            barrage06_Move();
        }


        if (init_flg == true)
        {
            //初期化
            barrage01_init();
            barrage.GetComponent<Barrage_control>().barrge_flg = true;
        }




    }
    void barrage01_init()
    {
        barrage_flg = new bool[6] { true, false, false, false, false, false };      //弾幕コントロールフラグ
        instans_flg = new bool[6] { true, true, true, true, true, true };    //生成するフラグ
        instans_flg_back = new bool[6] { true, true, true, true, true, true };   //最初に生成された弾幕にくっつく弾幕の生成するフラグ

        moveflg = new bool[6] { true, true, true, true, true, true };  //移動フラグ

        init_flg = false;

    }

    //弾幕を生成する処理
    void barrage01_Output()
    {

        //生成する処理
        if (instans_flg[0] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack01[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[0] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[0] == true) && (attack01[0].transform.position.x < -barrage_x + barrage.transform.position.x))
        {
            for (int i = 0; i < total[0]; i++)
            {

                //生成
                attack01_back[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[0] = false;
        }


    }

    //弾幕の移動処理
    void barrage01_Move()
    {

        if (moveflg[0] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack01[i].transform.position += attack01[i].transform.forward * speed;

                if (attack01[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack01)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[0] = false;
                    break;
                }
            }
            if (attack01[0].transform.position.x < -b_x + barrage.transform.position.x)
            {
                barrage_flg[1] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[0] == false)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack01_back[i].transform.position += attack01_back[i].transform.forward * speed;



                if (attack01_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack01_back)
                    {
                        Destroy(bar);
                    }
                    instans_flg_back[0] = true;
                    moveflg[0] = true;

                    instans_flg[0] = true;
                    barrage_flg[0] = false; 
                    

                    break;
                }
            }

        }


    }


    //弾幕を生成する処理
    void barrage02_Output()
    {

        //生成する処理
        if (instans_flg[1] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack02[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[1] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[1] == true) && (attack02[0].transform.position.x < -barrage_x + barrage.transform.position.x))
        {
            for (int i = 0; i < total[1]; i++)
            {

                //生成
                attack02_back[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[1] = false;
        }


    }

    //弾幕の移動処理
    void barrage02_Move()
    {

        if (moveflg[1] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack02[i].transform.position += attack02[i].transform.forward * speed;

                if (attack02[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack02)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[1] = false;
                    break;
                }
            }
            if (attack02[0].transform.position.x < -b_x + barrage.transform.position.x)
            {
                barrage_flg[2] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[1] == false)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack02_back[i].transform.position += attack02_back[i].transform.forward * speed;



                if (attack02_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack02_back)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);
                    instans_flg_back[1] = true;
                    barrage_flg[1] = false;

                    instans_flg[1] = true;
                    moveflg[1] = true;

                   
                    
                    break;
                }
            }

        }


    }


    //弾幕を生成する処理
    void barrage03_Output()
    {

        //生成する処理
        if (instans_flg[2] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack03[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[2] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[2] == true) && (attack03[0].transform.position.x < -barrage_x + barrage.transform.position.x))
        {
            for (int i = 0; i < total[0]; i++)
            {

                //生成
                attack03_back[i] = Instantiate(danmakutype3d[0],
                                            barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[2] = false;
        }


    }

    //弾幕の移動処理
    void barrage03_Move()
    {

        if (moveflg[2] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack03[i].transform.position += attack03[i].transform.forward * speed;

                if (attack03[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack03)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[2] = false;
                    break;
                }
            }
            if (attack03[0].transform.position.x < -b_x + barrage.transform.position.x)
            {
                barrage_flg[3] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[2] == false)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack03_back[i].transform.position += attack03_back[i].transform.forward * speed;



                if (attack03_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack03_back)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);
                    instans_flg_back[2] = true;
                    barrage_flg[2] = false;

                    instans_flg[2] = true;
                    moveflg[2] = true;
                    break;
                }
            }

        }


    }

    void barrage04_Output()
    {

        //生成する処理
        if (instans_flg[3] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack04[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[3] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[3] == true) && (attack04[0].transform.position.x < -barrage_x + barrage.transform.position.x))
        {
            for (int i = 0; i < total[1]; i++)
            {

                //生成
                attack04_back[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[3] = false;
        }


    }

    //弾幕の移動処理
    void barrage04_Move()
    {

        if (moveflg[3] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack04[i].transform.position += attack04[i].transform.forward * speed;

                if (attack04[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack04)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[3] = false;
                    break;
                }
            }
            if (attack04[0].transform.position.x < -b_x + barrage.transform.position.x)
            {
                barrage_flg[4] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[3] == false)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack04_back[i].transform.position += attack04_back[i].transform.forward * speed;



                if (attack04_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack04_back)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);
                    instans_flg_back[3] = true;
                    barrage_flg[3] = false;


                    instans_flg[3] = true;
                    moveflg[3] = true;
                    break;
                }
            }

        }


    }

    void barrage05_Output()
    {

        //生成する処理
        if (instans_flg[4] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack05[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[4] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[4] == true) && (attack05[0].transform.position.x < -barrage_x+ barrage.transform.position.x))
        {
            for (int i = 0; i < total[0]; i++)
            {

                //生成
                attack05_back[i] = Instantiate(danmakutype3d[0],
                                            barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[0] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[4] = false;
        }


    }

    //弾幕の移動処理
    void barrage05_Move()
    {

        if (moveflg[4] == true)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack05[i].transform.position += attack05[i].transform.forward * speed;

                if (attack05[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack05)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[4] = false;
                    break;
                }
            }
            if (attack05[0].transform.position.x < -b_x + barrage.transform.position.x + barrage.transform.position.x)
            {
                barrage_flg[5] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[4] == false)
        {
            for (int i = 0; i < total[0]; i++)
            {
                //弾幕いどう
                attack05_back[i].transform.position += attack05_back[i].transform.forward * speed;



                if (attack05_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack05_back)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);
                    instans_flg_back[4] = true;
                    barrage_flg[4] = false;

                    instans_flg[4] = true;
                    moveflg[4] = true;
                    break;
                }
            }

        }


    }

    void barrage06_Output()
    {

        //生成する処理
        if (instans_flg[5] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                Debug.Log(total[0]);
                //生成
                attack06[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));
            }

            //生成を止める
            instans_flg[5] = false;
        }



        //あとから生成する処理 _
        if ((instans_flg_back[5] == true) && (attack06[0].transform.position.x < -barrage_x + barrage.transform.position.x))
        {
            for (int i = 0; i < total[1]; i++)
            {

                //生成
                attack06_back[i] = Instantiate(danmakutype3d[0],
                                             barrage.transform.position,
                                               Quaternion.Euler(0, (180 / (total[1] - 1)) * i - 90, 0));


            }
            //生成を止める
            instans_flg_back[5] = false;
           
        }


    }

    //弾幕の移動処理
    void barrage06_Move()
    {

        if (moveflg[5] == true)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack06[i].transform.position += attack06[i].transform.forward * speed;

                if (attack06[0].transform.position.x < -_barrage_x+ barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack06)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);

                    moveflg[5] = false;
                    break;
                }
            }
            if (attack06[0].transform.position.x < -b_x + barrage.transform.position.x + barrage.transform.position.x)
            {
                barrage_flg[0] = true;
            }
        }

        // if (attack01[0][0] > 0) { }

        if (instans_flg_back[5] == false)
        {
            for (int i = 0; i < total[1]; i++)
            {
                //弾幕いどう
                attack06_back[i].transform.position += attack06_back[i].transform.forward * speed;



                if (attack06_back[0].transform.position.x < -_barrage_x + barrage.transform.position.x)
                {

                    foreach (GameObject bar in attack06_back)
                    {
                        Destroy(bar);
                    }
                    Debug.Log(0);
                    instans_flg[5] = true;
                    barrage_flg[5] = false;

                    instans_flg_back[5] = true;
                    moveflg[5] = true;
                    //init_flg = true;
                    break;
                }
            }

        }


    }
}
//弾幕攻撃01
//    void danmaku_attack01()
//    {
//        if (instans_flg == true)
//        {  //弾幕を一度だけ生成する
//            //プレハブ生成
//            PrefabDraw01();

//            //インスタンス生成フラグをfalseにする
//            instans_flg = false;
//        }

//        //弾幕の移動1番目
//        if (attack01_01[0].transform.position.x > 150f)
//        {
//            //弾幕の初期化
//            danmaku01_init();

//        }
//        else if (order[0] == true)
//        {
//            //弾幕の移動１番目
//            danmaku01_idou01();

//        }


//        //弾幕の移動2番目
//        if (attack01_02[0].transform.position.x > 150f)
//        {
//            danmaku02_init();
//        }
//        if (order[1] == true)
//        {
//            //弾幕の移動二番目
//            danmaku01_idou02();
//        }
//        else if ((attack01_01[0].transform.position.x > 50f) && (order[1] == false))
//        {
//            order[1] = true;
//        }

//        //弾幕の移動3番目
//        if (attack01_03[0].transform.position.x > 150f)
//        {
//            danmaku03_init();
//        }
//        else if (order[2] == true)
//        {
//            //弾幕の移動二番目
//            danmaku01_idou03();
//        }
//        else if ((attack01_02[0].transform.position.x > 50f) && (order[2] == false))
//        {
//            order[2] = true;
//        }




//        //弾幕の移動関数一番目
//        void danmaku01_idou01()
//        {
//            for (int i = 0; i < 11; i++)
//            {
//                //一番目の弾幕移動
//                attack01_01[i].transform.position += attack01_01[i].transform.up * danmaku_speed * uu;

//                Vector3 iti = attack01_01[i].transform.position;
//                attack3d01_01[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

//            }

//            //最初の弾幕についていく弾幕
//            if (10 < attack01_01[0].transform.position.x)
//            {
//                for (int i = 0; i < 11; i++)
//                {
//                    attack01_01[i + 11].transform.position += attack01_01[i + 11].transform.up * danmaku_speed * uu;

//                    Vector3 iti = attack01_01[i + 11].transform.position;
//                    attack3d01_01[i + 11].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

//                }
//            }
//        }


//        //弾幕の移動関数二番目
//        void danmaku01_idou02()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                //二番目の弾幕移動
//                attack01_02[i].transform.position += attack01_02[i].transform.up * danmaku_speed * uu;

//                Vector3 iti = attack01_02[i].transform.position;
//                attack3d01_02[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);


//            }

//            //最初の弾幕についていく弾幕
//            if (10f < attack01_02[0].transform.position.x)
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    attack01_02[i + 10].transform.position += attack01_02[i + 10].transform.up * danmaku_speed * uu;

//                    Vector3 iti = attack01_02[i + 10].transform.position;
//                    attack3d01_02[i + 10].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

//                }
//            }

//        }

//        void danmaku01_idou03()
//        {
//            for (int i = 0; i < 11; i++)
//            {
//                //二番目の弾幕移動
//                attack01_03[i].transform.position += attack01_03[i].transform.up * danmaku_speed * uu;

//                Vector3 iti = attack01_03[i].transform.position;
//                attack3d01_03[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);


//            }

//            //最初の弾幕についていく弾幕
//            if (10f < attack01_03[0].transform.position.x)
//            {
//                for (int i = 0; i < 11; i++)
//                {
//                    attack01_03[i + 11].transform.position += attack01_03[i + 11].transform.up * danmaku_speed * uu;

//                    Vector3 iti = attack01_03[i + 11].transform.position;
//                    attack3d01_03[i + 11].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

//                }
//            }

//        }

//        //弾幕の移動関数一番目の初期化
//        void danmaku01_init()
//        {

//            for (int i = 0; i < 11; i++)
//            {
//                attack01_01[i].transform.position = Ouroboros.transform.position;
//                attack01_01[i + 11].transform.position = Ouroboros.transform.position;
//            }

//        }

//        //弾幕の移動関数一番目の初期化
//        void danmaku02_init()
//        {

//            for (int i = 0; i < 10; i++)
//            {
//                attack01_02[i].transform.position = Ouroboros.transform.position;
//                attack01_02[i + 10].transform.position = Ouroboros.transform.position;
//            }

//        }

//        //弾幕の移動関数一番目の初期化
//        void danmaku03_init()
//        {

//            for (int i = 0; i < 11; i++)
//            {
//                attack01_03[i].transform.position = Ouroboros.transform.position;
//                attack01_03[i + 11].transform.position = Ouroboros.transform.position;
//            }

//        }

//        //attack01[0].transform.position += new Vector3(0f, 0.1f, 0f);
//    }
//    //弾幕プレハブ生成
//    void PrefabDraw01()
//    {
//        //一番目にすすむ弾幕を進む
//        for (int i = 0; i < 11; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_01[i] = (GameObject)Instantiate(danmakutype[0],
//                                                   Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

//            attack3d01_01[i] = (GameObject)Instantiate(danmakutype3d[0],
//                                                   Ouroboros3D.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
//        }
//        for (int i = 0; i < 11; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_01[i + 11] = (GameObject)Instantiate(danmakutype[0],
//                                                    Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

//            attack3d01_01[i + 11] = (GameObject)Instantiate(danmakutype3d[0],
//                                       Ouroboros3D.transform.position,
//                                        Quaternion.Euler(0, 0, (180 / 10) * i - 90));
//        }


//        //二番目にすすむ弾幕を進む
//        for (int i = 0; i < 10; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_02[i] = (GameObject)Instantiate(danmakutype[0],
//                                                    Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));

//            attack3d01_02[i] = (GameObject)Instantiate(danmakutype3d[0],
//                           Ouroboros3D.transform.position,
//                            Quaternion.Euler(0, 0, (180 / 10) * i - 90));

//        }
//        for (int i = 0; i < 10; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_02[i + 10] = (GameObject)Instantiate(danmakutype[0],
//                                                   Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));

//            attack3d01_02[i + 10] = (GameObject)Instantiate(danmakutype3d[0],
//               Ouroboros3D.transform.position,
//                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
//        }

//        //3番目にすすむ弾幕を進む
//        for (int i = 0; i < 11; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_03[i] = (GameObject)Instantiate(danmakutype[0],
//                                                    Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

//            attack3d01_03[i] = (GameObject)Instantiate(danmakutype3d[0],
//               Ouroboros3D.transform.position,
//                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
//        }
//        for (int i = 0; i < 11; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_03[i + 11] = (GameObject)Instantiate(danmakutype[0],
//                                                    Ouroboros.transform.position,
//                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

//            attack3d01_03[i + 11] = (GameObject)Instantiate(danmakutype3d[0],
//               Ouroboros3D.transform.position,
//                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
//        }
//    }

//    //弾幕攻撃02
//    void danmaku_attack01_back()
//    {
//        if (instans_flg == true)
//        {  //弾幕を一度だけ生成する
//            //プレハブ生成
//            PrefabDraw02();

//            //インスタンス生成フラグをfalseにする
//            instans_flg = false;
//        }



//        //弾幕の移動１番目
//        //danmaku01_idou01();



//        //弾幕の移動関数一番目
//        //void danmaku01_idou01()
//        //{

//        //    if ((attack01_01[count].transform.position.z < 40f)&&(count<90))
//        //    {
//        //        count++;
//        //    }
//        //        for (int i = 0; i < count; i++)
//        //        {
//        //            //一番目の弾幕移動
//        //            attack01_01[i].transform.position += attack01_01[i].transform.forward * danmaku_speed * uu;

//        //        }
//        //}

//    }

//    void PrefabDraw02()
//    {
//        //一番目にすすむ弾幕を進む
//        for (int i = 0; i < 90; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_01[i] = (GameObject)Instantiate(danmakutype3d[1],
//                                                   Ouroboros3D.transform.position,
//                                                    Quaternion.Euler(0, 0, 0));
//        }

//        for (int i = 0; i < 90; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_02[i] = (GameObject)Instantiate(danmakutype3d[1],
//                                                   Ouroboros3D.transform.position,
//                                                    Quaternion.Euler(0, 0, 0));
//        }

//        for (int i = 0; i < 90; i++)
//        {
//            // プレハブを元にオブジェクトを生成する
//            attack01_03[i] = (GameObject)Instantiate(danmakutype3d[1],
//                                                   Ouroboros3D.transform.position,
//                                                    Quaternion.Euler(0, 0, 0));
//        }
//    }
//}

