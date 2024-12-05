using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBCamToggle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.G;
    public KeyCode toggleControllerKey = KeyCode.JoystickButton3;
    public bool isOn = false;
    private Camera gbCam;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        gbCam = GetComponent<Camera>();
        mainCam = gbCam.transform.parent.GetComponent<Camera>();

        // set the correct camera to be active
        gbCam.enabled = isOn;
        mainCam.enabled = !isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey) || Input.GetKeyDown(toggleControllerKey))
        {
            isOn = !isOn;
        }   

        gbCam.enabled = isOn;
        mainCam.enabled = !isOn;
    }
}
