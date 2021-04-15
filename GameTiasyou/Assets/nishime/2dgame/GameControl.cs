using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    //プレイヤーの変数///////////////////////////////////////////////////////////////////////////////////
    public GameObject Player3d;     //2dのプレイヤーオブジェクト
    private float Player3d_y;       //3dプレイヤーの高さの座標
    private Transform player_pos;   //プレイヤー位置変更に使う変数
    public float speed;              //プレイヤーの移動速度

    //ウロボロス変数/////////////////////////////////////////////////////////////////////////
    public GameObject Ouroboros;


    //弾幕の変数////////////////////////////////////////////////////////////////////////////////////////
    public GameObject[] danmakutype; //インスタンス化する弾幕データ
    private bool instans_flg;        //生成するフラグ
    public GameObject[] attack01_01;    //生成した複数の弾幕の配列 順番１
    public GameObject[] attack01_02;    //生成した複数の弾幕の配列 順番２
    public GameObject[] attack01_03;    //生成した複数の弾幕の配列 順番３

    private bool[] order = { true, false, false };    //移動するタイミングのフラグ


    public float danmaku_speed;      //弾幕のスピード
                                     // private int order, danmakucount;   //attack[][]配列の要素



    public float uu;
    public float t;

    private void Start()
    {


        //インスタンスの生成フラグをtrueに初期化
        instans_flg = true;
        //ボートの高さは変更しない
        Player3d_y = Player3d.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {


        //プレイヤーコントロール
        Player_Control();

        //弾幕攻撃　
        danmaku_attack01();

    }

    //プレイヤーコントロール関数
    void Player_Control()
    {

        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        //プレイヤー移動
        if (lsh > 0)
        {

            if (transform.position.x < 74)
            {
                //2dプレイヤー移動
                this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
        }
        else if (lsh < 0)
        {

            if (transform.position.x > -74)
            {
                //2dプレイヤー移動
                this.transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
        }

        //if (lsv > 0)
        //{
        //    if (this.transform.position.y < 50)
        //    {
        //        this.transform.position += new Vector3(0f, speed * Time.deltaTime,0f);
        //    }

        //}
        //else if (lsv < 0)
        //{
        //    if (this.transform.position.y > 0)
        //    {
        //        this.transform.position -= new Vector3(0f, speed * Time.deltaTime,0f);
        //    }
        //}


        //2d側のプレイヤーの位置をコピー
        Vector3 Player2d = this.transform.position;

        //3d側のプレイヤーの移動
        Player3d.transform.position = new Vector3(Player2d.x, Player3d_y, Player2d.y);
    }




    //弾幕攻撃　
    void danmaku_attack01()
    {
        if (instans_flg == true)
        {  //弾幕を一度だけ生成する
            //プレハブ生成
            PrefabDraw();

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
                attack01_01[i].transform.position += attack01_01[i].transform.up * danmaku_speed * Time.deltaTime;

            }

            //最初の弾幕についていく弾幕
            if (10 < attack01_01[0].transform.position.x)
            {
                for (int i = 0; i < 11; i++)
                {
                    attack01_01[i + 11].transform.position += attack01_01[i + 11].transform.up * danmaku_speed * Time.deltaTime;
                }
            }
        }


        //弾幕の移動関数二番目
        void danmaku01_idou02()
        {
            for (int i = 0; i < 10; i++)
            {
                //二番目の弾幕移動
                attack01_02[i].transform.position += attack01_02[i].transform.up * danmaku_speed * Time.deltaTime;

            }

            //最初の弾幕についていく弾幕
            if (10f < attack01_02[0].transform.position.x)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack01_02[i + 10].transform.position += attack01_02[i + 10].transform.up * danmaku_speed * Time.deltaTime;
                }
            }

        }

        void danmaku01_idou03()
        {
            for (int i = 0; i < 11; i++)
            {
                //二番目の弾幕移動
                attack01_03[i].transform.position += attack01_03[i].transform.up * danmaku_speed * Time.deltaTime;

            }

            //最初の弾幕についていく弾幕
            if (10f < attack01_03[0].transform.position.x)
            {
                for (int i = 0; i < 11; i++)
                {
                    attack01_03[i + 11].transform.position += attack01_03[i + 11].transform.up * danmaku_speed * Time.deltaTime;
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

    //衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "danmaku")
        {
            Destroy(this.gameObject);
        }
    }

    //弾幕プレハブ生成
    void PrefabDraw()
    {
        //一番目にすすむ弾幕を進む
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_01[i] = (GameObject)Instantiate(danmakutype[0],
                                                   Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_01[i + 11] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }


        //二番目にすすむ弾幕を進む
        for (int i = 0; i < 10; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_02[i] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));

        }
        for (int i = 0; i < 10; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_02[i + 10] = (GameObject)Instantiate(danmakutype[0],
                                                   Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 9) * i - 90));
        }

        //3番目にすすむ弾幕を進む
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_03[i] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
        for (int i = 0; i < 11; i++)
        {
            // プレハブを元にオブジェクトを生成する
            attack01_03[i + 11] = (GameObject)Instantiate(danmakutype[0],
                                                    Ouroboros.transform.position,
                                                    Quaternion.Euler(0, 0, (180 / 10) * i - 90));
        }
    }
}
