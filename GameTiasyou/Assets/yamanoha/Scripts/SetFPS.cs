using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // fps値を 60 に設定
        Application.targetFrameRate = 60;
    }
}
