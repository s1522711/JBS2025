using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTerrorist : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    // save the initial rotation
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void ResetRotation()
    {
        transform.rotation = initialRotation;
    }
}
