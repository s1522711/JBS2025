using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class winScreen : MonoBehaviour
{
    [Header("Win Screen Elements")]
    public AudioSource winMusic;

    public string sceneToLoad;

    [Header("positions")]
    public float winTextYPositionEnd;
    public float animationTime;

    private RectTransform winTextRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // hide the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // get the RectTransform component of the win text
        winTextRectTransform = GetComponent<RectTransform>();
        // play the animation
        WinTextAnimation();
        // wait for the win music to finish playing before loading the next scene
        StartCoroutine(LoadNextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadNextScene()
    {
        // wait for the win music to finish playing
        if (winMusic != null)
        {
            yield return new WaitForSeconds(winMusic.clip.length);
        }
        else // if there is no win music, wait for the animation to finish
        {
            yield return new WaitForSeconds(animationTime);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    private void WinTextAnimation()
    {
        winTextRectTransform.DOAnchorPosY(winTextYPositionEnd, animationTime).SetEase(Ease.Linear);
    }
}
