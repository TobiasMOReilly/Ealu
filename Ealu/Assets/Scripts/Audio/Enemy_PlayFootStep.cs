using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayFootStep : MonoBehaviour {

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

    }
	
    public void PlayFootStep()
    {
        source.Play();
    }
}
