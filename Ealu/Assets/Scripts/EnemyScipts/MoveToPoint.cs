using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour {

    private NavMeshAgent navAgent; // ref to enemy nav mesh agent
    private Vector3 lastKnow;

    private bool atDestination;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    //Move to Point Methods
    public void MoveTo(Transform destination)
    {
        atDestination = false;
        navAgent.SetDestination(destination.position); ;
    }
    public void MoveTo(Vector3 destination)
    {
        atDestination = false;
        lastKnow = destination;
        navAgent.SetDestination(destination); ;
    }

    public bool ArrivedAtPoint()
    {
        bool arrived = false;

        if(transform.position.x == lastKnow.x && transform.position.z == lastKnow.z)
        {
            arrived = true;
        }

        return arrived;
    }
    //Getters
    public bool AtDestination()
    {
        return atDestination;
    }



}
