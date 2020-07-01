using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public SO_GameEvent Event;
    public UnityEvent Response;
    public List<SO_GameEvent> events;

    private void OnEnable()
    {
        if (Event != null)
        {
            Event.RegisterListener(this);
        }
        foreach(SO_GameEvent e in events)
        {
            e.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        if (Event != null)
        {
            Event.UnregisterListener(this);
        }
        foreach (SO_GameEvent e in events)
        {
            e.UnregisterListener(this);
        }
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
