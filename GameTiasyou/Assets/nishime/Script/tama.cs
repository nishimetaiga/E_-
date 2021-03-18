//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// Transform.RotateAroundを用いた円運動
///// </summary>
//public class tama : MonoBehaviour
//{

//    public GameObject to;
//    public GameObject uro;

//    public float speed;


//    private void Update() {
//        var te = transform.rotation;
//        this.transform.LookAt(uro.transform);
//        GameObject bullet = (GameObject)Instantiate(to, transform.position, Quaternion.Euler(0f,0f, 70f));

//        Debug.Log(te);
//    }
//}