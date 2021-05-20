using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }
    
    public void Onclick()
    {
        
    }

    void CheckButton()
    {
        if (Input.GetKeyDown("joystick button 0"))
            Debug.Log("このボタンは　A　です");

        if (Input.GetKeyDown("joystick button 1"))
            Debug.Log("このボタンは　B　です");

        if (Input.GetKeyDown("joystick button 2"))
            Debug.Log("このボタンは　X　です");

        if (Input.GetKeyDown("joystick button 3"))
            Debug.Log("このボタンは　Y　です");

        if (Input.GetAxis("L_Stick_V") != 0)
            Debug.Log(Input.GetAxis("L_Stick_V"));
    }

    /// <summary>
    /// 選択肢を実行します
    /// </summary>
    /*void RunSelection()
    {
        // メニューを開く
        if (Input.GetKeyDown("joystick button 2"))
        {
            ObjectInstantiate();
        }

        // サウンド設定を開く
        if (Input.GetKeyDown("joystick button 3"))
        {
            if (soundInstance != null)
            {

            }
        }

        // ゲームを終了する
        if (Input.GetKeyDown("joystick button 1"))
        {
            if (gameEndButtonInstance != null)
                //Debug.Log("button0");
                //Invoke("EndGame", 0.1f);
                EndGame();
        }

        // メニューを閉じる
        if (Input.GetKeyDown("joystick button 0"))
        {
            if (backButtonInstance)
            {
                Destroy(menuUIInstance);
                //Destroy(soundInstance);
                Destroy(gameEndButtonInstance);
                Destroy(backButtonInstance);
                Time.timeScale = 1.0f;
            }
        }
    }*/

    void GoTitleScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}