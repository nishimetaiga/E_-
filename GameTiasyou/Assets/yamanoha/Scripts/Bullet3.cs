using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    /// <summary>
    /// アタッチされている GameObject を取得するためのオブジェクト
    /// </summary>
    private GameObject uroboros = null;

    /// <summary>
    /// 攻撃用オブジェクトの実体化に使うプレハブを格納する
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
    /// プレイヤーの座標を格納するためのオブジェクト
    /// </summary>
    private GameObject player = null;

    /// <summary>
    /// ウロボロスからプレイヤーへのベクトル
    /// </summary>
    Vector3 targetVector;

    /// <summary>
    /// targetVector の正規化(単位ベクトル化)用
    /// </summary>
    Vector3 direction;

    Vector3 ballisticVector;
    Vector3 unitBallisticVector;

    private void Start()
    {
        // スクリプトがアタッチされている GameObject を格納
        uroboros = GameObject.Find("LaunchPort");
        player = GameObject.Find("Boat_4");
    }

    /// <summary>
    /// 攻撃を開始させる
    /// </summary>
    public void AttackStart()
    {
        // 弾幕のモーションを始動
        StartCoroutine(Generate3WayBullet());
    }

    /// <summary>
    /// 球形の弾の列をプレイヤーに向けて生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator Generate3WayBullet()
    {
        int num = 0;        // 番号付け
        float radius = 3;   // 生成される球の間隔
        targetVector = player.transform.position - uroboros.transform.position;  // ウロボロスからプレイヤーへのベクトル
        direction = targetVector / targetVector.magnitude;  // targetVector の正規化(単位ベクトル化)
        Vector3 vertical = new Vector3(targetVector.z * 0.1f, targetVector.y, -targetVector.x * 0.1f);  // targetVectorの垂直ベクトル
        Vector3 unitVertical = new Vector3(direction.z, direction.y, -direction.x);// targetVector の垂直ベクトルを正規化(単位ベクトル化)
        Vector2 bulletAngle = new Vector2(Vector3.Angle(/*targetangle, uroboros.transform.position)*/uroboros.transform.forward, targetVector),
                                            Vector3.Angle(targetVector, uroboros.transform.right));
        //Debug.Log(targetVector.magnitude);
        //Debug.Log(direction);
        //Debug.Log(vertical);
        //Debug.Log(vertical * -1);


        //for (float angle = Mathf.PI / 6; angle < Mathf.PI * 2; angle += Mathf.PI / 6)
        for (int way = -1, setAngle = 0; way < 2;way++)
        {
            ballisticVector = player.transform.position + (vertical * way) - uroboros.transform.position;
            unitBallisticVector = ballisticVector / ballisticVector.magnitude;
            if (float.IsNaN(unitBallisticVector.x)) unitBallisticVector.x = 0;
            if (float.IsNaN(unitBallisticVector.y)) unitBallisticVector.y = 0;
            if (float.IsNaN(unitBallisticVector.z)) unitBallisticVector.z = 0;
            unitVertical = new Vector3(unitBallisticVector.z, unitBallisticVector.y, -unitBallisticVector.x);
            //Debug.Log(way);
            //Debug.Log(setAngle);
            //Debug.Log(ballisticVector);

            for (int line = 0; line < 2; line++)
            {

                for (int cnt = 1; cnt < 5; cnt++)
                {
                    num++;

                    Debug.Log(cnt * radius * unitBallisticVector.x + unitVertical.x + vertical.x *  way);
                    // 攻撃用オブジェクトの生成
                    bullet = Instantiate(spherePrefab,
                        new Vector3(/*transform.position.x +*/ cnt * radius * unitBallisticVector.x + unitVertical.x + vertical.x * way,
                        cnt * radius * direction.y,
                        /*transform.position.z +*/ cnt * radius * unitBallisticVector.z + unitVertical.z + vertical.z * way),
                        Quaternion.Euler(Mathf.Cos(bulletAngle.x), Mathf.Sin(bulletAngle.y), Mathf.Sin(bulletAngle.y)));
                    /*new Vector3(cnt * radius * direction.x + unitVertical.x + vertical.x * way,
                    cnt * radius * direction.y, 
                    cnt * radius * direction.z + unitVertical.z + vertical.z * way),
                    Quaternion.Euler(Mathf.Cos(bulletAngle.x), Mathf.Sin(bulletAngle.y), Mathf.Sin(bulletAngle.y)));*/
                    /*bullet = Instantiate(spherePrefab,
                        new Vector3(cnt * radius * Mathf.Cos(bulletAngle.x) + AAA, this.transform.position.y, cnt * radius * Mathf.Sin(bulletAngle.x) + AAA),
                        Quaternion.Euler(Mathf.Cos(bulletAngle.x), Mathf.Sin(bulletAngle.y), Mathf.Sin(bulletAngle.y)));*/

                    // オブジェクトの大きさの指定
                    bullet.transform.localScale = new Vector3(1, 1, 1);

                    // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
                    bullet.transform.SetParent(this.transform, false);

                    // 名付け
                    bullet.name = "bullet" + num;

                    // 生成した bullet をリスト化する
                    bulletList.Add(bullet);

                    // 処理の間隔を 0.05 秒あける
                    yield return new WaitForSeconds(0.05f);
                }
                unitVertical *= -1;
            }
        }
            // 処理の間隔を 0.05 秒あける
            yield return new WaitForSeconds(0.35f);

            //// コルーチンの終了、次のコルーチンの呼び出し
            yield return StartCoroutine(Move3WayBullet());
            //yield break;
    }

    /// <summary>
    /// 弾を海面まで移動させる
    /// </summary>
    /// <returns></returns>
    public IEnumerator Move3WayBullet()
    {

        // 移動限界地点
        Transform moveLimitValueY = GameObject.Find("Field Cube").transform;

        // 弾を海面まで移動させる
        while (true)
        {
            foreach (var obj in bulletList)
            {
                var bulletSpeed = 0.4f;
                // オブジェクトの移動
                obj.transform.position
                    = new Vector3(obj.transform.position.x + unitBallisticVector.x * bulletSpeed, obj.transform.position.y + direction.y * bulletSpeed, obj.transform.position.z + unitBallisticVector.z * bulletSpeed);
            }

            // 弾の最後尾が一定の値になったら処理を抜ける
            if (bulletList[0].transform.position.y + bulletList[bulletList.Count - 1].transform.localScale.y /** 0.5*/
                < moveLimitValueY.position.y)
                break;

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

        // クールタイム開始
        StartCoroutine(uroboros.GetComponent<UroborosAttackMothion>().AttackFinishReceiver());
    }
}
