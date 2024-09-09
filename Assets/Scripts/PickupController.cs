using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] KeyCode pickupKey = KeyCode.E;
    [SerializeField] KeyCode controllerPickupKey = KeyCode.JoystickButton2;
    private GameObject heldObj;
    private Rigidbody heldObjRb;

    [Header("Physics Parameters")]
    [SerializeField] private float PickupRange = 5.0f;
    [SerializeField] private float PickupForce = 150.0f;
    [SerializeField] private bool disableGravity = true;
    [SerializeField] private bool disableRotation = true;

    [Header("Crosshair Settings")]
    [SerializeField] private bool ChangeCrosshairVisibility = true;
    [SerializeField] private Canvas crosshairCanvas;
    private bool crosshairVisible = true;

    void Update()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange);
        
        if (crosshairCanvas != null && ChangeCrosshairVisibility)
        {
            if (isHit)
            {
                Rigidbody hitRigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (hitRigidbody != null && !crosshairVisible)
                {
                    crosshairCanvas.enabled = true;
                    crosshairVisible = true;
                }
                else if (hitRigidbody == null && crosshairVisible)
                {
                    crosshairCanvas.enabled = false;
                    crosshairVisible = false;
                }
            }
            else if (crosshairVisible)
            {
                crosshairCanvas.enabled = false;
                crosshairVisible = false;
            }
        }
        
        if (Input.GetKeyDown(pickupKey) || Input.GetKeyDown(controllerPickupKey))
        {
            if (heldObj == null)
            {
                if (isHit)
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRb = pickObj.GetComponent<Rigidbody>();
            heldObjRb.useGravity = !disableGravity;
            heldObjRb.drag = 10;
            heldObjRb.constraints = disableRotation ? RigidbodyConstraints.FreezeRotation : RigidbodyConstraints.None;

            heldObjRb.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObjRb.transform.parent = null;
        heldObj = null;
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRb.AddForce(moveDirection * PickupForce);
        }
    }
}
