using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMode : MonoBehaviour, PlayMode
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
            Swift();
            Steady();
            Vault();
            Action();
        }
    }

    private bool isExploring()
    {
        return MainCharacterController.playMode.Equals(PlayOptions.Explore);
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
