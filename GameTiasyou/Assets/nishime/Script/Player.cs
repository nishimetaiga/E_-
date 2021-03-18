using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public CinemachineVirtualCamera vcameraA;
    public CinemachineVirtualCamera vcameraB;



    public float speed;             //プレイヤーの速さ
    public float speedxz;           //プレイヤーの横の動きの速さ
    public float speedup;           //加速

    public float wh;                //横の限界値
    public float count;

    public float Ar_speed;          //プレイヤーの旋回の回転の速さ
    public GameObject Ouroboros;    //ウロボロスのオブジェクト
    public float radius;            //ウロボロスとの半径


    private bool rb_button;        //RBボタンが押されている（TRUE)か押されていない(false)か
    private float rb_rote;          //プレイヤーの旋回角度の限界値

    // Start is called before the first frame update
    void Start() {
        var ouro = Ouroboros.transform.position;　 //ウロボロスの位置
        var player = transform.position;           //プレイヤーの位置          
        this.transform.position = new Vector3(ouro.x + radius, player.y, ouro.z); //プレイヤーの初期位置を設定

        rb_button = false;   //RBボタンが押されていない
    }

    // Update is called once per frame
    void Update() {

        //L Stick


        if (vcameraA.Priority < vcameraB.Priority) {
            cmeraB();
        }
        else if (vcameraA.Priority > vcameraB.Priority) {
            cmeraA();
        }

        //RBボタンを押したらカメラの位置を変える
        if (Input.GetKeyDown("joystick button 5")) {
            rb_button = true;
            //Debug.Log("button5");

            if (vcameraA.Priority < vcameraB.Priority) {
                vcameraA.Priority = 20;
                vcameraB.Priority = 10;
            }
            else if (vcameraA.Priority > vcameraB.Priority) {
                vcameraA.Priority = 10;
                vcameraB.Priority = 20;
            }

        }
    }

    void cmeraA() {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        if (lsh != 0f) {
            //RotateAround(円運動の中心,進行方向,速度) ボートの前方に移動
            transform.RotateAround(Ouroboros.transform.position,
            -transform.up, speedup * Time.deltaTime);

            //cm.transform.RotateAround(Ouroboros.transform.position,-transform.up * lsh, speed * Time.deltaTime);
        }
        else {
            transform.RotateAround(Ouroboros.transform.position,
            -transform.up, speed * Time.deltaTime);
        }
        if (lsv < 0f && wh >= count) {
            count += 1f * speedxz * Time.deltaTime;
            transform.position += transform.right * speedxz * Time.deltaTime;
        }
        else if (lsv > 0f && -wh <= count) {
            count -= 1f * speedxz * Time.deltaTime;
            transform.position -= transform.right * speedxz * Time.deltaTime;

        }

    }

    void cmeraB() {
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        if (lsv != 0f) {
            //RotateAround(円運動の中心,進行方向,速度) ボートの前方に移動
            transform.RotateAround(Ouroboros.transform.position,
            -transform.up, speedup * Time.deltaTime);

            //cm.transform.RotateAround(Ouroboros.transform.position,-transform.up * lsh, speed * Time.deltaTime);
        }
        else {
            transform.RotateAround(Ouroboros.transform.position,
            -transform.up, speed * Time.deltaTime);
        }

        if (lsh > 0f && -wh <= count) {
            count -= 1f * speedxz * Time.deltaTime;
            transform.position += transform.right * speedxz * Time.deltaTime;
        }
        else if (lsh < 0f && wh >= count) {
            count += 1f * speedxz * Time.deltaTime;
            transform.position -= transform.right * speedxz * Time.deltaTime;

        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class Player : MonoBehaviour
//{

//    public GameObject boat;

//    private float rudder_r;      //舵の角度
//    public float rd_max;         //舵角度の限界    
//    public float rudder_speed;   //舵の角度変更スピード
//    private float rd_init;       //舵の初期角度

//    public float speed;         //プレイヤースピード
//    public float speed_up;      //プレイヤーの加速
//    public float speed_max;     　//前進の限界速度
//    public float speed_down;    //プレイヤーの減速

//    //public float speed_slow;     //微速前進の速度
//    //public float speed_recession;//後退の速度


//    private void Start() {

//        //rd_init = 90;     //初期角度９０度
//    }


//    // Update is called once per frame
//    public void Update() {
//        //Boat();
//        //前に移動
//        if (Input.GetKey(KeyCode.W)) {      //ｗが押されたとき

//            if (speed < speed_max) {        //速度が限界を超えているとき
//                //スピードを徐々に上げる
//                speed += speed_max;
//            }
//        }
//        else {
//            if (speed > 0) {        //速度が０以上のとき
//                //速度を落とす
//                speed -= speed_down;
//            }
//            else {
//                //速度を完全に停止させる
//                speed = 0;
//            }
//        }

//        //旋回処理
//        if (speed != 0) {
//            if (Input.GetKey(KeyCode.A)) {
//                Rudder(-1);
//            }
//            else if (Input.GetKey(KeyCode.D)) {
//                Rudder(1);
//            }
//        }

//        //プレイヤー前進移動
//        transform.position += transform.forward * speed * Time.deltaTime;
//    }


//    private int Rudder(int r) {

//        transform.eulerAngles += new Vector3(0f, 0f+r*rudder_speed*Time.deltaTime, 0f);

//        return 0;
//    }
//    ////旋回処理
//    //private void Rudder() {

//    //    if (Input.GetKey(KeyCode.D)) {      //Dが押されたとき

//    //        //右に曲がるため　舵の角度を３０度まで上げる
//    //        rudder_r += rudder_speed * Time.deltaTime;
//    //        this.transform.rotation = Quaternion.Euler(transform.rotation.x, rudder_r, transform.rotation.z);
//    //    }
//    //    if (Input.GetKey(KeyCode.A)) {      //Dが押されたとき

//    //        //左に曲がるため　舵の角度を３０度まで上げる
//    //        rudder_r += -rudder_speed * Time.deltaTime;
//    //        this.transform.rotation = Quaternion.Euler(transform.rotation.x, rudder_r, transform.rotation.z);

//    //    }
//    //}
//}
////public void Update() {
////    //Boat();
////    //前に移動
////    if (Input.GetKey(KeyCode.W)) {      //ｗが押されたとき
////        if (speed < speed_max) {    //プレイヤーの速度が速度限界値になるまで
////                                    //スピードの加速
////            speed += speed_up;
////        }
////    }
////    else if (speed > 0) {
////        //プレイヤーの速度を落とす
////        speed -= speed_down;
////    }
////    else if (Input.GetKey(KeyCode.S)) {     //Sが押されたとき
////        if (speed > speed_recession) {  //後退のスピードの以下になるまで
////            speed -= (speed_down * 10) * Time.deltaTime;        //後退するためにspeedをマイナスにするまで下げる
////        }
////    }
////    else if (0 > speed) {      //speedが０以下だった時
////        speed += speed_down * Time.deltaTime;    //スピードを０より大きくする
////    }
////    //旋回の関数
////    Rudder();


////    //プレイヤー前進移動
////    transform.position += transform.forward * speed * Time.deltaTime;


////}
