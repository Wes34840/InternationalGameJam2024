using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform PlayerBody;
    private float _xRot = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRot -= mouseY;
        _xRot = Mathf.Clamp(_xRot, -90f, 90f);


        //Y rotation
        transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        //mouse X (left - right)
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
