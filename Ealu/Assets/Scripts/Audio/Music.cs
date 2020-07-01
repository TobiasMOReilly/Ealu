using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour {

    [SerializeField] private AudioMixerSnapshot patrolSnap;//
    [SerializeField] private AudioMixerSnapshot chaseSnap;//
    [SerializeField] private AudioMixerSnapshot searchSnap;//
    [SerializeField] private float transitionTime;

    private int currentClip;
    private bool switchClip;
    // Use this for initialization
    void Start () {
        switchClip = true;
    }

    private void Update()
    {
        Play();
    }

    private void Play()
    {

        if (switchClip)
        {
            switchClip = false;
            //Load the required clip into current source
            switch (currentClip)
            {
                case 1:
                    patrolSnap.TransitionTo(transitionTime);
                    break;
                case 2:
                    chaseSnap.TransitionTo(transitionTime);
                    break;
                case 3:
                    searchSnap.TransitionTo(transitionTime);
                    break;
                default:
                    patrolSnap.TransitionTo(transitionTime);
                    break;
            }
        }
    }

    //Play Patrol Clip
    public void PlayPatrolMusic()
    {
        currentClip = 1;
        switchClip = true;
    }
    //Play Chase Clip
    public void PlayChaseMusic()
    {
        currentClip = 2;
        switchClip = true;
    }
    //Play Search Clip
    public void PlaySearchMusic()
    {
        currentClip = 3;
        switchClip = true;
    }
}
