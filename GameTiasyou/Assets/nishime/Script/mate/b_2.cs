﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_2 : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;

    public int de;
    private int _de;

    public float nerai;
    public bool flg=true;


    private GameObject barrage;
    private GameObject boat;

    private void Start()
    {
        flg = true;
        barrage= GameObject.Find("Barrage");
        boat = GameObject.Find("Boat_4");
    }
    // Update is called once per frame
    void Update()
    {

        if (boat.transform.position.z - 20 < transform.position.z)
        {
            flg = false;
           
           
        }

        if (flg == true)
        {
            transform.LookAt(boat.transform);
        }
        transform.position += transform.forward * speed;

        


        _de++;



        if (de < _de)
        {
            Destroy(gameObject);
        }
    }
}