using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform Spawn1, Spawn2, Spawn3;//Positions for possible spawn points
    [SerializeField] private GameObject EndPoint1, EndPoint2, EndPoint3;
    private int RandomSpawn, RandomEnd;//Integer to select spawn and end point

    [SerializeField] private GameObject exitBlockade;

    void Start() {
        MovePlayer(RandomSpawn = Random.Range(1, 4));//Random integer between 1 and 3 chosen
        //The spawn point is chosen depending on what the integer variable is set to 
        print("Spawn Point " + RandomSpawn + " was chosen");
        
        //End point is chosen depending on what the interger variable is set to
        RandomEnd = Random.Range(1, 3);//Random integer between 1 and 3 chosen
        print("End Point " + RandomEnd + " was chosen");
        if (RandomEnd == 1)
        {
            EndPoint2.SetActive(false);
            //EndPoint3.SetActive(false);
            exitBlockade.transform.position = EndPoint2.transform.position;
            exitBlockade.transform.rotation = EndPoint2.transform.rotation;
        }
        else if(RandomEnd == 2)
        {
            //EndPoint3.SetActive(false);
            EndPoint1.SetActive(false);
            exitBlockade.transform.position = EndPoint1.transform.position;
            exitBlockade.transform.rotation = EndPoint1.transform.rotation;
        }
        //else if(RandomEnd == 3)
        //{
        //    EndPoint1.SetActive(false);
        //    EndPoint2.SetActive(false);
        //}
        else
        {
            EndPoint2.SetActive(false);
            EndPoint3.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MovePlayer(int randomNumber)
    {
        if (RandomSpawn == 1)
        {
            player.transform.position = (Spawn1.transform.position);

        }
        else if (RandomSpawn == 2)
        {
            player.transform.position = (Spawn2.transform.position);
        }
        else if (RandomSpawn == 3)
        {
            player.transform.position = (Spawn3.transform.position);
        }
        else
        {
            player.transform.position = (Spawn1.transform.position);
        }
    }
}
