using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterPlay : MonoBehaviour
{
    void Start()
    {
        // get the length of the audio clip
        float clipLength = GetComponent<AudioSource>().clip.length;
        // destroy the game object after the audio clip has finished playing with some buffer time added
        Destroy(gameObject, clipLength*2);
    }
}
