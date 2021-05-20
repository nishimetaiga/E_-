using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    [SerializeField]
    //　メニューパネルのプレハブ
    private GameObject menuUIPrefab;
    //　メニューパネルのインスタンス
    private GameObject menuUIInstance;

    [SerializeField]
    //　ポーズした時に表示するサウンドボタンのプレハブ
    private GameObject soundButtonPrefab;
    //　サウンドボタンのインスタンス
    private GameObject soundInstance;

    [SerializeField]
    //　ポーズした時に表示するゲーム終了ボタンのプレハブ
    private GameObject gameEndButtonPrefab;
    //　ゲーム終了ボタンのインスタンス
    private GameObject gameEndButtonInstance;

    [SerializeField]
    //　ポーズした時に表示する戻るボタンのプレハブ
    private GameObject backButtonPrefab;
    //　戻るボタンのインスタンス
    private GameObject backButtonInstance;

    // 現在選択中のボタン
    int nowSelect;

    // 入力を制限するフラグ
    bool fixedFlg;

    void Start()
    {
        nowSelect = 0;
        fixedFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ボタンを選択
        ButtonSelect_Stick(Input.GetAxis("L_Stick_V"));

        // 選択を実行
        RunSelection();

        Debug.Log(nowSelect);
    }

    /// <summary>
    /// 選択肢を実行します
    /// </summary>
    void RunSelection()
    {
        // メニューを開く
        if (Input.GetKeyDown("joystick button 2"))
        {

            if (menuUIInstance == null)
                // オブジェクトを生成
                ObjectInstantiate();
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            //if (menuUIInstance == null)
            //    // オブジェクトを生成
            //    ObjectInstantiate();

            if (menuUIInstance)
            {
                //if(nowSelect == 0)
                    // サウンド設定を開く

                if (nowSelect == 1)
                    // ゲームを終了する
                    EndGame();
                if (nowSelect == 2)
                    // メニューを閉じる
                    ObjectDestroy();

            }
        }
    }

    /// <summary>
    /// スティックでボタンを選択します
    /// </summary>
    void ButtonSelect_Stick(float ls)
    {

        if (ls != 0)
        {
            if (fixedFlg==false)
            {
                if (ls > 0) nowSelect--;
                if (ls < 0) nowSelect++;

                if (nowSelect > 2) nowSelect = 0;
                if (nowSelect < 0) nowSelect = 2;

                fixedFlg = true;
            }
        }
        else
            fixedFlg = false;
    }

    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    void EndGame()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// オブジェクトの生成
    /// </summary>
    void ObjectInstantiate()
    {
        menuUIInstance = GameObject.Instantiate(menuUIPrefab, GameObject.Find("Canvas").transform);
        //soundInstance = GameObject.Instantiate(soundButtonPrefab, menuUIInstance.transform);
        gameEndButtonInstance = GameObject.Instantiate(gameEndButtonPrefab, menuUIInstance.transform);
        backButtonInstance = GameObject.Instantiate(backButtonPrefab, menuUIInstance.transform);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// オブジェクトの破壊
    /// </summary>
    void ObjectDestroy()
    {
        Destroy(menuUIInstance);
        //Destroy(soundInstance);
        Destroy(gameEndButtonInstance);
        Destroy(backButtonInstance);
        nowSelect = 0;
        Time.timeScale = 1.0f;
    }
}
