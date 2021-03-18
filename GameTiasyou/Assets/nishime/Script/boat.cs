using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "teki") {
            Destroy(other.gameObject);
        }
    }


}
