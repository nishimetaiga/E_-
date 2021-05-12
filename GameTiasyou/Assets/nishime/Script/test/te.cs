using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class te : MonoBehaviour
{

    public GameObject W_trace;  //prefabデータ
    public List<GameObject> trace;//instance化オブジェクト
    private Vector3 trace_pos;

    private bool put_flg=true;

    public float speed;

    private GameObject boat;

    

    private int count;
    private int des;

    public float haba;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        des = 0;
        boat=GameObject.Find("Boat_4");

    }

    // Update is called once per frame
    void Update()
    {
        if (put_flg == true)
        {
            output();
            
        }
        trace_Move();

    }

    void output()
    {
        trace.Add(Instantiate(W_trace, boat.transform.position, Quaternion.Euler(0, 0, 0)));
        trace_pos = trace[count].transform.position;
        put_flg = false;
    }

    void trace_Move()
    {
        for (int i = des; i < count+1; i++)
        {
            trace[i].transform.position += trace[i].transform.forward * -speed;
        }
        if (trace[count].transform.position.z < trace_pos.z - haba)
        {
            put_flg = true;
            count++;
        }
    }
}
