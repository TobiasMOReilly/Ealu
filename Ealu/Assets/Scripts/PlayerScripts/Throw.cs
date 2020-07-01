using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

	public GameObject Sliotar;
    [SerializeField] private GameObject Player;
    public bool isThrown;
    private float ThrowForce = 600f;

    [SerializeField] private SO_GameEvent BallThrownEvent;

	void Start () {
        isThrown = false;
        ThrowForce = 600f;
        Sliotar.transform.SetParent(Player.transform);
        Sliotar.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && isThrown == false)//Get Mouse input

        {
            print("Throwing");
            ThrowSliotar();
            BallThrownEvent.Raise();
        }
        //if(Input.GetKey(KeyCode.O)) //test score
        //{
        //    gameObject.GetComponent<Score>().CalculateTimeScore();
        //    print("key pressed");
        //}
		
	}

    private void ThrowSliotar()
    {
        isThrown = true;
        Sliotar.SetActive(true);
        Sliotar.transform.SetParent(null);
        Sliotar.transform.rotation = GetComponent<Pickup>().cam.transform.rotation;
        Sliotar.GetComponent<Rigidbody>().useGravity = true;
        Sliotar.GetComponent<Rigidbody>().AddForce(Sliotar.transform.forward * ThrowForce);
        
        StartCoroutine(ThrowCount());
    }

    IEnumerator ThrowCount()
    {
        yield return new WaitForSeconds(1);
        isThrown = true;
        yield return null;
    }
}
