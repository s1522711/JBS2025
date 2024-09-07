using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FunMode : MonoBehaviour
{
    [Header("Fun Mode Settings")]
    public bool funModeEnabled = false;
    public KeyCode funModeKey = KeyCode.F;
    public float funModeMaxAirSpeed = 1000f;
    public float funModeAirAcceleration = 50f;
    public float funModeJumpForwardsSpeed = 30f;
    public float funModeJumpUpwardsSpeed = 30f;
    public float maxGroundSpeed = 20f;

    [Header("UI Settings")]
    public Image funModePanel;
    public float animationTime = 0.8f;
    private bool anim = false;


    private ExampleCharacterController ecc;
    private float originalMaxAirSpeed;
    private float originalAirAcceleration;
    private float originalJumpForwardsSpeed;
    private float originalJumpUpwardsSpeed;
    private float originalMaxGroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ecc = GetComponent<ExampleCharacterController>();
        originalMaxAirSpeed = ecc.MaxAirMoveSpeed;
        originalAirAcceleration = ecc.AirAccelerationSpeed;
        originalJumpForwardsSpeed = ecc.JumpScalableForwardSpeed;
        originalJumpUpwardsSpeed = ecc.JumpUpSpeed;
        originalMaxGroundSpeed = ecc.MaxStableMoveSpeed;

        if (funModePanel != null)
        {
            // reset the position of the panel
            funModePanel.rectTransform.anchoredPosition = new Vector2(0 - funModePanel.rectTransform.rect.width, 0 - funModePanel.rectTransform.rect.height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(funModeKey))
        {
            funModeEnabled = !funModeEnabled;
            Debug.Log("Fun mode updated: " + funModeEnabled);
        }

        if (funModeEnabled)
        {
            ecc.MaxAirMoveSpeed = funModeMaxAirSpeed;
            ecc.AirAccelerationSpeed = funModeAirAcceleration;
            ecc.JumpScalableForwardSpeed = funModeJumpForwardsSpeed;
            ecc.JumpUpSpeed = funModeJumpUpwardsSpeed;
            ecc.MaxStableMoveSpeed = maxGroundSpeed;
            if (funModePanel != null && !anim)
            {
                // show the panel
                anim = true;
                funModePanel.rectTransform.DOAnchorPos(new Vector2(funModePanel.rectTransform.rect.width*2, funModePanel.rectTransform.rect.height*2), animationTime);
            }
        }
        else
        {
            ecc.MaxAirMoveSpeed = originalMaxAirSpeed;
            ecc.AirAccelerationSpeed = originalAirAcceleration;
            ecc.JumpScalableForwardSpeed = originalJumpForwardsSpeed;
            ecc.JumpUpSpeed = originalJumpUpwardsSpeed;
            ecc.MaxStableMoveSpeed = originalMaxGroundSpeed;
            
            if (funModePanel != null)
            {

                // hide the panel
                funModePanel.rectTransform.DOAnchorPos(new Vector2(0 - funModePanel.rectTransform.rect.width, 0 - funModePanel.rectTransform.rect.height), animationTime).OnComplete(() => anim = false);
            }
        }

    }
}
