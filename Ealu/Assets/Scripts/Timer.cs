using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeleftsec, timeleft = 9f;
    [SerializeField] private SO_GameEvent OutOfTime;
    public Text timer;
    private bool timerRunning, timerdone;
    private float timeleftinsec;
    
	void Start () {
        timeleftsec = 59f;
        
        timerRunning = false;
        timerdone = false;
	}
	
	// Update is called once per frame
	void Update () {

        timer.text = "" + timeleft + ":" + timeleftsec;
        if (timeleft == 0 && timeleftsec == 0)
        {
            OutOfTime.Raise();
            timeleftsec = 0;
            timerdone = true;

        }
        else if (timerRunning == false && timerdone == false )
        {
            StartCoroutine(Clock());
        }
       
       

    }



    public float GetTimeLeftInSec()
    {
        timeleftinsec = (timeleft * 60) + timeleftsec;
        return timeleftinsec;
    }

    IEnumerator Clock()
    {
        timerRunning = true;
        while (timeleftsec > 0)
        {
            
            yield return new WaitForSeconds(1);
            timeleftsec--;
            
            
        }
        if(timeleftsec == 0)
        {
            print("Working");
            
            timeleftsec = 0;
            timer.text = "" + timeleft + ":" + timeleftsec;
            yield return new WaitForSeconds(1);
            timerRunning = false;
            timeleft--;
            timeleftsec = 59;
        }
       

    }
   

   
}
