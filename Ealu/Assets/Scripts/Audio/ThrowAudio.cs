using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAudio : MonoBehaviour {

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();	
	}
	
    public void PlayThrowSample()
    {
        source.Play();
    }
}
