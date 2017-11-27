using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{

    private float moveInput;
    private float rotateInput;
    public float moveSpeed;
    public float rotationSpeed;
    private Rigidbody character;
    private Collider characterCollider;
    private Vector3 characterNormalScale;
    public GameObject PlayerTorch;
    private enum MovementOptions { Crouch, Explore, Run };
    private MovementOptions movementMode;

    void Start()
    {
        character = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
        characterNormalScale = transform.localScale;
        movementMode = MovementOptions.Explore;
    }

    void Update()
    {
        TorchGrabDetect();
        ChooseMovementMode();
        moveInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    
    private void TorchGrabDetect()
    {
        if (TorchGrab.torchGrabbed == true)
        {
            PlayerTorch.SetActive(true);
        }
    }

    private void Move()
    {
        // Default movement and scale
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.localScale = characterNormalScale;

        // Determine current movement mode to set movement speed and scale of character
        if (movementMode == MovementOptions.Run)
        {
            // Create a vector in the direction the character is facing with a magnitude based on the input, speed and time between frames
            movement = transform.forward * moveInput * (moveSpeed * 2) * Time.deltaTime;
        }
        else if (movementMode == MovementOptions.Crouch)
        {
            // Create a vector in the direction the character is facing with a magnitude based on the input, speed and time between frames
            movement = transform.forward * moveInput * (moveSpeed / 2) * Time.deltaTime;
            // Reduce y-axis local scale
            transform.localScale = characterNormalScale + Vector3.down / 2;
        }

        // Apply movement to the rigidbody's position
        character.MovePosition(character.position + movement);

    }

    private void Rotate()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames 
        float rotate = rotateInput * rotationSpeed * Time.deltaTime;

        // Make this into a rotation in the y-axis
        Quaternion turnRotation = Quaternion.Euler(0, rotate, 0);

        // Apply this rotation to the rigidbody's rotation
        character.MoveRotation(character.rotation * turnRotation);
    }
    
    private void ChooseMovementMode()
    {
        MovementOptions currentMovementMode = movementMode;
        Debug.Log("Current movement mode = " + currentMovementMode);
        if (Input.GetButtonDown("ToggleMovementModeRight"))
        {
            switch (currentMovementMode)
            {
                case MovementOptions.Explore:
                    movementMode = MovementOptions.Run;
                    break;

                case MovementOptions.Crouch:
                    movementMode = MovementOptions.Explore;
                    break;

                case MovementOptions.Run:
                    movementMode = MovementOptions.Crouch;
                    break;
            }
        }

        if (Input.GetButtonDown("ToggleMovementModeLeft"))
        {
            switch (currentMovementMode)
            {
                case MovementOptions.Explore:
                    movementMode = MovementOptions.Crouch;
                    break;

                case MovementOptions.Crouch:
                    movementMode = MovementOptions.Run;
                    break;

                case MovementOptions.Run:
                    movementMode = MovementOptions.Explore;
                    break;
            }
        }
    }
}
