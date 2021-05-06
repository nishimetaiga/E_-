using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheCamera : MonoBehaviour
{
    /// <summary>
    ///  メインカメラのタグ名
    /// </summary>
    private const string MAIN_CAMEREA_TAG_NAME = "MainCamera";

    /// <summary>
    /// カメラに映っている間だけ呼ばれる
    /// </summary>
    public void OnWillRenderObject()
    {
        // メインカメラに映ってなければ非アクティブに
        if (Camera.main.tag != MAIN_CAMEREA_TAG_NAME)
        {
            this.transform.gameObject.SetActive(false);
            Debug.Log("yes");
        }
    }
}
