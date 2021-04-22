using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class se_test : MonoBehaviour
{

    void Start()
    {
     }
    public void OnClick()
    {  
        Invoke("ChangeScene", 0.5f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("main");
    }
}