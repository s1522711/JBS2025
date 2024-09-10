using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrigger : MonoBehaviour
{
    // when an object enters the trigger, destroy it
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("tag: " + other.tag);
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("Destroyed object");
        }
    }
}
