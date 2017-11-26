using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGrab : MonoBehaviour
{
    public Transform player;
    public static bool torchGrabbed;
    // Use this for initialization
    void Start()
    {
        torchGrabbed = false;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            torchGrabbed = true;
            
            transform.parent = player.transform;
            /* change Torch Prefab tag to 'Player' for added Enemy detection */
            gameObject.tag = "Player";
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (torchGrabbed== true)
        {
            Destroy(gameObject);
        }
    }
}
