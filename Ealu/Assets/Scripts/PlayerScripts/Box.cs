using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField] private Transform box;
    private bool InBox;
    RaycastHit Hit;
    [SerializeField] private GameObject Player, TPC, FPC;
    [SerializeField] private GameObject PressF;
    [SerializeField] private LayerMask BoxLayer;
    [SerializeField] private Transform camtransform;
    [SerializeField] private Transform PlayerPosition, PlayerprevPos;
    [SerializeField] private GameObject charMesh;
    private bool canHide;
	void Start () {
        InBox = false;
        PressF.SetActive(false);
        TPC.SetActive(false);
        canHide = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F) && InBox == true)
        {
            
            ExitBox();
        }
        else if (Physics.Raycast(camtransform.position, camtransform.forward, out Hit, 1, BoxLayer) && InBox == false)
        {
            box = Hit.collider.gameObject.transform;

            if(canHide)
            {
                EnterBox();
            }
            
        }
        else
        {
            PressF.SetActive(false);
        }

        



    }

    void EnterBox()
    {
        PressF.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F) && InBox == false)
        {
            print("Enters Box");
            PlayerprevPos.transform.position = gameObject.transform.position;//Save Position
            PlayerprevPos.transform.rotation = gameObject.transform.rotation;
            Player.GetComponent<Collider>().enabled = false;
            charMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
            TPC.SetActive(true);
            //FPC.SetActive(false);
            Player.GetComponent<MeshRenderer>().enabled = false;
            Player.GetComponent<Throw>().enabled = false;
            gameObject.transform.position = box.transform.position;//go into box
            gameObject.transform.rotation = box.transform.rotation;//rotate player to look out of box
            Player.GetComponent<CharacterController>().enabled = false;

            InBox = true;
        }
    }

    void ExitBox()
    {
        print("Exit Box");
        gameObject.transform.position = PlayerprevPos.transform.position;
        gameObject.transform.rotation = PlayerprevPos.transform.rotation;
        Player.GetComponent<Collider>().enabled = true;
        Player.GetComponent<CharacterController>().enabled = true;
        charMesh.GetComponent<SkinnedMeshRenderer>().enabled = true;
        Player.GetComponent<Throw>().enabled = true;
        //FPC.SetActive(true);
        TPC.SetActive(false);
        
        InBox = false;
    }
    public void CanHide()
    {
        canHide = !canHide;
    }

}
