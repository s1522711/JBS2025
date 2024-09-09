using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwitchSceneAfterPlaybackIsOver : MonoBehaviour
{
    [Header("Scene to load")]
    public string sceneToLoad;

    [Header("Audio")]
    public AudioSource skipSound;
    public float audioDelay = 0.0f;

    [Header("Video")]
    [SerializeField] public string videoName = "IntroCutscene.mp4";
    private VideoPlayer vp;

    void Start()
    {
        // disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // get the video player component
        vp = GetComponent<VideoPlayer>();
        // play the video
        vp.url = System.IO.Path.Combine (Application.streamingAssetsPath,videoName);
        vp.Play();
        // set the video player to call the EndReached function when the video has finished playing
        vp.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses the space key, skip the video and load the next scene
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            StartCoroutine(LoadNextScene());
        }   
    }
    
    // load the next scene after the video has finished playing
    void EndReached(VideoPlayer vp)
    {
        skipSound = null;
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        // play the skip sound
        if (skipSound != null)
        {
            skipSound.Play();
            yield return new WaitForSeconds(skipSound.clip.length+audioDelay);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
