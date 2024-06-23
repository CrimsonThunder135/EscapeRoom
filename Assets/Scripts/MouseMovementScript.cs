using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseMovementScript : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;

    float mouseSensitivityX;

    float xRotation = 0f;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;

        mouseSensitivityX = gameState.mouseSensitivity;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityX * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.y, 0f);
    }
}