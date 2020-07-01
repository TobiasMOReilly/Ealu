using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Audio_Voice : MonoBehaviour {

    [SerializeField] private AudioClip playerSpotted;
    [SerializeField] private AudioClip playerLost;
    [SerializeField] private AudioClip returnToPatrol;
    [SerializeField] private AudioClip playerCaught;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();	
	}
	
    public void PlayPlayerSpottedSample()
    {
        source.clip = playerSpotted;
        source.Play();
    }
    public void PlayPlayerLostSample()
    {
        source.clip = playerLost;
        source.Play();
    }
    public void PlayPlayerCaughtSample()
    {
        source.clip = playerCaught;
        source.Play();
    }
    public void PlayReturnToPatrolSample()
    {
        source.clip = returnToPatrol;
        source.Play();
    }
}
