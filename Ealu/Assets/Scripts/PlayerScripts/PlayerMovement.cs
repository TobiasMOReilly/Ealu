using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator an;
    public float speed;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] private SO_Player playerData;
    private CharacterController controller;

    private void Start()
    {
        an = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        

        //run
        if (Input.GetKey("left shift"))
        {
            speed = playerData.SpeedMax;
        }

        //crawl
        else if (Input.GetKey("left ctrl"))
        {
            speed = playerData.SpeedCrawl;
        }

        else
            speed = playerData.SpeedWalk;


        //movement
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //movement animation

        //crawl
        if (speed == playerData.SpeedCrawl)
        {
            an.SetInteger("AnimState", 3);
        }

        //walk
        else if (speed == playerData.SpeedWalk)
        {
            an.SetInteger("AnimState", 2);
        }

        //run
        else if (speed == playerData.SpeedMax)
        {
            an.SetInteger("AnimState", 1);
        }

        if (controller.velocity.magnitude == 0)
        {
            an.SetInteger("AnimState", 0);
        }

        //throw
        if (Input.GetMouseButton(0))
        {
            an.SetInteger("AnimState", 5);
        }

        //jump
        if (Input.GetButton("Jump"))
        {
            an.SetInteger("AnimState", 4);
        }


        //if speed has changed, update
        if (speed != playerData.CurrentSpeed)
        {
            playerData.SetCurrentSpeed(speed);
        }
    }
}
