using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1");
            EndGame();
        }
    }

    /// <summary>
    /// ゲーム終了処理
    /// </summary>
    void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
