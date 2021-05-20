using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectedCollision : MonoBehaviour
{
    private GameObject boat;
    private ParticleSystem exprosion;

    void Start()
    {
        boat = GameObject.Find("Boat_4");
        GenerateExprosion();
        exprosion = this.GetComponent<ParticleSystem>();
        // 停止しておく
        //exprosion.Stop();
    }

    /// <summary>
    /// 船と弾幕が衝突した際に呼び出す
    /// </summary>
    public void BoatAndBarrage()
    {
        // エフェクトを再生
        exprosion.Play();
    }

    /// <summary>
    /// 爆発エフェクトの生成
    /// </summary>
    private void GenerateExprosion()
    {
        // エフェクトを生成
        //Instantiate(exprosion, boat.transform.position, boat.transform.rotation, this.transform);
        //Instantiate(exprosion, new Vector3(0, 0, 0), boat.transform.rotation);

        // サイズ調整
        //exprosion.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

    }
}
