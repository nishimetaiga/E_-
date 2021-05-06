using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet4 : MonoBehaviour
{
    /// <summary>
    /// アタッチされている親となるオブジェクト
    /// </summary>
    private GameObject uroboros = null;

    /// <summary>
    /// 攻撃用オブジェクトの実体化に使うプレハブを格納する(球)
    /// </summary>
    public GameObject spherePrefab = null;

    /// <summary>
    /// 生成した攻撃用オブジェクトをまとめるリスト
    /// </summary>
    private List<GameObject> bulletList = new List<GameObject>();

    /// <summary>
    /// 攻撃用オブジェクト
    /// </summary>
    private GameObject bullet = null;

    /// <summary>
    /// 生成する弾の最大数
    /// </summary>
    private const int sphereMax = 110;

    /// <summary>
    /// 生成した弾の数
    /// </summary>
    private int sphereNum;

    /// <summary>
    /// 攻撃中か判断するフラグ
    /// </summary>
    bool atkFlg;

    ///// <summary>
    ///// 生成する弾のサイズを固定
    ///// </summary>
    //public Vector3 bulletSize;

    /// <summary>
    /// アクティブな弾の数
    /// </summary>
    int activeCnt = 0;          // アクティブになっている弾をカウント

    // Start is called before the first frame update
    void Start()
    {
        // スクリプトがアタッチされている GameObject を格納
        //uroboros = GameObject.Find("LaunchPort");
        uroboros = GameObject.Find("Barrage");

        // sphereNum の初期化
        sphereNum = 0;

        // atkFlg の初期化
        atkFlg = false;

        //// プール用オブジェクトの初期化
        //bulletPool = new GameObject("BulletPool").transform;

        Bulletpool();
    }

    /// <summary>
    /// 攻撃を開始させる
    /// </summary>
    public void AttackControl()
    {
        // 弾幕のモーションを始動
        if (atkFlg == false)
        {
            uroboros.GetComponent<Barrage_control>().barrge_flg = false;
            //BulletInit();
            StartCoroutine(GenerateSwirlBullet());
        }
        StartCoroutine(MoveSphereBullet());
    }

    /// <summary>
    /// 渦形に球形の弾を生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator GenerateSwirlBullet()
    {
        //const float arc = Mathf.PI * 0.04f;     // 弾同士の弧
        //float ringSize = spherePrefab.transform.localScale.x + 5;
            
        atkFlg = true;
        if (/*atkFlg == false &&*/ activeCnt < sphereMax)
        {

            for (int num = activeCnt; num < bulletList.Count; num++)
            //while(activeCnt < bulletList.Count)
            {
                //Debug.Log(bulletList.Count);
                // 攻撃用オブジェクトの生成
                //bullet = Instantiate(spherePrefab, new Vector3(uroboros.transform.position.x,
                //    transform.position.y - 5, uroboros.transform.position.z), Quaternion.Euler(0, arc * (sphereNum), 0));
                GetObject(num/*, spherePrefab, new Vector3(uroboros.transform.position.x,
                    transform.position.y,
                    uroboros.transform.position.z),
                    Quaternion.Euler(0, arc * (sphereNum), 0)*/);

                activeCnt++;

                // 処理の間隔を 0.1 秒あける
                yield return new WaitForSeconds(0.1f);
            }
        }

        // コルーチンの終了、次のコルーチンの呼び出し
        //yield return StartCoroutine();
        yield break;
    }

    /// <summary>
    /// 弾を外側に向けて移動させる
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveSphereBullet()
    {
        // 射程距離
        const int limitRange = 150;
        // 弾速
        float bulletSpeed = 0.3f;

        //int inactive = 0;    // 非アクティブのオブジェクトをカウントするのに使う

        for(var num = 0; num < bulletList.Count; num++)
        //foreach (var obj in bulletList)
        {
            // オブジェクトがアクティブか判定
            if (/*!*/bulletList[num].gameObject.activeSelf)
            //inactive++;
            //else
            {
                float arc = bulletList[num].transform.rotation.eulerAngles.y;
                // オブジェクトを外側に向けて移動させる
                bulletList[num].transform.position
                    = new Vector3(bulletList[num].transform.position.x + Mathf.Cos(arc) * bulletSpeed,
                    bulletList[num].transform.position.y,
                    bulletList[num].transform.position.z + Mathf.Sin(arc) * bulletSpeed);


                // 一定以上の距離を移動したら非アクティブにする
                var dis = Vector3.Distance(bulletList[num].transform.position, uroboros.transform.position);
                if (dis > limitRange)
                {
                    bulletList[num].gameObject.SetActive(false);
                    activeCnt--;
                }
            }


            // 1フレームずつ処理が行われる
            yield return null;
        }
        // 全ての弾が非アクティブの場合に処理を抜ける
        if (/*inactive*/bulletList.Count - activeCnt >= bulletList.Count)
            // 攻撃が終了したオブジェクトを消去する
            DeactivateBullet();

        yield break;
    }

    /// <summary>
    /// 生成した攻撃オブジェクトを消去する
    /// </summary>
    /// <returns></returns>
    void DeactivateBullet()
    {
        //// 使用済みのオブジェクトを破壊
        //foreach (var obj in bulletList)
        //{
        //    Destroy(obj);
        //}
        //// リストのクリア
        //bulletList.Clear();
        //// 生成した弾のカウントをクリア
        //sphereNum = 0;
        activeCnt = 0;

        atkFlg = false;

        uroboros.GetComponent<Barrage_control>().barrge_flg = true;
    }

    void GetObject(int num/*, GameObject obj, Vector3 pos, Quaternion qua*/)
    {

        //if (atkFlg == false)
        //{
            //オブジェが非アクティブならアクティブへ
            if (!bulletList[num].gameObject.activeSelf)
            {
                //bulletList[num].transform.SetPositionAndRotation(pos, qua);
                //bulletList[num].transform.SetPositionAndRotation(pos, bulletList[num].transform.localRotation);
                bulletList[num].transform.position = uroboros.transform.position;
                bulletList[num].gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                return;
            }
            //// 余っているオブジェクトがなければ、生成する
            //else if (sphereNum < sphereMax && atkFlg == false)
            //{
            //    //非アクティブなオブジェクトがないなら生成
            //    bullet = Instantiate(obj, pos, qua, this.transform);//生成と同時にpoolを親に設定

            //    // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
            //    bullet.transform.SetParent(uroboros.transform, false);
            //    //bullet.transform.parent = uroboros.transform;

            //    // 生成したオブジェクトに InTheCamera スクリプトを追加
            //    bullet.transform.gameObject.AddComponent<InTheCamera>().OnWillRenderObject();

            //    // 作った弾をカウント
            //    sphereNum++;

            //    // 生成したオブジェクトの名付け
            //    bullet.name = "bullet" + sphereNum;

            //    // 生成した bullet をリスト化する
            //    bulletList.Add(bullet);
            //}
        //}
    }

    void Bulletpool()
    {
        float arc = Mathf.PI * 0.045f;     // 弾同士の弧
        float rad;
        float ringSize = spherePrefab.transform.localScale.x + 5;

        for (int num = 0, add = 1; sphereNum < sphereMax; )
        {
            // 弾の角度計算
            if (num * arc > Mathf.PI || 0 > num * arc)
                add *= -1;
            num += add;
            rad =  num * arc;

            // 攻撃用オブジェクトの生成
            bullet = Instantiate(spherePrefab, new Vector3(uroboros.transform.position.x,
               transform.position.y, uroboros.transform.position.z), Quaternion.Euler(0, rad, 0));
            

            // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
            bullet.transform.SetParent(uroboros.transform, false);
            //bullet.transform.parent = uroboros.transform;

            // 生成したオブジェクトに InTheCamera スクリプトを追加
            bullet.transform.gameObject.AddComponent<InTheCamera>().OnWillRenderObject();

            //// 作った弾をカウント
            sphereNum++;

            // 生成したオブジェクトの名付け
            bullet.name = "bullet" + sphereNum;

            // 生成した bullet をリスト化する
            bulletList.Add(bullet);

            bullet.gameObject.SetActive(false);
        }
    }
}
