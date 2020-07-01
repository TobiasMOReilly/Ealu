using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private bool IsThrown;
    [SerializeField] private GameObject SliotarPos;
    RaycastHit hit;
    [SerializeField] private GameObject PressF;
    public GameObject cam;
    [SerializeField] private LayerMask SliotarLayer;
    [SerializeField] private Transform camtransform;
    private bool TimerBoolean = false;

    private Throw throwScript;
    void Start () {
        throwScript = GetComponent<Throw>();
        PressF.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(camtransform.position, camtransform.forward * 100, Color.red, 0.2f);
        IsThrown = player.GetComponent<Throw>().isThrown;
        //StartCoroutine(Timer());
        if (Physics.Raycast(camtransform.position, camtransform.forward, out hit, 1, SliotarLayer) /*&& TimerBoolean == true*/)
        {
            PressF.SetActive(true);
            //TimerBoolean = false;
        }
        else
        {
            PressF.SetActive(false);
        }




    }

    private void OnTriggerStay(Collider other)
    {
        if (Physics.Raycast(camtransform.position, camtransform.forward, out hit, 20, SliotarLayer) && other.gameObject.tag == "Pickup")
        {
            
            if (player.GetComponent<Throw>().Sliotar.tag == "Pickup" && IsThrown == true && Input.GetKeyDown(KeyCode.F))
            {
                
                throwScript.isThrown = false;
                throwScript.Sliotar.GetComponent<Rigidbody>().useGravity = false;
                throwScript.Sliotar.transform.position = SliotarPos.transform.position;
                throwScript.Sliotar.transform.rotation = cam.transform.rotation;
                throwScript.Sliotar.transform.SetParent(cam.transform);
                throwScript.Sliotar.SetActive(false);

            }
        }
        
       
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(1f);
    //    TimerBoolean = true;
    //    yield return null;
    //}
}
