using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFloor : MonoBehaviour
{
    //座標取得用変数
    private Vector3 tmp;
    //オブジェクト情報格納用変数
    public GameObject FloorObj;
     void Update()
    {
        //座標取得取得
        tmp = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        //タグが　Player　のオブジェクトが触れたときに処理が行われる
        //オブジェクトを出す処理
        if (other.gameObject.tag == "Player")
        {
            //確認用
            //Debug.Log("すり抜けた！");
            //オブジェクトを生成する
            Instantiate(FloorObj, new Vector3(tmp.x, tmp.y, tmp.z + 149.6F), Quaternion.identity);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //タグが　Player　のオブジェクトが離れたときに処理が行われる
        //オブジェクトを消す処理
        if (other.gameObject.tag == "Player")
        {
            //確認用
            //Debug.Log("通り抜けた！");
            Destroy(gameObject);
        }

    }
}
