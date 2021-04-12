using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesttCameraPosition : MonoBehaviour
{
    private Vector3 a;
    private void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find("TestPlayer");
        a = playerObj.transform.position;
    }
    private void Update()
    {
        //StartCoroutine("Roto1");
        transform.position = new Vector3(a.x , a.y + 20, a.z - 20);
        transform.rotation = Quaternion.Euler(45, 0, 0);

    }
}
