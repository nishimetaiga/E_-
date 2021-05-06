using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
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
    /// 攻撃用オブジェクトの実体化に使うプレハブを格納する(円柱)
    /// </summary>
    public GameObject cylinderPrefab = null;

    /// <summary>
    /// 生成した攻撃用オブジェクトをまとめるリスト
    /// </summary>
    private List<GameObject> bulletList = new List<GameObject>();

    /// <summary>
    /// 攻撃用オブジェクト
    /// </summary>
    private GameObject bullet = null;


    // Start is called before the first frame update
    void Start()
    {
        // スクリプトがアタッチされている GameObject を格納
        uroboros = GameObject.Find("LaunchPort");
    }

    /// <summary>
    /// 攻撃を開始させる
    /// </summary>
    public void AttackStart()
    {
        // 弾幕のモーションを始動
        StartCoroutine(GenerateSphereBullet());
    }

    /// <summary>
    /// 球形の弾を生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator GenerateSphereBullet()
    {
        {
            var sphereNum = 0;
            float radius = 5;
            float ringSize = spherePrefab.transform.localScale.x + 5;

            for (int ringNum = 0; ringNum < 3; ringNum++)
            {
                for (float angle = 0; angle < Mathf.PI * 2; angle += Mathf.PI / 8)
                {
                    sphereNum++;
                    // 攻撃用オブジェクトの生成
                    bullet = Instantiate(spherePrefab, new Vector3(uroboros.transform.position.x + (radius + ringSize * ringNum) * Mathf.Cos(angle), transform.position.y - 5, uroboros.transform.position.z + (radius + ringSize * ringNum) * Mathf.Sin(angle)), Quaternion.Euler(0, -22.5f * sphereNum, 0));

                    // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
                    bullet.transform.parent = this.transform;

                    // 生成したオブジェクトの名付け
                    bullet.name = "bullet" + sphereNum;

                    // 生成した bullet をリスト化する
                    bulletList.Add(bullet);

                    // 処理の間隔を 0.05 秒あける
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // コルーチンの終了、次のコルーチンの呼び出し
            yield return StartCoroutine(MoveSphereBullet());
        }
    }

    /// <summary>
    /// 円柱形の弾を生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator GenerateCylinderBullet()
    {
        {
            var num = 0;
            float radius = 5;
            var listCountBuffer = bulletList.Count;

            for (float angle = Mathf.PI / 3; angle < Mathf.PI * 2; angle += Mathf.PI / 3)
            {
                num++;
                // 攻撃用オブジェクトの生成
                bullet = Instantiate(cylinderPrefab, new Vector3(radius * Mathf.Cos(angle), transform.position.y, radius * Mathf.Sin(angle)), Quaternion.Euler(90, -60f * num, 0));

                // 生成した bullet の親オブジェクトにアタッチしているこのオブジェクトを指定
                bullet.transform.parent = this.transform;

                // 生成したオブジェクトの名付け
                bullet.name = "bullet" + (num + bulletList.Count);

                // 生成した bullet をリスト化する
                bulletList.Add(bullet);

                // 処理の間隔を 0.25 秒あける
                yield return new WaitForSeconds(0.1f);
            }

            // コルーチンの終了、次のコルーチンの呼び出し
            //yield return StartCoroutine(DeformCurtainBullet());
            yield break;
        }
    }

    /// <summary>
    /// 球形の弾の移動
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveSphereBullet()
    {
        // 縦の変化量
        //const float bulletSpeedY = 0.5f;
        // 横の変化量
        const float bulletSpeedX = 0.7f;
        //// 移動限界地点
        ////Transform moveLimitValueY = GameObject.Find("Field Cube").transform;
        // 移動限界距離
        const float specifiedValueX = 110f;
        // 現在の移動量
        float bulletMoveMentAmount = 0;

        //// 弾を下まで移動させる
        //while (true)
        //{
        //    foreach(var obj in bulletList)
        //    {
        //        // オブジェクトを海面まで移動させる
        //        obj.transform.position
        //            = new Vector3(obj.transform.position.x, obj.transform.position.y - bulletSpeedY, obj.transform.position.z);
        //    }

        //    // リストの最後の要素が一定の値になったら処理を抜ける
        //    if (bulletList[bulletList.Count - 1].transform.position.y - bulletList[bulletList.Count - 1].transform.localScale.y * 0.5 
        //        <= moveLimitValueY.position.y + moveLimitValueY.localScale.y)
        //        break;

        //    // 1フレームずつ処理が行われる
        //    yield return null;
        //}

        // 弾を水平方向に移動させる
        while (true)
        {
            int count = 0;

            foreach (var obj in bulletList)
            {
                // オブジェクトを水平方向に移動させる
                obj.transform.position
                    = new Vector3(obj.transform.position.x + bulletSpeedX * Mathf.Cos(Mathf.PI / 8 * ++count),
                    obj.transform.position.y, 
                    obj.transform.position.z + bulletSpeedX * Mathf.Sin(Mathf.PI / 8 * count));
            }

            bulletMoveMentAmount += bulletSpeedX;

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletMoveMentAmount >= specifiedValueX)
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
