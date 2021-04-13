using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
//private Vector3 tmp;
 //   public GameObject floorObj;
    private void Start()
    {

     //   tmp = this.transform.position;
    }
    void Update()
    {
        //this.transform.position += new Vector3(0, 0, 0.2f);
        this.transform.position -= new Vector3(0, 0, 0.2f);

    }
}
