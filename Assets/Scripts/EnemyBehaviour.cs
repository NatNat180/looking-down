using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody enemyBody;
    private Renderer enemyRenderer;
    Ray enemyRay;
	RaycastHit rayHit;
    public float speed;
    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    Transform targetWayPoint;

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

        /* check that enemy has somewhere to move */
        if (currentWayPoint < this.wayPointList.Length && targetWayPoint == null)
        {
            targetWayPoint = wayPointList[currentWayPoint];
            move();
        }
    }

    void move()
    {
        Vector3 targetDirection = targetWayPoint.position - transform.position;
        float step = speed * Time.deltaTime;
        /* rotate towards the target */
        Vector3 lookDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(lookDirection);
        Debug.Log("transform forward = " + lookDirection);
        /* move towards the target */
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, step);
        Debug.Log("transform position = " + transform.position);
        Debug.Log("target waypoint = " + targetWayPoint.position);
        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}
