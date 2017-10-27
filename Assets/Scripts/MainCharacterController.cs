using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    private Rigidbody character;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        character.velocity = transform.forward * moveSpeed * move;
        transform.Rotate(Vector3.up * rotationSpeed * rotate * Time.deltaTime);

    }
}
