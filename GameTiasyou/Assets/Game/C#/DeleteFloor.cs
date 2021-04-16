using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFloor : MonoBehaviour
{
    private Vector3 tmp;
    public GameObject FloorObj;
    //private void Start()
    //{
    //    tmp = this.transform.position;
    //}
     void Update()
    {

        tmp = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        //タグが　Player　のオブジェクトが触れたときに処理が行われる
        if (other.gameObject.tag == "Player")
        {
            //確認用
            //Debug.Log("すり抜けた！");
            //Instantiate(FloorObj, new Vector3(tmp.x, tmp.y, tmp.z - 49.0F), Quaternion.identity);
            //Instantiate(FloorObj, new Vector3(tmp.x, tmp.y, tmp.z + 49.0F), Quaternion.identity);
            Instantiate(FloorObj, new Vector3(tmp.x, tmp.y, tmp.z + 149.0F), Quaternion.identity);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //タグが　Player　のオブジェクトが触れたときに処理が行われる
        if (other.gameObject.tag == "Player")
        {
            //確認用
            //Debug.Log("通り抜けた！");
            Destroy(gameObject);
        }

    }
}
