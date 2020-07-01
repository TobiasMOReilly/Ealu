using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Blockade : MonoBehaviour {

    [SerializeField] private SO_GameEvent playerLostEvent;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            playerLostEvent.Raise();
            source.Play();
        }
    }
}
