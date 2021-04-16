using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    //プレイヤーの変数///////////////////////////////////////////////////////////////////////////////////
    public GameObject Player3d;     //2dのプレイヤーオブジェクト
    private float Player3d_y;       //3dプレイヤーの高さの座標
    private Transform player_pos;   //プレイヤー位置変更に使う変数
    public float speed;              //プレイヤーの移動速度

    public float rote;         //ボートの回転
    public float rote_speed;   //回転のスピード
    public float rote_max;     //回転の限界値

    //ウロボロス変数/////////////////////////////////////////////////////////////////////////
    public GameObject Ouroboros;
    public GameObject Ouroboros3D;
    public float boss_speed;
    public bool bossflg;


    //弾幕の変数////////////////////////////////////////////////////////////////////////////////////////
    public GameObject[] danmakutype; //インスタンス化する弾幕データ
    public GameObject[] danmakutype3d;  //インスタンス化する3dの弾幕データ
    private bool instans_flg;        //生成するフラグ

    //弾幕の種類１
    public GameObject[] attack01_01;    //生成した複数の弾幕の配列 順番１
    public GameObject[] attack01_02;    //生成した複数の弾幕の配列 順番２
    public GameObject[] attack01_03;    //生成した複数の弾幕の配列 順番３

    public GameObject[] attack3d01_01;    //生成した複数の弾幕の配列 順番１
    public GameObject[] attack3d01_02;    //生成した複数の弾幕の配列 順番２
    public GameObject[] attack3d01_03;    //生成した複数の弾幕の配列 順番３

    public int count;





    private bool[] order = { true, false, false };    //移動するタイミングのフラグ


    public float danmaku_speed;      //弾幕のスピード
                                     // private int order, danmakucount;   //attack[][]配列の要素
    public float uu;

    private void Start()
    {
        bossflg = true;

        //インスタンスの生成フラグをtrueに初期化
        instans_flg = true;
        //ボートの高さは変更しない
        Player3d_y = Player3d.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {

            //プレイヤーコントロール
            Player_Control();

            //ウロボロスコントロール
            Ouroboros_Control();

            //弾幕攻撃01
            danmaku_attack01();

            //弾幕攻撃02
            //danmaku_attack02();
        }

    }

    //プレイヤーコントロール関数
    public void Player_Control()
    {

        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");


        //プレイヤー移動
        if (lsh > 0)
        {

            if (transform.position.x < 74)
            {
                //2dプレイヤー移動
                this.transform.position += new Vector3(speed * uu, 0f, 0f);    
                if (rote < 10f)
                    {
                        rote += rote_speed;
                    }
            }
        }
        else if (lsh < 0)
        {

            if (transform.position.x > -74)
            {
                //2dプレイヤー移動
                this.transform.position -= new Vector3(speed * uu, 0f, 0f);


                if (rote > -10f)
                {
                    rote -= rote_speed;
                }
            }
        }
        else
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


        //2d側のプレイヤーの位置をコピー
        Vector3 Player2d = this.transform.position;

        //3d側のプレイヤーの移動
        Player3d.transform.position = new Vector3(Player2d.x, Player3d_y, Player2d.y);
        Player3d.transform.rotation = Quaternion.Euler(-90, 0f, rote);
    }

    //ウロボロスコントロール関数
    void Ouroboros_Control()
    {
        //３ｄのウロボロスに2dのウロボロスの位置を入れる
        Ouroboros3D.transform.position = new Vector3(Ouroboros.transform.position.x, 0.5f, Ouroboros.transform.position.y);


        //if ((Ouroboros.transform.position.x < 40f) && (bossflg == true))
        //{
        //    Ouroboros.transform.position += new Vector3(boss_speed * uu, 0f, 0f);


        //}
        //else if ((Ouroboros.transform.position.x > -40) && (bossflg == false))
        //{
        //    Ouroboros.transform.position += new Vector3(boss_speed * uu, 0f, 0f);
        //}

        //if (Ouroboros.transform.position.x > 40)
        //{
        //    bossflg = false;
        //}
        //else if (Ouroboros.transform.position.x < -40)
        //{
        //    bossflg = true;
        //}

    }


    //弾幕攻撃01
    void danmaku_attack01()
    {
        if (instans_flg == true)
        {  //弾幕を一度だけ生成する
            //プレハブ生成
            PrefabDraw01();

            //インスタンス生成フラグをfalseにする
            instans_flg = false;
        }

        //弾幕の移動1番目
        if (attack01_01[0].transform.position.x > 150f)
        {
            //弾幕の初期化
            danmaku01_init();

        }
        else if (order[0] == true)
        {
            //弾幕の移動１番目
            danmaku01_idou01();

        }


        //弾幕の移動2番目
        if (attack01_02[0].transform.position.x > 150f)
        {
            danmaku02_init();
        }
        if (order[1] == true)
        {
            //弾幕の移動二番目
            danmaku01_idou02();
        }
        else if ((attack01_01[0].transform.position.x > 50f) && (order[1] == false))
        {
            order[1] = true;
        }

        //弾幕の移動3番目
        if (attack01_03[0].transform.position.x > 150f)
        {
            danmaku03_init();
        }
        else if (order[2] == true)
        {
            //弾幕の移動二番目
            danmaku01_idou03();
        }
        else if ((attack01_02[0].transform.position.x > 50f) && (order[2] == false))
        {
            order[2] = true;
        }




        //弾幕の移動関数一番目
        void danmaku01_idou01()
        {
            for (int i = 0; i < 11; i++)
            {
                //一番目の弾幕移動
                attack01_01[i].transform.position += attack01_01[i].transform.up * danmaku_speed * uu;

                Vector3 iti = attack01_01[i].transform.position;
                attack3d01_01[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

            }

            //最初の弾幕についていく弾幕
            if (10 < attack01_01[0].transform.position.x)
            {
                for (int i = 0; i < 11; i++)
                {
                    attack01_01[i + 11].transform.position += attack01_01[i + 11].transform.up * danmaku_speed * uu;

                    Vector3 iti = attack01_01[i + 11].transform.position;
                    attack3d01_01[i + 11].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

                }
            }
        }


        //弾幕の移動関数二番目
        void danmaku01_idou02()
        {
            for (int i = 0; i < 10; i++)
            {
                //二番目の弾幕移動
                attack01_02[i].transform.position += attack01_02[i].transform.up * danmaku_speed * uu;

                Vector3 iti = attack01_02[i].transform.position;
                attack3d01_02[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);


            }

            //最初の弾幕についていく弾幕
            if (10f < attack01_02[0].transform.position.x)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack01_02[i + 10].transform.position += attack01_02[i + 10].transform.up * danmaku_speed * uu;

                    Vector3 iti = attack01_02[i + 10].transform.position;
                    attack3d01_02[i + 10].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

                }
            }

        }

        void danmaku01_idou03()
        {
            for (int i = 0; i < 11; i++)
            {
                //二番目の弾幕移動
                attack01_03[i].transform.position += attack01_03[i].transform.up * danmaku_speed * uu;

                Vector3 iti = attack01_03[i].transform.position;
                attack3d01_03[i].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);


            }

            //最初の弾幕についていく弾幕
            if (10f < attack01_03[0].transform.position.x)
            {
                for (int i = 0; i < 11; i++)
                {
                    attack01_03[i + 11].transform.position += attack01_03[i + 11].transform.up * danmaku_speed * uu;

                    Vector3 iti = attack01_03[i + 11].transform.position;
                    attack3d01_03[i + 11].transform.position = new Vector3(iti.x, Ouroboros3D.transform.position.y, iti.y);

                }
            }

        }

        //弾幕の移動関数一番目の初期化
        void danmaku01_init()
        {

            for (int i = 0; i < 11; i++)
            {
                attack01_01[i].transform.position = Ouroboros.transform.position;
                attack01_01[i + 11].transform.position = Ouroboros.transform.position;
            }

        }

        //弾幕の移動関数一番目の初期化
        void danmaku02_init()
        {

            for (int i = 0; i < 10; i++)
            {
                attack01_02[i].transform.position = Ouroboros.transform.position;
                attack01_02[i + 10].transform.position = Ouroboros.transform.position;
            }

        }

        //弾幕の移動関数一番目の初期化
        void danmaku03_init()
        {

            for (int i = 0; i < 11; i++)
            {
                attack01_03[i].transform.position = Ouroboros.transform.position;
                attack01_03[i + 11].transform.position = Ouroboros.transform.position;
            }

        }

        //attack01[0].transform.position += new Vector3(0f, 0.1f, 0f);
    }
    //弾幕プレハブ生成
    void PrefabDraw01()
    {
        //一番目にすすむ弾幕を進む
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_01[i] = (GameObject)Instantiate(danmakutype[0],
                                                   Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

            attack3d01_01[i] = (GameObject)Instantiate(danmakutype3d[0],
                                                   Ouroboros3D.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_01[i + 11] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

            attack3d01_01[i + 11] = (GameObject)Instantiate(danmakutype3d[0],
                                       Ouroboros3D.transform.position,
                                        Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }


        //二番目にすすむ弾幕を進む
        for (int i = 0; i < 10; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_02[i] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));

            attack3d01_02[i] = (GameObject)Instantiate(danmakutype3d[0],
                           Ouroboros3D.transform.position,
                            Quaternion.Euler(0, 0, (180 / 10) * i - 90));

        }
        for (int i = 0; i < 10; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_02[i + 10] = (GameObject)Instantiate(danmakutype[0],
                                                   Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));

            attack3d01_02[i + 10] = (GameObject)Instantiate(danmakutype3d[0],
               Ouroboros3D.transform.position,
                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }

        //3番目にすすむ弾幕を進む
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_03[i] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

            attack3d01_03[i] = (GameObject)Instantiate(danmakutype3d[0],
               Ouroboros3D.transform.position,
                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_03[i + 11] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));

            attack3d01_03[i + 11] = (GameObject)Instantiate(danmakutype3d[0],
               Ouroboros3D.transform.position,
                Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
    }

    //弾幕攻撃02
    void danmaku_attack02()
    {
        if (instans_flg == true)
        {  //弾幕を一度だけ生成する
            //プレハブ生成
            PrefabDraw02();

            //インスタンス生成フラグをfalseにする
            instans_flg = false;
        }



            //弾幕の移動１番目
            //danmaku01_idou01();

        

        //弾幕の移動関数一番目
        //void danmaku01_idou01()
        //{

        //    if ((attack01_01[count].transform.position.z < 40f)&&(count<90))
        //    {
        //        count++;
        //    }
        //        for (int i = 0; i < count; i++)
        //        {
        //            //一番目の弾幕移動
        //            attack01_01[i].transform.position += attack01_01[i].transform.forward * danmaku_speed * uu;

        //        }
        //}

    }

    void PrefabDraw02()
    {
        //一番目にすすむ弾幕を進む
        for (int i = 0; i < 90; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_01[i] = (GameObject)Instantiate(danmakutype3d[1],
                                                   Ouroboros3D.transform.position,
                                                    Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < 90; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_02[i] = (GameObject)Instantiate(danmakutype3d[1],
                                                   Ouroboros3D.transform.position,
                                                    Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < 90; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_03[i] = (GameObject)Instantiate(danmakutype3d[1],
                                                   Ouroboros3D.transform.position,
                                                    Quaternion.Euler(0, 0, 0));
        }
    }
}
