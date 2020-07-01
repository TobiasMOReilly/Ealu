using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chase : MonoBehaviour {

    //private Vector3 lastKnownPosition;
    private NavMeshAgent navAgent;
    
    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>(); //Get the nav mesh component
    }
	
    //Got to targets last known position
    public void MoveToLastKnownPosition(Vector3 lastKnownPosition)
    {
        navAgent.SetDestination(lastKnownPosition);
    }
}
