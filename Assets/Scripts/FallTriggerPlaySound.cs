using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerPlaySound : MonoBehaviour
{
    public AudioSource fallSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fallSound.Play();
        }
    }
}
