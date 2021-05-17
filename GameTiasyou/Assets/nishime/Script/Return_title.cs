using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return_title : MonoBehaviour
{
    public Text title_return;


    //public Color ap_alpha = new Color(255, 255, 255, 0);

    //public bool flg = false;

    //public float ap_speed;

    //public float ap = 0;

    //public float ap_max;
    //public float ap_min;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Invoke("UI_con", 0.6f);

        UI_con();


    }

    void UI_con()
    {

        //if (flg == true)
        //{
        //    if (ap_max <= ap)
        //    {
        //        flg = false;
        //    }
        //    else
        //    {
        //        ap += ap_speed;
        //    }


        //}
        //else if (flg == false)
        //{
        //    if (ap_min >= ap)
        //    {
        //        flg = true;
        //    }
        //    else
        //    {
        //        ap -= ap_speed;
        //    }

        //}

        //title_return.color = new Color(255, 255, 255, ap);

        if (Input.GetKeyDown("joystick button 0"))
        {
            Invoke("ChangeScene", 0.8f);
        }
    }

    void ChangeScene()
    {
            SceneManager.LoadScene("TitleScene");
        
    }
}
