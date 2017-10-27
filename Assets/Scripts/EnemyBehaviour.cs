using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody enemyBody;
    private Renderer enemyRenderer;
    Ray enemyRay;
	RaycastHit rayHit;

    // Use this for initialization
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        enemyRenderer = enemyBody.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRay = new Ray(enemyBody.transform.position, transform.TransformDirection(Vector3.forward));
        /* if rayCast location @ enemyBody position detects player collider */
        if (Physics.Raycast(enemyRay, out rayHit) && rayHit.collider.tag.Equals("Player"))
        {
            /* change color of enemyRenderer */
            enemyRenderer.material.color = Color.cyan;
            /* move forward */
            //transform.Translate(Vector3.forward * Time.deltaTime * 3);

        }
        else
        {
            enemyRenderer.material.color = Color.black;
        }
    }
}
