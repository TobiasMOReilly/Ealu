using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {
    [SerializeField] private SO_PatrolPoints patrolPointsList;//TEST

    [SerializeField] private List<Transform> possiblePatrolPoints; // list of possible patrol points
    [SerializeField] private List<Transform> currentPatrolPoints; // list of current patrol points
    [SerializeField] private int patrolRouteLength; //lenght of the patrol route
    private NavMeshAgent navAgent; // ref to enemy nav mesh agent

    private int destination = -1; //the current destination of the enemy

    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>(); //Get the nav mesh component
        SelectPatrolPointsV2(); //Select the points to patrol
    }
	
	// Update is called once per frame
	void Update () {
        patrolMap(); // Start Patroling the map
    }

    //Select patrol points
    private void SelectPatrolPoints()
    {
        while (currentPatrolPoints.Count < patrolRouteLength)
        {
            int randNum = Random.Range(0, possiblePatrolPoints.Count); //Generate a random numeber between 0 and length of possiblePoints list
            if (!IsDuplicate(possiblePatrolPoints[randNum])) // Check that the point is not a duplicate
            {
                currentPatrolPoints.Add(possiblePatrolPoints[randNum]); //Add the point the the list of patrol points
            }
        }

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

    //Find the closest patrol point (Working)
    private int FindClosestPoint()
    {
        float smallestDist = Vector3.Distance(transform.position, currentPatrolPoints[0].position);
        int shortest = 0;

        for (int i = 0; i < currentPatrolPoints.Count; i++)
            if (Vector3.Distance(transform.position, currentPatrolPoints[i].position) < smallestDist)
            {
                smallestDist = Vector3.Distance(transform.position, currentPatrolPoints[i].position);
                shortest = i;
            }

        return shortest;
    }


    //Patrol the map method
    public void patrolMap()
    {
        //Check if currently off route or at last patrol point.
        if (destination == -1) // If Currently not on route go to the closes patrol point
        {
            destination = FindClosestPoint();
        }
        else if(destination == currentPatrolPoints.Count) //Or heading for the last patrol point
        {
            destination = 0; // set the destination point back to the start of the list
        }
        //Check if arrived at destination
        if(HasArrived(currentPatrolPoints[destination]))
        {
            if(destination == currentPatrolPoints.Count-1)
            {
                destination = 0;
            }
            else
            {
                destination += 1;
            }
        }

        navAgent.SetDestination(currentPatrolPoints[destination].position);
    }

    //Check if the enemy has arrived at the destination
    public bool HasArrived(Transform destination)
    {
        bool arrived = false;

        //if enemy x&y == destination x&y return true else return false
        if (transform.position.x == destination.position.x && transform.position.z == destination.position.z)
        {
            arrived = true;
        }
        return arrived;
    }

    public void IncrementDestination()
    {
        destination += 1;
    }
}
