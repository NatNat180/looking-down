using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    private Rigidbody character;
    private Collider characterCollider;
    public GameObject goal;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Rigidbody>();
        characterCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        character.velocity = transform.forward * moveSpeed * move;
        transform.Rotate(Vector3.up * rotationSpeed * rotate * Time.deltaTime);

    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        transform.localPosition = new Vector3(transform.localPosition.x, 0.75f, transform.localPosition.z);
    }
}
