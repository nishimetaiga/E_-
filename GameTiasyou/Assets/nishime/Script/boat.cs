using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //キャラクターをワールド座標で動かす
        //transform.eulerAngles += new Vector3(0f, 0f, speed * Time.deltaTime);               //旋回用
       //transform.position += -transform.up *speed * Time.deltaTime;    //発進

    }
}
