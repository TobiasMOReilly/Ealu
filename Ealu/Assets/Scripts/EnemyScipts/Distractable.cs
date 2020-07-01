using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractable : MonoBehaviour {

    private bool isDistracted;
    private bool canDistract;


    private Vector3 sliotarPosition;

    private GameObject sliotar;
    // Use this for initialization
    void Start () {
        isDistracted = false;
        canDistract = false;
    }


    void Update()
    {
        if(canDistract)
        {
            //check if the sliotar is on the ground
            if (sliotar.transform.position.y <= 0.5)
            {
                print("Setting Pos");
                isDistracted = true;
                canDistract = false;
                sliotarPosition = sliotar.transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Detected Something");
        if (other.gameObject.layer == 9)  //if the collider object is the Sliotar
        {
            //print("Detected Ball");
            canDistract = true;
            sliotar = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)//Reset the flags
        {
            canDistract = true;
            isDistracted = false;
        }
    }
 
    //getters
    public bool IsDistracted()
    {
        return isDistracted;
    }
    public bool CanDistract()
    {
        return canDistract;
    }
    public Vector3 SliotorPosition()
    {
        return sliotarPosition;
    }
}
