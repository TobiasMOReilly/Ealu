using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private SO_GameEvent playerSpottedEvent;
    [SerializeField] private SO_GameEvent playerLostEvent;
    [SerializeField] private SO_GameEvent returningPatrolEvent;

    private FieldOfView fOV;
    private Animator anim;
    private Scan scan;
    private Distractable distract;
    private Hearing hearing;
    private Vector3 lastKnown;

    private string playerSpottedString;
    private string playerLostString;
    private string scanCompleteString;
    private string enemyDistractedString;
    // Use this for initialization
    void Start () {
        fOV = GetComponent<FieldOfView>();
        anim = GetComponent<Animator>();
        scan = GetComponent<Scan>();
        distract = GetComponent<Distractable>();
        hearing = GetComponent<Hearing>();
        scanCompleteString = "ScanComplete";
        playerLostString = "PlayerLost";
        playerSpottedString = "PlayerSpotted";
        enemyDistractedString = "Distracted";
    }
	
	// Update is called once per frame
	void Update () {

        //Draw Field of View
        fOV.DrawFieldOfView();
        //SET CHASE
        //Player Spotted, set chase behaviour
        if (fOV.PlayerInView())
        {
            //print("Spotted");
            lastKnown = fOV.GetLastKnownPosition();
            anim.SetBool(playerSpottedString, true);
        }
        //If Player is hear
        if(hearing.IsHeard())
        {
            lastKnown = hearing.GetLastKnowPosition().position;
            anim.SetBool(playerSpottedString, true);
            //print(lastKnown);
        }
        //SET SCAN
        //If at last known position & player not in view, set scan behavior
        if(transform.position.x == lastKnown.x && transform.position.z == lastKnown.z)
        {
            //print("Player Lost, SCANNING");
            anim.SetBool(playerLostString, true);
        }
        //SET PATROL
        if(scan.IsComplete())
        {
            anim.SetBool(scanCompleteString, true);
        }
        //If the player is not in view and the enemy has been distracted
        if(!fOV.PlayerInView() && distract.IsDistracted() && distract.CanDistract())
        {
            anim.SetBool(enemyDistractedString, true);
        }
	}


    //RaiseEvents
    public void RaiseSpottedEvent()
    {
        playerSpottedEvent.Raise();
    }
    public void RaiseLostEvent()
    {
        playerLostEvent.Raise();
    }
    public void RaisePatrolEvent()
    {
        returningPatrolEvent.Raise();
    }
    //Getters
    public Vector3 GetLastKnownPosition()
    {
        return lastKnown;
    }
}
