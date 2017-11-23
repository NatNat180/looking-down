using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public void cutToShot()
	{
		Camera.main.transform.localPosition = transform.position;
		Camera.main.transform.localRotation = transform.rotation; 
	}

}
