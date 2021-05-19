using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_1 : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;

    public int dead_mx;
    public int _dead;


    public GameObject barrage;
 

    private void Start()
    {
     
        barrage = GameObject.Find("Barrage");
    }

    public void move()
    {

        transform.position += transform.forward * speed;
        _dead++;

  

        if (dead_mx < _dead)
        {
            Destroy(gameObject);
            barrage.GetComponent<barrage01>().dead_count++;
            int d = barrage.GetComponent<barrage01>().dead_count;
            int a = barrage.GetComponent<barrage01>().obj_count;

            if (a == d)
            {
                barrage.GetComponent<Barrage_control>().backup_num = barrage.GetComponent<Barrage_control>().barrage_num;
            }

        }


    }

}




