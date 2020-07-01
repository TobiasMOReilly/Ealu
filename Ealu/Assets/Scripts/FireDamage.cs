using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {

    private GameObject player;
    private Coroutine last;

    // Use this for initialization
    void Start () {
		
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11) // if the collider is the player
        {
            player = other.gameObject;
            //start damage coroutine
            last = StartCoroutine(DamagePlayer());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11) // if the collider is the player
        {
            player = other.gameObject;
            //stop damage coroutine
            StopCoroutine(last);
            print("stop ");
            
        }
    }

    IEnumerator DamagePlayer()
    {
        while (true)
        {
            StartCoroutine(player.GetComponent<PlayerHealth>().DecHealth());
            yield return new WaitForSeconds(1);
        }
    }
}
