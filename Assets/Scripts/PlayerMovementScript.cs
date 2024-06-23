using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField]
    public GameState gameState;

    public float speed = 6f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    float mouseSensitivityY;

    float YRotation = 0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivityY = gameState.mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(gameState.crouch))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            speed = speed / 2;
        }
        if (Input.GetKeyUp(gameState.crouch))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            speed = speed * 2;
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityY * Time.deltaTime;

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;

        //applying both rotations
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, YRotation, 0f);
        
    }
}
