using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHardMode : MonoBehaviour
{
    // list of RotateTerrorist objects to toggle
    public List<RotateTerrorist> objectsToToggle;
    public bool hardMode = false;
    public KeyCode toggleKey = KeyCode.H;
    public KeyCode toggleKeyController = KeyCode.JoystickButton4;

    // Start is called before the first frame update
    void Start()
    {
        // disable all RotateTerrorist objects
        foreach (RotateTerrorist obj in objectsToToggle)
        {
            obj.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey) || Input.GetKeyDown(toggleKeyController))
        {
            hardMode = !hardMode;
        }

        // toggle the RotateTerrorist objects
        foreach (RotateTerrorist obj in objectsToToggle)
        {
            obj.enabled = hardMode;
            if (!hardMode)
            {
                obj.ResetRotation();
            }
        }
    }
}
