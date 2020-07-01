using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {

    Vector2 look;
    Vector2 smooth;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
   // public Camera cam; 

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouse = Vector2.Scale(mouse, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mouse.x, 1f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouse.y, 1f / smoothing);
        look += smooth;

        //moves camera vertically
        //transform.localRotation = Quaternion.AngleAxis(-look.y, Vector3.right);


        //moves char horizontally
        character.transform.localRotation = Quaternion.AngleAxis(look.x, character.transform.up);

        //limit vertical rotation
       // mouse.x = Mathf.Clamp(mouse.x, -90F, 90F);
       // cam.transform.localEulerAngles = new Vector3(Mathf.Clamp(cam.transform.localEulerAngles.x, -90F, 90F), 0, 0);
    }
}
