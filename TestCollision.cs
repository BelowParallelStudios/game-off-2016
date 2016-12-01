using UnityEngine;
using System.Collections;

public class TestCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProxS")
        {
            Debug.Log("this");
        }
    }

}
