using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    /// <summary>
    /// アタッチされている GameObject を取得するためのオブジェクト
    /// </summary>
    private GameObject uroboros = null;

    /// <summary>
    /// 攻撃用オブジェクトの実体化に使うプレハブを格納する
    /// </summary>
    public GameObject curtainPrefab = null;

    /// <summary>
    /// 生成した攻撃用オブジェクトをまとめるリスト
    /// </summary>
    private List<GameObject> bulletList = new List<GameObject>();

    /// <summary>
    /// 攻撃用オブジェクト
    /// </summary>
    private GameObject enemyBullet = null;

    private void Start()
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
        StartCoroutine(GenerateCurtainBullet());
    }

    /// <summary>
    /// カーテン型の弾を生成する
    /// </summary>
    /// <returns></returns>
    public IEnumerator GenerateCurtainBullet()
    {
        {
            var num = 0;
            float radius = 5;

            for (float angle = Mathf.PI / 6; angle < Mathf.PI * 2; angle += Mathf.PI / 6)
            {
                num++;
                // 攻撃用オブジェクトの生成
                enemyBullet = Instantiate(curtainPrefab, new Vector3(radius * Mathf.Cos(angle), transform.position.y, radius * Mathf.Sin(angle)), Quaternion.Euler(0, -30 * num, 0));

                // 生成した enemyBullet の親オブジェクトにアタッチしているこのオブジェクトを指定
                enemyBullet.transform.parent = this.transform;

                // 名付け
                enemyBullet.name = "enemyBullet" + num;

                // 生成した enemyBullet をリスト化する
                bulletList.Add(enemyBullet);

                // 処理の間隔を 0.25 秒あける
                yield return new WaitForSeconds(0.25f);
            }

            // コルーチンの終了、次のコルーチンの呼び出し
            yield return StartCoroutine(DeformCurtainBullet());
        }
    }

    /// <summary>
    /// 生成した攻撃オブジェクトを縦軸に変形させる
    /// </summary>
    /// <returns></returns>
    IEnumerator DeformCurtainBullet()
    {
        // 縦の変化量
        const float bulletSpeedY = 0.05f;
        // 横の変化量
        const float bulletSpeedX = 0.05f;
        // 縦に伸ばす量
        const float specifiedValueY = 5f;
        // 横に伸ばす量
        const float specifiedValueX = 10f;

        // カーテン型の攻撃を縦に伸ばす
        while (true)
        {
            // リストに入っているオブジェクトのスケールを徐々に変更する
            for(int count = 0; count < bulletList.Count; count++) {
                // カーテンを bulletSpeedY ずつ縦に伸ばす
                bulletList[count].transform.localScale 
                    = new Vector3(bulletList[count].transform.localScale.x, bulletList[count].transform.localScale.y + bulletSpeedY, bulletList[count].transform.localScale.z);


                // 伸ばした分だけ下に移動させる
                bulletList[count].transform.position
                    = new Vector3(bulletList[count].transform.position.x, bulletList[count].transform.position.y - bulletSpeedY * 1.0f, bulletList[count].transform.position.z);
            }

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletList[bulletList.Count - 1].transform.localScale.y >= specifiedValueY)
                break;

            // 1フレームずつ処理が行われる
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        // カーテン型の攻撃を横に伸ばす
        while (true)
        {
            // リストに入っているオブジェクトのスケールを徐々に変更する
            for (int count = 0; count < bulletList.Count; count++)
            {
                // 横に伸びる前と後の変化率を求める
                float variationRatio = (bulletSpeedX / transform.localScale.x + bulletSpeedX % transform.localScale.x) * 0.5f;

                // カーテンを extendSpeedX ずつ横に伸ばす
                bulletList[count].transform.localScale
                    = new Vector3(bulletList[count].transform.localScale.x+ bulletSpeedX, bulletList[count].transform.localScale.y, bulletList[count].transform.localScale.z);

                // 伸ばした分だけ外側に移動させる
                bulletList[count].transform.position
                    //= new Vector3(bulletList[count].transform.position.x + bulletList[count].transform.position.x * variationRatio * 0.1f,
                    //bulletList[count].transform.position.y,
                    //bulletList[count].transform.position.z + bulletList[count].transform.position.z * variationRatio * 0.1f);
                    = new Vector3(bulletList[count].transform.position.x + bulletSpeedX * Mathf.Cos(Mathf.PI / 6 *(count + 1)),
                    bulletList[count].transform.position.y,
                    bulletList[count].transform.position.z + bulletSpeedX * Mathf.Sin(Mathf.PI / 6 * (count + 1)));
            }

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletList[bulletList.Count - 1].transform.localScale.x >= specifiedValueX)
                break;

            // 1フレームずつ処理が行われる
            yield return null;
        }


        yield return new WaitForSeconds(0.5f);

        // カーテン型の攻撃を横に縮める
        while (true)
        {
            // リストに入っているオブジェクトのスケールを徐々に変更する
            for (int count = 0; count < bulletList.Count; count++)
            {
                // 横に伸びる前と後の変化率を求める
                float variationRatio = (bulletSpeedX / transform.localScale.x + bulletSpeedX % transform.localScale.x) * 0.5f;

                // カーテンを extendSpeedX ずつ横に縮める
                bulletList[count].transform.localScale
                    = new Vector3(bulletList[count].transform.localScale.x - bulletSpeedX, bulletList[count].transform.localScale.y, bulletList[count].transform.localScale.z);

                // 縮めた分だけ外側に移動させる
                bulletList[count].transform.position
                    = new Vector3(bulletList[count].transform.position.x + bulletList[count].transform.position.x * variationRatio * 0.1f,
                    bulletList[count].transform.position.y,
                    bulletList[count].transform.position.z + bulletList[count].transform.position.z * variationRatio * 0.1f);
            }

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletList[bulletList.Count - 1].transform.localScale.x <= 0f)
                break;

            // 1フレームずつ処理が行われる
            yield return null;
        }

        // 攻撃が終了したオブジェクトを消去する
        DeleteCurtainBullet();

        yield break;
        
    }

    /// <summary>
    /// 生成した攻撃オブジェクトを消去する
    /// </summary>
    /// <returns></returns>
    void DeleteCurtainBullet()
    {
        // 使用済みのオブジェクトを破壊
        foreach(var obj in bulletList)
        {
            Destroy(obj);
        }
        // リストのクリア
        bulletList.Clear();

        // クールタイム開始
        StartCoroutine(uroboros.GetComponent<UroborosAttackMothion>().AttackFinishReceiver());
    }
}
