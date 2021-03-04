using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //ボートの速さ
    public float speed;
    public float speed_up;
    public float speed_down;
    //ボートの曲がる角度
    public float angle;


    public GameObject player_z;     //プレイヤーの前のに行く方向


    private void Update() {
        //前に移動
        if (Input.GetKey(KeyCode.W)) {
            speed += Time.deltaTime*speed_up;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player_z.transform.position, step);
        }
        else if(speed>0){
            speed -= Time.deltaTime * speed_down;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player_z.transform.position, step);

        }
        Debug.Log(transform.forward);
        //右にカーブ
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0.0f, 0.0f, angle);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0.0f, 0.0f, -angle);

        }
    }
}
