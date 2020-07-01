using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour {

    public float speed;
    [SerializeField] private SO_Player playerData;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked; //prevents cursor from leaving game window

	}
	
	// Update is called once per frame
	void Update () {

        //show cursor
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;


        //run
        if (Input.GetKey("left shift"))
        {
            speed = playerData.SpeedMax;

        }

        //crouch & crawl
        else if (Input.GetKey("left ctrl"))
        {
            //*CROUCH*//

            speed = playerData.SpeedCrawl;
        }

        else
            speed = playerData.SpeedWalk;

        //jump


        //movement
        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * speed;
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);

    }
}
