using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5");
        Invoke("ChangeScene", 0.1f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Result");
    }
}