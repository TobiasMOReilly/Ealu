using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    private FieldOfView fOV;
    private Chase chase;
    private PatrolV2 patrol;
    private NavMeshAgent agent;

    private bool playerInSight;
    private bool playerLost;
    private bool chasing;
    private bool scanning;
    private bool waiting;
    private bool rotating;

    Quaternion startRot;
    Quaternion rotationDest;
    float rotationProg;

    // Use this for initialization
    void Start () {
        fOV = GetComponent<FieldOfView>();
        patrol = GetComponent<PatrolV2>();
        chase = GetComponent<Chase>();
        agent = GetComponent<NavMeshAgent>();

        playerInSight = false;
        playerLost = false;
        chasing = false;
        waiting = false;
        rotating = false;

    }
	
	// Update is called once per frame
	void Update () {

        //Draw Field of View
        fOV.DrawFieldOfView();

        //Check if player in view
        if (fOV.PlayerInView())
        { playerInSight = true; print("INVIEW"); }
        else
            playerInSight = false;

        //IF player in view, chase player
        if (playerInSight)
        {
            chasing = true;
            print("I see player");
            chase.MoveToLastKnownPosition(fOV.GetLastKnownPosition());
        }
        //If chasing player and lost player
        if (chasing && !playerInSight)
        {
            scanning = true;
            //continue to players last known position
            print("Going to last known");

            Vector3 lastKnow = fOV.GetLastKnownPosition();
            chase.MoveToLastKnownPosition(lastKnow);
            
            //scan the area
            print("Scanning area");
            if (transform.position.x == lastKnow.x && transform.position.z == lastKnow.z)
            {
                print("At Last Known pos");
                agent.isStopped = true;

                //Rotate to look around
                if (!rotating)
                    StartRotation();

                if (!waiting)
                {
                    waiting = true;
                    StartCoroutine(Wait());
                }
            }
        }

        //else patrol the map
        if(!playerInSight && !chasing && !scanning)
        {
            //print("Patroling");
            patrol.MoveToPoint();
        }
    }

    IEnumerator Wait()
    {
        print("Waiting");
        waiting = true;
        yield return new WaitForSeconds(3);
        ResetChecks();

        agent.isStopped = false;
        print("Waiting Finnished");
    }

    //Reset bools
    private void ResetChecks()
    {
        playerInSight = false;
        playerLost = false;
        chasing = false;
        scanning = false;
        waiting = false;
        rotating = false;
    }
    private void StartRotation()
    {
        startRot = transform.rotation;
        rotationDest = Quaternion.Euler(transform.rotation.x, 345f, transform.rotation.z);
        rotationProg = 0;
    }

    private void Rotate()
    {
        if (rotationProg < 1 && rotationProg >= 0)
        {
            rotationProg += Time.deltaTime * 5;

            // Here we assign the interpolated rotation to transform.rotation
            // It will range from startRotation (rotationProgress == 0) to endRotation (rotationProgress >= 1)
            transform.rotation = Quaternion.Lerp(startRot, rotationDest, rotationProg);
        }
    }
}
