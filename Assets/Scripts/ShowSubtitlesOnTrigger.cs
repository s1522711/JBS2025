using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSubtitlesOnTrigger : MonoBehaviour
{
    public Canvas subtitleCanvas;
    // Start is called before the first frame update
    void Start()
    {
        subtitleCanvas.enabled = false;
    }

    // When the player enters the trigger, show the subtitles
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            subtitleCanvas.enabled = true;
        }
    }

    // When the player exits the trigger, hide the subtitles
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            subtitleCanvas.enabled = false;
        }
    }
}
