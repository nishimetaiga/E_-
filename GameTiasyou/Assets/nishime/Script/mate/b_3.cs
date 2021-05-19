using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_3 : MonoBehaviour
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
    public void move()
    {

        barrage = GameObject.Find("Barrage");
        boat = GameObject.Find("Boat_4");

        if (flg == true || transform.position.z < -18)
        {
            transform.LookAt(boat.transform);
            flg = false;
        }

        transform.position += transform.forward * speed;

        


        _de++;



        if (de < _de)
        {
            Destroy(gameObject);

            barrage.GetComponent<barrage03>().dead_count++;
            int d = barrage.GetComponent<barrage03>().dead_count;
            int a = barrage.GetComponent<barrage03>().obj_count;

            if (a == d)
            {
                barrage.GetComponent<Barrage_control>().backup_num = barrage.GetComponent<Barrage_control>().barrage_num;
            }
        }


    }
}
