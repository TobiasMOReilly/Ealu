using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player", menuName = "Scriptable Object/Enemy")]
public class SO_Enemy : ScriptableObject
{
    //Enemy vars
    [SerializeField] private float speedMax;

    //Getters
    public float SpeedMax
    {
        get { return speedMax; }
    }
}
