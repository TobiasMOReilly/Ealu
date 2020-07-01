using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hearing : MonoBehaviour {
    //--------Game Object Must Have a Sphere Collider--------//
    [SerializeField] private Transform target;
    [SerializeField] private SO_Player player; //NEW


    private Transform lastKnownPosition;
    private NavMeshAgent navAgent;
    private float maxHearingRange;
    private float currentHearingRange;
    private float crouchReduction;
    private float sprintIncrease;
    private bool isHeard;

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        maxHearingRange = GetComponentInChildren<SphereCollider>().radius;
        crouchReduction = 3f;
        sprintIncrease = 2f;
        isHeard = false;
    }

    //Check if player can be heard
    private bool PlayerHeard(Vector3 targetPos, float maxHearingRange)
    {
        bool heard = false;

        //Calculate if player is close enough to be heard
        NavMeshPath pathToPlayer = new NavMeshPath(); //create a new nav path
        
        //Calculate the path from enemy to player
        if (navAgent.enabled)
            navAgent.CalculatePath(targetPos, pathToPlayer);
        
        //Get all points on path + enemy current pos and target pos
        Vector3[] points = new Vector3[pathToPlayer.corners.Length+2];
        
        //add the enemy pos to first
        points[0] = transform.position;
        
        //add target pos to last
        points[points.Length - 1] = targetPos;

        if (points.Length > 2)
        {
            //add the points inbetween
            //print("PointLength: " + points.Length);
            for (int i = 0; i < points.Length - 2; i++)
            {
                //print("Added points: " + i);
                points[i + 1] = pathToPlayer.corners[i];
            }
        }
        
        //Calculate the length of the path (distance between each point)
        float distance = 0f;
        for (int i = 0; i < points.Length-1; i++)
            distance += Vector3.Distance(points[i], points[i+1]);

        if (distance <= maxHearingRange)
        {
            heard = true;
            //print("HUH!?!?! WHATS THAT NOISE: " + distance);
            lastKnownPosition = target.transform;
        }
        return heard;
    }

    //ONTRIGGER ENTER set last known position
 /**   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            lastKnownPosition = target.transform;
        }
    }**/

    //RUN WHILE PLAYER IN COLLIDER
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Listen();
        }
    }
    //ONTRIGGER EXIT EVENT
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if(isHeard)
                lastKnownPosition = target.transform;
            isHeard = false;
        }
    }

    //Return isHeard
    public bool IsHeard()
    {
        return isHeard;
    }

    //Return LastKnownPos
    public Transform GetLastKnowPosition()
    {
        return lastKnownPosition;
    }

    private void Listen()
    {
        if(player.CurrentSpeed > 0)
        {
            //if the player is crouching hearing range divided by crouchReduction
            if (Input.GetKey("left ctrl"))
                currentHearingRange = maxHearingRange / crouchReduction;
            //if player sprinting hearing range doubled
            else if (Input.GetKey("left shift"))
                currentHearingRange = maxHearingRange * sprintIncrease; //Not working due to collider limit
                                                                        //else hearing range equal to sphere collider size
            else
                currentHearingRange = maxHearingRange;

            if (PlayerHeard(target.position, currentHearingRange)) // CONSTANT POS UDATE ISSUE
            {
                isHeard = true;
            }
            else
                isHeard = false;
        }
        else
            isHeard = false;
    }

    //Allow target to be set externally
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}
