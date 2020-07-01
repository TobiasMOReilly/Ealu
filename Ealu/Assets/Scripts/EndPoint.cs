using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {

    [SerializeField] private SO_GameEvent playerWinEvent;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 11) // if the player enters the collider
        {
            playerWinEvent.Raise();
        }
    }
}
