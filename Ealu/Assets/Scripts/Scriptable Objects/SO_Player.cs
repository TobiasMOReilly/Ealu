using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Object/Player")]

public class SO_Player : ScriptableObject
{
    //Player Max Variables
    [SerializeField] private float speedMax;
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedCrawl;
    [SerializeField] private float speedCrouch;
    [SerializeField] private float speedTurn;

    private float currentSpeed;
    [SerializeField] private SO_GameEvent playerSpeedChangeEvent;
    //On disable / enable
    private void OnDisable()
    { }
    private void OnEnable()
    { currentSpeed = 0; }

    //Getters
    public float SpeedMax
    {
        get {return speedMax;}        
    }
    public float SpeedWalk
    {
        get {return speedWalk; }
    }
    public float SpeedCrawl
    {
        get { return speedCrawl; }
    }
    public float SpeedCrouch
    {
        get { return speedCrouch; }
    }
    public float SpeedTurn
    {
        get { return speedTurn; }
    }
    public float CurrentSpeed
    {
        get { return currentSpeed; }
    }
    public void SetCurrentSpeed(float speed)
    {
        playerSpeedChangeEvent.Raise();
        //Debug.Log("IRan");
        currentSpeed = speed;
    }
}
