using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<Patrol>().IncrementDestination();
        }
    }
}
