using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private SO_GameEvent GameOver;

    private static float health;
    private float MaxHealth = 100;
    public Slider sl;
    public bool dead;
    private bool loop = false;
	void Start () {
        health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        sl.value = health / MaxHealth;


       

        if(health <= 0)
        {
            dead = true;
            GameOver.Raise();
        }
		
	}


   

    public IEnumerator DecHealth()
    {
        loop = true;
        health-=10;
        yield return new WaitForSeconds(1);
        loop = false;
    }
}
