using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bullet4 : MonoBehaviour
{
    /// <summary>
    /// アタッチされている GameObject を取得するためのオブジェクト
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
    /// 生成した弾の数
    /// </summary>
    private int sphereNum;

    ///// <summary>
    ///// 生成した弾をプール（確保）しておくための空のオブジェクト
    ///// </summary>
    //Transform bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        // スクリプトがアタッチされている GameObject を格納
        uroboros = GameObject.Find("LaunchPort");

        // sphereNum の初期化
        sphereNum = 0;

        //// プール用オブジェクトの初期化
        //bulletPool = new GameObject("BulletPool").transform;
    }

    /// <summary>
    /// 攻撃を開始させる
    /// </summary>
    public void AttackStart()
    {
        // 弾幕のモーションを始動
        StartCoroutine(GenerateSwirlBullet());
        StartCoroutine(MoveSphereBullet());
    }

    /// <summary>
    /// 渦形に球形の弾を生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator GenerateSwirlBullet()
    {
        {
            var sphereMax = 90;// 1列ごとに生成する弾の最大数
            float arc = Mathf.PI * 0.05f;     // 弾同士の弧
            float ringSize = spherePrefab.transform.localScale.x + 5;

            for (int sphereNum = 1; sphereNum <= sphereMax; sphereNum++)
            {
                Debug.Log(bulletList.Count);
                // 攻撃用オブジェクトの生成
                //bullet = Instantiate(spherePrefab, new Vector3(uroboros.transform.position.x,
                //    transform.position.y - 5, uroboros.transform.position.z), Quaternion.Euler(0, arc * (sphereNum), 0));
                GetObject(spherePrefab, new Vector3(uroboros.transform.position.x,
                    transform.position.y - 5,
                    uroboros.transform.position.z),
                    Quaternion.Euler(0, arc * (sphereNum), 0));

                // 処理の間隔を 0.1 秒あける
                yield return new WaitForSeconds(0.1f);
            }

            // コルーチンの終了、次のコルーチンの呼び出し
            //yield return StartCoroutine();
            yield break;
        }
    }

    /// <summary>
    /// 弾を外側に向けて移動させる
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveSphereBullet()
    {
        // 射程距離
        var limitRange = 200;

        // 一定の距離を移動するまで繰り返す
        while (true)
        {
            int cnt = 0;    // 非アクティブのオブジェクトをカウントするのに使う

            foreach (var obj in bulletList)
            {
                // オブジェクトがアクティブか判定
                if (!obj.gameObject.activeSelf)
                    cnt++;
                else
                {
                    float arc = obj.transform.rotation.eulerAngles.y;
                    float bulletSpeed = 0.5f;
                    // オブジェクトを外側に向けて移動させる
                    obj.transform.position
                        = new Vector3(obj.transform.position.x + Mathf.Cos(arc) * bulletSpeed,
                        obj.transform.position.y,
                        obj.transform.position.z + Mathf.Sin(arc) * bulletSpeed);


                    // 一定以上の距離を移動したら非アクティブにする
                    var dis = Vector3.Distance(obj.transform.position, uroboros.transform.position);
                    if (dis > limitRange) obj.gameObject.SetActive(false);
                }
            }

            // 全ての弾が非アクティブの場合に処理を抜ける
            if (cnt >= bulletList.Count) break;

            // 1フレームずつ処理が行われる
            yield return null;
        }
        // 攻撃が終了したオブジェクトを消去する
        DeleteBullet();

        yield break;
    }

    /// <summary>
    /// 生成した攻撃オブジェクトを消去する
    /// </summary>
    /// <returns></returns>
    void DeleteBullet()
    {
        // 使用済みのオブジェクトを破壊
        foreach (var obj in bulletList)
        {
            Destroy(obj);
        }
        // リストのクリア
        bulletList.Clear();

        //// クールタイム開始
        StartCoroutine(uroboros.GetComponent<UroborosAttackMothion>().AttackFinishReceiver());
    }

    void GetObject(GameObject obj, Vector3 pos, Quaternion qua)
    {
        foreach (var t in bulletList)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.transform.SetPositionAndRotation(pos, qua);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                return;
            }
        }
        //非アクティブなオブジェクトがないなら生成
        bullet = Instantiate(obj, pos, qua, this.transform);//生成と同時にpoolを親に設定

        // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
        bullet.transform.parent = uroboros.transform;

        // 作った弾をカウント
        sphereNum++;

        // 生成したオブジェクトの名付け
        bullet.name = "bullet" + sphereNum;

        // 生成した bullet をリスト化する
        bulletList.Add(bullet);
    }
}
