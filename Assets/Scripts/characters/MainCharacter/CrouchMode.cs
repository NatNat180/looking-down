using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchMode : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isCrouching())
        {
			Rush();
			Roll();
			Hide();
        }
    }

    private bool isCrouching()
    {
        return MainCharacterController.movementMode.Equals(MovementOptions.Crouch);
    }

    private void Rush()
    {

    }

    private void Roll()
    {

    }

    private void Hide()
    {

    }
}
