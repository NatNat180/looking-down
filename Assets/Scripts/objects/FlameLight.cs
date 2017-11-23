using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameLight : MonoBehaviour
{
    public ParticleSystem flame;
    public Text win;
    private string winText = "YOU WON!!!";

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Player") && (TorchGrab.torchGrabbed == true))
        {
            flame.Play(true);
            win.text = winText;
        }
    }

}
