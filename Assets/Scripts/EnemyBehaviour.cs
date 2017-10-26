using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	private Rigidbody enemyBody;
	private Renderer enemyRenderer;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody>();
		enemyRenderer = enemyBody.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// if rayCast location @ enemyBody position detects (any) collider
		if (Physics.Raycast(enemyBody.transform.position, transform.TransformDirection(Vector3.forward), 10)) {
			// change color of enemyRenderer
			enemyRenderer.material.color = Color.cyan;
			// move forward
			//transform.Translate(Vector3.forward * Time.deltaTime * 3);
		} else {
			enemyRenderer.material.color = Color.black;
		}
	}
}
