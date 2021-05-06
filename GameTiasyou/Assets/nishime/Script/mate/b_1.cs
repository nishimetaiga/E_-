using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_1 : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed;

    public int  de;
    private int _de;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;

        _de++;

        if (de<_de)
        {
            Destroy(gameObject);
        }
    }
}
