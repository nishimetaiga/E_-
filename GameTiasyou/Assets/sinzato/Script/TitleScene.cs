using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6");
            Invoke("ChangeScene", 0.1f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}