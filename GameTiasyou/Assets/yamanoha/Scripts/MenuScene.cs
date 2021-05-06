using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject menuUIPrefab;
    //　ポーズUIのインスタンス
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


    // Update is called once per frame
    void Update()
    {

        // メニューを開く
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (menuUIInstance == null)
            {
                menuUIInstance = GameObject.Instantiate(menuUIPrefab, GameObject.Find("Canvas").transform);
                //soundInstance = GameObject.Instantiate(soundButtonPrefab, GameObject.Find("Canvas").transform);
                gameEndButtonInstance = GameObject.Instantiate(gameEndButtonPrefab, GameObject.Find("Canvas").transform);
                backButtonInstance = GameObject.Instantiate(backButtonPrefab, GameObject.Find("Canvas").transform);
                Time.timeScale = 0f;
            }

            //Debug.Log("button0");
            //Invoke("EndGame", 0.1f);
        }

        // サウンド設定を開く
        if (Input.GetKeyDown("joystick button 2"))
        {
            if(soundInstance != null)
            {

            }
        }

        // ゲームを終了する
        if (Input.GetKeyDown("joystick button 1"))
        {
            if (gameEndButtonInstance != null)
                EndGame();
        }

        // メニューを閉じる

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (backButtonInstance != null)
            {
                Destroy(menuUIInstance);
                //Destroy(soundInstance);
                Destroy(gameEndButtonInstance);
                Destroy(backButtonInstance);
                Time.timeScale = 1.0f;
            }
        }
    }

    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    void EndGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
