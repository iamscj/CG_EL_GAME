using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float sensitivity = 10f;
    public float speed = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player around the Y-axis based on mouse input
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera around its local X-axis based on mouse input
        transform.GetChild(0).Rotate(Vector3.left * mouseY);

        // Optionally, move the player forward based on keyboard input
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);
    }
}
