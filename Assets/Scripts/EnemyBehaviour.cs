using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private Rigidbody enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast(enemy.transform.position, transform.TransformDirection(Vector3.forward), 10)) {
			transform.Translate(Vector3.forward * Time.deltaTime * 3);
		}
	}
}
