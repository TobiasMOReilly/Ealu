using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepAudio : MonoBehaviour {

    [SerializeField] SO_Player player;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }
	

    public void PlayerFootStep()
    {
        source.Play();
    }
}
