using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventRaiser : MonoBehaviour {

    [SerializeField] private SO_GameEvent enemyInRange;
    [SerializeField] private SO_GameEvent enemyOutRange;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            print("COLL");
            enemyInRange.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            enemyOutRange.Raise();
        }
    }
}
