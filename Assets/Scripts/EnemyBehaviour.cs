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
    int playerSpotted;

    // Use this for initialization
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        enemyRenderer = enemyBody.GetComponent<Renderer>();
        playerSpotted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerDetected = false;
        enemyRay = new Ray(enemyBody.transform.position, transform.TransformDirection(Vector3.forward));
        /* if rayCast location @ enemyBody position detects player collider, set to true */
        if (Physics.Raycast(enemyRay, out rayHit) && rayHit.collider.tag.Equals("Player"))
        {
            isPlayerDetected = true;
        }

        /* check that currentWayPoint iteration is less than wayPointList length - that enemy has somewhere to move */
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (isPlayerDetected)
            {
                playerSpotted++;
                //jump();
                speed = 5f;
                enemyRenderer.material.color = Color.red;
                targetWayPoint = playerBody.transform;
                targetDirection = playerBody.position - transform.position;
            }
            else
            {
                playerSpotted = 0;
                speed = 3f;
                enemyRenderer.material.color = Color.black;
                targetWayPoint = wayPointList[currentWayPoint];
                targetDirection = targetWayPoint.position - transform.position;
            }

            move();
        }
        else
        {
            currentWayPoint = 0;
        }

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
            targetWayPoint = wayPointList[currentWayPoint];
        }

    }

    /* jump animation for fun - will be removed later */
    void jump()
    {
        if (playerSpotted <= 1)
        {
            transform.Translate(0f, 0.5f, 0f);
        }
        else if (playerSpotted == 4)
        {
            transform.Translate(0f, -0.5f, 0f);
        }

    }

}
