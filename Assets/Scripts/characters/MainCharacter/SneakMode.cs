using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakMode : MonoBehaviour, PlayMode
{

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isSneaking())
        {
            Swift();
            Steady();
            Vault();
            Action();
        }
    }

    private bool isSneaking()
    {
        return MainCharacterController.playMode.Equals(PlayOptions.Sneak);
    }

    /* hold button options */
    public void Swift()
    {
        if (Input.GetButton("Swift"))
        {
            Debug.Log("Player is swift");
        }
    }

    public void Steady()
    {
        if (Input.GetButton("Steady"))
        {
            Debug.Log("Player is steady");
        }
    }

    /* press button options */
    public void Vault()
    {
        if (Input.GetButtonDown("Vault"))
        {
            Debug.Log("Player vaulted");
        }
    }

    public void Action()
    {
        if (Input.GetButtonDown("Action"))
        {
            Debug.Log("Player executed main action");
        }
    }
}
