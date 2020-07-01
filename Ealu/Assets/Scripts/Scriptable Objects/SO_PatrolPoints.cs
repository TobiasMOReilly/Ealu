using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Object/Patrol Points")]

public class SO_PatrolPoints : ScriptableObject {

    [SerializeField] private List<Transform> patrolPoints;

    //return list of possible patrol points
    public List<Transform> getPatrolList()
    {
        return patrolPoints;
    }
}
