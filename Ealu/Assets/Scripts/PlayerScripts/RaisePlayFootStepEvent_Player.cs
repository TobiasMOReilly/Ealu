using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePlayFootStepEvent_Player : MonoBehaviour {

    [SerializeField] private SO_GameEvent playFootStepEvent;

    public void RaisePlayFootStepEvent()
    {
        playFootStepEvent.Raise();
        //print("RaisePlayFootStepEvent");
    }
}
