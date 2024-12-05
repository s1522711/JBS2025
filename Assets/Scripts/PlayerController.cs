using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 moveInput;
    public float speed;
    private Vector3 PlayerVelocity;
    private bool grounded;
    public float gravity = -9.8f;
    public float jumpForce = 2f;
    public Camera cam;
    private Vector2 lookPos;
    private float xRotation = 0f;
    public float xSens = 30f;
    public float ySens = 30f;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookPos = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        movePlayer();
        playerLook();
    }

    public void movePlayer()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        PlayerVelocity.y += gravity * Time.deltaTime;
        if (grounded && PlayerVelocity.y < 0)
        {
            PlayerVelocity.y = -2f;
        }
        controller.Move(PlayerVelocity * Time.deltaTime);
    }

    public void jump()
    {
        if (grounded)
        {
            PlayerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }
    }

    public void playerLook()
    {
        xRotation -= lookPos.y * xSens * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * lookPos.x * xSens * Time.deltaTime);
    }
    
}
