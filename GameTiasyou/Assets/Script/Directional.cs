using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directional : MonoBehaviour
{

    //プレイヤーを変数に格納
    public GameObject Player;

    //回転させるスピード
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //回転させる角度
        float angle = Input.GetAxis("Horizontal") * rotateSpeed;

        //プレイヤー位置情報
        Vector3 playerpos = Player.transform.position;

        //オブジェクトを回転させる
        transform.RotateAround(playerpos, Vector3.up, angle);
    }
}
