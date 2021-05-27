using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFloor : MonoBehaviour
{

    //カウント
    private int DeleteCount;
    private int Count;
    //座標取得用変数
    private Vector3 tmp;
    //オブジェクト情報格納用変数
    public GameObject FloorObj;
    // Start is called before the first frame update
    void Start()
    {
        //カウントリセット
        DeleteCount = 0;
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //座標取得取得
        tmp = this.transform.position;

        //生成のタイミング：このオブジェクトのZが40より小さいときかつカウントが0の時
        if (tmp.z < 40 && Count == 0)
        {// X.0 Y.0 Z.190 の位置にオブジェクトを生成する。カウントを1にする
            Instantiate(FloorObj, new Vector3(0, 0, 190), Quaternion.identity);
            Count = 1;
        }
        //削除のタイミング：このオブジェクトのZが-150のより大きいときかつ削除カウントが0の時
        if (tmp.z < -150 && DeleteCount == 0)
        {//削除処理。削除カウントを１にする
            Destroy(gameObject);
            DeleteCount = 1;
        }
    }
}
