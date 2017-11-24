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
    Vector3 targetDirection;
    bool isPlayerDetected;
    public Rigidbody playerBody;

    // Use this for initialization
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        enemyRenderer = enemyBody.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerDetected = false;
        // Make enemy line-of-sight slightly higher than default position
        enemyRay = new Ray((enemyBody.transform.position + Vector3.up / 2), transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(enemyRay, out rayHit) && rayHit.collider.tag.Equals("Player"))
        {
            isPlayerDetected = true;
        }

        if (isPlayerDetected)
        {
            speed = 5f;
            enemyRenderer.material.color = Color.red;
            targetWayPoint = playerBody.transform;
            targetDirection = playerBody.position - transform.position;
        }
        else
        {
            speed = 3f;
            enemyRenderer.material.color = Color.green;
            targetWayPoint = wayPointList[currentWayPoint];
            targetDirection = targetWayPoint.position - transform.position;
        }

        move();
    }

    void move()
    {
        float step = speed * Time.deltaTime;

        /* rotate towards the target */
        transform.forward = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);

        /* move towards the target */
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, step);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            /* restart waypoint loop when last waypoint is reached */
            if (currentWayPoint >= wayPointList.Length)
            {
                currentWayPoint = 0;
            }
            targetWayPoint = wayPointList[currentWayPoint];
        }

    }

}
