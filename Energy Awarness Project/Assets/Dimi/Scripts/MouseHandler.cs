using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    // vertical rotation speed
    private float yRotation = 0.0f;
    private float xRotation = 0.0f;
    private Camera cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = Camera.main.gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //retrieves the x axis of the mouse
        float mouseY = Input.GetAxis("Mouse Y") * horizontalSpeed;
        //retrieves the y axis of the mouse
        float mouseX = Input.GetAxis("Mouse X") * verticalSpeed;

        xRotation = mouseX;
        yRotation = -mouseY;

        yRotation = Mathf.Clamp(yRotation, -90, 90);

        cam.transform.Rotate(yRotation, 0, 0);
        transform.Rotate(0, xRotation, 0);
    }
}
