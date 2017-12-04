using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMode : MonoBehaviour, PlayMode
{

    void Start()
    {

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        if (isInCombatMode())
        {
            Swift();
            Steady();
            Vault();
            Action();
        }
    }

    private bool isInCombatMode()
    {
        return MainCharacterController.playMode.Equals(PlayOptions.Combat);
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
