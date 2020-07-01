using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatAudio : MonoBehaviour {

    private AudioSource source;
    private float pitchMax = 2.8f;
    private float pitchMin = 1.0f;
    private float pitchCurrent;

    private float time;

    public bool increase;
    public bool decrease;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        time = 0.5f;
        pitchCurrent = source.pitch;
        increase = false;
        decrease = false;
    }
	
	// Update is called once per frame
	void Update () {
        //print("Pitch: " + pitchCurrent);

        
        if(increase) // increase the heart sample pitch
        {
          
            if(pitchCurrent / pitchMax < 1)
            {
                increase = false;
                print("inc comp");
            }
            pitchCurrent = source.pitch;
            source.pitch = Mathf.Lerp(pitchCurrent, pitchMax, time);

        }
        else if(decrease) // decrease the heart sample pitch
        {
            pitchCurrent = source.pitch;
            source.pitch = Mathf.Lerp(pitchCurrent, pitchMin, time);
            if (pitchCurrent <= pitchMin)
            {
                decrease = false;
                //print("dec comp");
            }
        }

	}

    public void IncreaseHeartRate()
    {
        decrease = false;
        increase = true;
    }
    public void DecreaseHeartRate()
    {
        decrease = true;
    }
}
