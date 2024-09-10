using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PortalTriggerScript : MonoBehaviour
{
    public AudioSource portalSound;
    public Image FadePanel;
    public string sceneToLoad;
    public float fadeSpeed = 1.0f;
    private bool isFading = false;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        // set canvas to the canvas object that the fade panel is a child of
        canvas = FadePanel.GetComponentInParent<Canvas>();
        // set the fade panel's alpha to 0
        FadePanel.canvasRenderer.SetAlpha(0.0f);
        // disable the fade panel's parent canvas
        canvas.enabled = false;
    }

    // Called when the player enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IgnorePortal")
        {
            return;
        }
        
        if (portalSound != null)
        {
            portalSound.Play();
        }
        if (!isFading)
        {
            StartCoroutine(FadeToBlack());
        }
    }

    // Fade to white
    IEnumerator FadeToBlack()
    {
        // enable the canvas
        canvas.enabled = true;
        isFading = true;
        FadePanel.CrossFadeAlpha(1.0f, fadeSpeed, false);
        yield return new WaitForSeconds(fadeSpeed);
        Debug.Log("fade Done");
        // wait for the sound to finish playing
        if (portalSound != null)
        {
            yield return new WaitForSeconds(portalSound.clip.length);
        }
        // load the next scene
        Debug.Log("Loading Scene");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        Debug.Log("Scene Loaded");
    }
}
