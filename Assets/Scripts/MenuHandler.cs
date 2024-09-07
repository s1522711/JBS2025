using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [Header("Scenes to load")]
    [SerializeField] public string Button1Scene = "bombStore";

    [SerializeField] public string Button2Scene = "bidenParkour";

    [SerializeField] public string Button3Scene = "jbs2022";

    [Header("Sound")]
    public AudioSource button3StartSound;
    public AudioSource exitClickSound;

    void Start()
    {
        // show the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;   
    }

    public void LoadButton1Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Button1Scene);
    }

    public void LoadButton2Scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Button2Scene);
    }

    public void LoadButton3Scene()
    {
        
        if (button3StartSound != null)
        {
            // play the sound while loading the scene
            button3StartSound.Play();
            DontDestroyOnLoad(button3StartSound.gameObject);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(Button3Scene);
    }

    public void QuitGame()
    {
        StartCoroutine(ExitTheGame());
    }

    IEnumerator ExitTheGame()
    {
        if (exitClickSound != null)
        {
            exitClickSound.Play();
            yield return new WaitForSeconds(exitClickSound.clip.length-1.8f);
        }
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
