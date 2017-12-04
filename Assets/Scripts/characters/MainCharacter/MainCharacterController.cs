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
    public static PlayOptions playMode;

    void Start()
    {
        character = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
        characterNormalScale = transform.localScale;
        playMode = PlayOptions.Explore;
    }

    void Update()
    {
        TorchGrabDetect();
        ChoosePlayMode();
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

    private void ChoosePlayMode()
    {
        PlayOptions currentPlayMode = playMode;
        Debug.Log("Current play mode = " + currentPlayMode);
        if (Input.GetButtonDown("TogglePlayModeRight"))
        {
            switch (currentPlayMode)
            {
                case PlayOptions.Explore:
                    playMode = PlayOptions.Combat;
                    break;

                case PlayOptions.Sneak:
                    playMode = PlayOptions.Explore;
                    break;

                case PlayOptions.Combat:
                    playMode = PlayOptions.Sneak;
                    break;
            }
        }

        if (Input.GetButtonDown("TogglePlayModeLeft"))
        {
            switch (currentPlayMode)
            {
                case PlayOptions.Explore:
                    playMode = PlayOptions.Sneak;
                    break;

                case PlayOptions.Sneak:
                    playMode = PlayOptions.Combat;
                    break;

                case PlayOptions.Combat:
                    playMode = PlayOptions.Explore;
                    break;
            }
        }
    }
    
    private void Move()
    {
        // Default movement and scale (a.k.a Explore movement mode)
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.localScale = characterNormalScale;

        // Determine current play mode to set movement speed and scale of character
        if (playMode == PlayOptions.Combat)
        {
            // Create a vector in the direction the character is facing with a magnitude based on the input, speed and time between frames
            movement = transform.forward * moveInput * (moveSpeed * 2) * Time.deltaTime;
        }
        else if (playMode == PlayOptions.Sneak)
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

}
