using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Strat_Control : MonoBehaviour
{


    public Image strat_color;
    public Image end_color;

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
            strat_color.color = ap_max;
            end_color.color = ap_alpha;
        }
        else if (select == 1)
        {
            strat_color.color = ap_alpha;
            end_color.color = ap_max;
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
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

}
