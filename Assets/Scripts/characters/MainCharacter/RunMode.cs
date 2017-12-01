using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMode : MonoBehaviour
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
        if (isRunning())
        {
			Charge();
			Leap();
			Slide();
        }
    }

    private bool isRunning()
    {
        return MainCharacterController.movementMode.Equals(MovementOptions.Run);
    }

    private void Charge()
    {

    }

    private void Leap()
    {

    }

    private void Slide()
    {

    }
}
