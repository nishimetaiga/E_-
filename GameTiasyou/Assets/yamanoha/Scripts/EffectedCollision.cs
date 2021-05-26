using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectedCollision : MonoBehaviour
{
    /// <summary>
    /// 爆発エフェクトオブジェクト
    /// </summary>
    public GameObject exprosion;

    /// <summary>
    /// 爆発音
    /// </summary>
    private AudioSource se_exp;

    /// <summary>
    /// エフェクトやSEを管理するフラグ
    /// </summary>
    bool expflg;

    void Start()
    {
        se_exp = this.transform.GetComponent<AudioSource>();
        expflg = false;
    }

    /// <summary>
    /// 爆発エフェクトの生成
    /// </summary>
    public void GenerateExprosion()
    {
        if (!expflg)
        {
            // SEを再生
            se_exp.Play();

            // 爆発する座標を指定
            exprosion.transform.position = this.transform.position;
            // エフェクトを再生
            Instantiate(exprosion, this.transform.position, this.transform.rotation, this.transform);

            expflg = true;
        }

        // サイズを変更
        exprosion.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    /// <summary>
    /// 爆発済みとして立てたフラグを寝かせる
    /// </summary>
    public void InintExpflg()
    {
        expflg = false;
    }
}
