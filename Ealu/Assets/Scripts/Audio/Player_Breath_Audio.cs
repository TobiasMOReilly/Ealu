using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Breath_Audio : MonoBehaviour {

    [SerializeField] private SO_Player player;
    private AudioSource source;

    private float currentSpeed =0;

    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //check if clip already playing
        if (source.isPlaying == false)
        {
            //print("Curr " + player.CurrentSpeed);
            //if player running OR in range of enemy
            if (player.CurrentSpeed == player.SpeedMax) //Player is running
            {
                source.Play();
            }
            else
            {
                source.Stop();
            }
        }
	}


}
