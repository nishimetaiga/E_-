using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class sln : MonoBehaviour
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
