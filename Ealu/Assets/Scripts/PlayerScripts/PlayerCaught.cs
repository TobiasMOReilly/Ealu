using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaught : MonoBehaviour {

    [SerializeField] private SO_GameEvent loseEvent;

    private void OnTriggerEnter(Collider other)
    {
        //If the enemy body layer collides with the the player game over
        if(other.gameObject.layer == 14)
        {
            print("PLAYER CAUGHT");
            loseEvent.Raise();
        }
    }
}
