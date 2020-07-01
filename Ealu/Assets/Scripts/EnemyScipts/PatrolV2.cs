using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolV2 : MonoBehaviour {
    [SerializeField] private SO_PatrolPoints patrolPointsList;//TEST
    [SerializeField] private List<Transform> currentPatrolPoints; // list of current patrol points
    [SerializeField] private int patrolRouteLength; //length of the patrol route
    [SerializeField] private Collider ignoreCollider;

    private NavMeshAgent navAgent; // ref to enemy nav mesh agent

    private int destination; //the current destination of the enemy
    private bool atDestination;

    // Use this for initialization
    void Start () {
        destination = 0;
        atDestination = true;
        navAgent = GetComponent<NavMeshAgent>(); //Get the nav mesh component
        SelectPatrolPointsV2();
        //MoveToPoint();
    }

    public void MoveToPoint()
    {
        atDestination = false;
        navAgent.SetDestination(currentPatrolPoints[destination].position);
    }

    //Select patrol points
    private void SelectPatrolPointsV2()
    {
        List<Transform> pp = patrolPointsList.getPatrolList();

        while (currentPatrolPoints.Count < patrolRouteLength)
        {
            int randNum = Random.Range(0, pp.Count); //Generate a random numeber between 0 and length of possiblePoints list
            if (!IsDuplicate(pp[randNum])) // Check that the point is not a duplicate
            {
                currentPatrolPoints.Add(pp[randNum]); //Add the point the the list of patrol points
            }
        }

    }

    //Check if point is already selected
    private bool IsDuplicate(Transform checkFor)
    {
        bool result = false;

        foreach (Transform t in currentPatrolPoints)
            if (t.position == checkFor.position)
            {
                result = true;
                break;
            }

        return result;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the object is a Patrol Point
        if (other.gameObject.tag.Equals("PatrolPoint"))
        {
            //If the Patrol Point is the current destination point
            if (other == ignoreCollider)
            {
                print("SKIPPING");
                return;
            }
            else
            {
                if (other.gameObject.transform.position == currentPatrolPoints[destination].position)
                {
                    atDestination = true;
                    //Increment Destination
                    //If at the last patrol point reset
                    if (destination == currentPatrolPoints.Count - 1)
                    {
                        destination = 0;
                    }
                    else
                    {
                        destination += 1;
                    }
                }
            }
        }
    }

    public bool AtDestination()
    {
        return atDestination;
    }
    public Transform GetDestination()
    {
        return currentPatrolPoints[destination];
    }
}
