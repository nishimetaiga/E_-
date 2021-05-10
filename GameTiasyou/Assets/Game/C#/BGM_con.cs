using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_con : MonoBehaviour
{

    public AudioSource audioSource;

    private bool flg=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 5")&&(flg==true)){
            audioSource.Stop();
            flg = false;

        }else
        if (Input.GetKeyDown("joystick button 5") && (flg == false))
        {
            audioSource.Play();
            flg = true;

        }

        

        
    }
}
