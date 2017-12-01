using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMode : MonoBehaviour
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
        if (isExploring())
        {
			Jog();
			Jump();
			Examine();
        }
    }

    private bool isExploring()
    {
        return MainCharacterController.movementMode.Equals(MovementOptions.Explore);
    }

    private void Jog()
    {

    }

    private void Jump()
    {

    }

    private void Examine()
    {

    }
}
