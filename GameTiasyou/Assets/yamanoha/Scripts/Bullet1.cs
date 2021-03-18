using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    private GameObject uroboros = null;
    public GameObject curtainPrefab = null;
    //public float attackSpeed;
    private List<GameObject> bulletList = new List<GameObject>();
    private GameObject enemyBullet = null;

    private void Start()
    {
        uroboros = GameObject.Find("LaunchPort");
    }

    /// <summary>
    /// 攻撃を開始させる
    /// </summary>
    public void AttackStart()
    {
        StartCoroutine(GenerateCurtainBullet());
    }

    /// <summary>
    /// カーテン型の弾幕を生成する
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
        const float extendSpeedY = 0.05f;
        // 横の変化量
        const float extendSpeedX = 0.05f;
        // 縦に伸ばす量
        const float specifiedValuY = 5f;
        // 横に伸ばす量
        const float specifiedValuX = 10f;

        // カーテン型の攻撃を縦に伸ばす
        while (true)
        {
            // リストに入っているオブジェクトのスケールを徐々に変更する
            for(int count = 0; count < bulletList.Count; count++) {
                // カーテンを extendSpeedY ずつ縦に伸ばす
                bulletList[count].transform.localScale 
                    = new Vector3(bulletList[count].transform.localScale.x, bulletList[count].transform.localScale.y + extendSpeedY, bulletList[count].transform.localScale.z);


                // 伸ばした分だけ下に移動させる
                bulletList[count].transform.position
                    = new Vector3(bulletList[count].transform.position.x, bulletList[count].transform.position.y - extendSpeedY * 1.0f, bulletList[count].transform.position.z);
            }

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletList[bulletList.Count - 1].transform.localScale.y >= specifiedValuY)
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
                float variationRatio = (extendSpeedX / transform.localScale.x + extendSpeedX % transform.localScale.x) * 0.5f;

                // カーテンを extendSpeedX ずつ横に伸ばす
                bulletList[count].transform.localScale
                    = new Vector3(bulletList[count].transform.localScale.x+ extendSpeedX, bulletList[count].transform.localScale.y, bulletList[count].transform.localScale.z);

                // 伸ばした分だけ外側に移動させる
                bulletList[count].transform.position
                    //= new Vector3(bulletList[count].transform.position.x + bulletList[count].transform.position.x * variationRatio * 0.1f,
                    //bulletList[count].transform.position.y,
                    //bulletList[count].transform.position.z + bulletList[count].transform.position.z * variationRatio * 0.1f);
                    = new Vector3(bulletList[count].transform.position.x + extendSpeedX * Mathf.Cos(Mathf.PI / 6 *(count + 1)),
                    bulletList[count].transform.position.y,
                    bulletList[count].transform.position.z + extendSpeedX * Mathf.Sin(Mathf.PI / 6 * (count + 1)));
            }

            // リストの最後の要素が一定の値になったら処理を抜ける
            if (bulletList[bulletList.Count - 1].transform.localScale.x >= specifiedValuX)
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
                float variationRatio = (extendSpeedX / transform.localScale.x + extendSpeedX % transform.localScale.x) * 0.5f;

                // カーテンを extendSpeedX ずつ横に縮める
                bulletList[count].transform.localScale
                    = new Vector3(bulletList[count].transform.localScale.x - extendSpeedX, bulletList[count].transform.localScale.y, bulletList[count].transform.localScale.z);

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

        // コルーチンの終了
        yield break;
        
    }

    /// <summary>
    /// 生成した攻撃オブジェクトを消去する
    /// </summary>
    /// <returns></returns>
    void DeleteCurtainBullet()
    {
        foreach(var obj in bulletList)
        {
            Destroy(obj);
        }
        bulletList.Clear();

        StartCoroutine(uroboros.GetComponent<UroborosAttackMothion>().AttackFinishReceiver());
    }
}
