using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public KeyCode keyToPress = KeyCode.M;
    public KeyCode controllerKeyToPress = KeyCode.JoystickButton7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToPress) || Input.GetKey(controllerKeyToPress))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}
