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
    public GameObject goal;

    void Start()
    {
        character = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
    }

    void Update()
    {

        moveInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // Create a vector in the direction the character is facing with a magnitude based on the input, speed and time between frames
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
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
