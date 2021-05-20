using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public Image retry_color;
    public Image title_color;

    private int select = 0;

    private bool flg = true;

    public Color ap_alpha = new Color(255, 255, 255, 0);
    private Color ap_max = new Color(255, 255, 255, 255);



    // Update is called once per frame
    void Update()
    {
        float lsv = Input.GetAxis("L_Stick_H");

        if (lsv != 0 && flg == true)
        {
            if (select == 0)
            {
                select = 1;
            }
            else if (select == 1)
            {

                select = 0;
            }

            flg = false;
        }
        else if (lsv == 0)
        {
            flg = true;
        }


        if (select == 0)
        {
            retry_color.color = ap_max;
            title_color.color = ap_alpha;
        }
        else if (select == 1)
        {
            retry_color.color = ap_alpha;
            title_color.color = ap_max;
        }


        if (Input.GetKeyDown("joystick button 0"))
        {
            Invoke("ChangeScene", 0.1f);

        }
    }

    void ChangeScene()
    {
        if (select == 0)
        {
            SceneManager.LoadScene("main");
        }
        else if (select == 1)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
