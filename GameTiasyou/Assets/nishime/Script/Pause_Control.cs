using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Control : MonoBehaviour
{


    public Image close;
    public Image oudio;
    public GameObject oudio_on;
    public GameObject oudio_off;
    public Image retry;
    public Image title_return;


    private int select = 0;
    private int on_off = 0;

    private bool flg = false;
    private bool oudio_flg = true;

    public AudioSource audioSource;

    public Color ap_alpha = new Color(255, 255, 255, 0);
    private Color ap_max = new Color(255, 255, 255, 255);



    private void Start()
    {


        if (AudioListener.volume == 0)
        {
            oudio_on.SetActive(false);
            oudio_off.SetActive(true);
            oudio_flg = false;
        }
        else
        {
            oudio_on.SetActive(true);
            oudio_off.SetActive(false);
            oudio_flg = true;
        }
    }
    public void pose_con()
    {
        float lsv = Input.GetAxis("L_Stick_V");



        if (lsv != 0 && flg == true)
        {
            if (lsv > 0)
            {
                if (select == 0)
                {
                    select = 3;
                }
                else if (select == 1)
                {
                    select = 0;
                }
                else if (select == 2)
                {
                    select = 1;
                }else if (select == 3)
                {
                    select = 2;
                }
            }
            else if (lsv < 0)
            {
                if (select == 0)
                {
                    select = 1;
                }
                else if (select == 1)
                {
                    select = 2;
                }
                else if (select == 2)
                {
                    select = 3;
                }else if (select == 3) {
                    select = 0;
                
                }
            }

            flg = false;
        }
        else if (lsv == 0)
        {
            flg = true;
        }


        if (select == 0)
        {
            close.color = ap_max;
            oudio.color = ap_alpha;
            retry.color = ap_alpha;
            title_return.color = ap_alpha;
        }
        else if (select == 1)
        {
            close.color = ap_alpha;
            oudio.color = ap_max;
            retry.color = ap_alpha;
            title_return.color = ap_alpha;
        }
        else if (select == 2)
        {
            close.color = ap_alpha;
            oudio.color = ap_alpha;
            retry.color = ap_max;
            title_return.color = ap_alpha;
        }else if (select == 3)
        {
            close.color = ap_alpha;
            oudio.color = ap_alpha;
            retry.color = ap_alpha;
            title_return.color = ap_max;
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            //Invoke("ChangeScene", 0.1f);
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (select == 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (select == 1)
        {
            if (oudio_flg == true)
            {
                AudioListener.volume = 0;
                oudio_off.SetActive(true);
                oudio_on.SetActive(false);
                oudio_flg = false;
            }else if (oudio_flg == false)
            {
                AudioListener.volume = 1;
                oudio_off.SetActive(false);
                oudio_on.SetActive(true);
                oudio_flg = true;

                
            }
        }
        else if (select == 2)
        {
            SceneManager.LoadScene("main");
            Time.timeScale = 1f;

        }else if(select==3)
        {
            SceneManager.LoadScene("TitleScene");
            Time.timeScale = 1f;
        }
    }

}
