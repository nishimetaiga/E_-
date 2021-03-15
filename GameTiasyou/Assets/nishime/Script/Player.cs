using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public GameObject boat;

    private float rudder_r;      //舵の角度
    public float rd_max;         //舵角度の限界    
    public float rudder_speed;   //舵の角度変更スピード
    private float rd_init;       //舵の初期角度

    public float speed;         //プレイヤースピード
    public float speed_up;      //プレイヤーの加速
    public float speed_max;     　//前進の限界速度
    public float speed_down;    //プレイヤーの減速

    //public float speed_slow;     //微速前進の速度
    //public float speed_recession;//後退の速度


    private void Start() {

        //rd_init = 90;     //初期角度９０度
    }


    // Update is called once per frame
    public void Update() {
        //Boat();
        //前に移動
        if (Input.GetKey(KeyCode.W)) {      //ｗが押されたとき

            if (speed < speed_max) {        //速度が限界を超えているとき
                //スピードを徐々に上げる
                speed += speed_max;
            }
        }
        else {
            if (speed > 0) {        //速度が０以上のとき
                //速度を落とす
                speed -= speed_down;
            }
            else {
                //速度を完全に停止させる
                speed = 0;
            }
        }

        //旋回処理
        if (speed != 0) {
            if (Input.GetKey(KeyCode.A)) {
                Rudder(-1);
            }
            else if (Input.GetKey(KeyCode.D)) {
                Rudder(1);
            }
        }

        //プレイヤー前進移動
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private int Rudder(int r) {

        transform.eulerAngles += new Vector3(0f, 0f+r*rudder_speed*Time.deltaTime, 0f);

        return 0;
    }
    ////旋回処理
    //private void Rudder() {

    //    if (Input.GetKey(KeyCode.D)) {      //Dが押されたとき

    //        //右に曲がるため　舵の角度を３０度まで上げる
    //        rudder_r += rudder_speed * Time.deltaTime;
    //        this.transform.rotation = Quaternion.Euler(transform.rotation.x, rudder_r, transform.rotation.z);
    //    }
    //    if (Input.GetKey(KeyCode.A)) {      //Dが押されたとき

    //        //左に曲がるため　舵の角度を３０度まで上げる
    //        rudder_r += -rudder_speed * Time.deltaTime;
    //        this.transform.rotation = Quaternion.Euler(transform.rotation.x, rudder_r, transform.rotation.z);

    //    }
    //}
}
//public void Update() {
//    //Boat();
//    //前に移動
//    if (Input.GetKey(KeyCode.W)) {      //ｗが押されたとき
//        if (speed < speed_max) {    //プレイヤーの速度が速度限界値になるまで
//                                    //スピードの加速
//            speed += speed_up;
//        }
//    }
//    else if (speed > 0) {
//        //プレイヤーの速度を落とす
//        speed -= speed_down;
//    }
//    else if (Input.GetKey(KeyCode.S)) {     //Sが押されたとき
//        if (speed > speed_recession) {  //後退のスピードの以下になるまで
//            speed -= (speed_down * 10) * Time.deltaTime;        //後退するためにspeedをマイナスにするまで下げる
//        }
//    }
//    else if (0 > speed) {      //speedが０以下だった時
//        speed += speed_down * Time.deltaTime;    //スピードを０より大きくする
//    }
//    //旋回の関数
//    Rudder();


//    //プレイヤー前進移動
//    transform.position += transform.forward * speed * Time.deltaTime;


//}
