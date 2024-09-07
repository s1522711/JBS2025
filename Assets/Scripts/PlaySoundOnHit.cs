using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    public AudioSource hitSound;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit something");
        hitSound.Play();
    }
}
