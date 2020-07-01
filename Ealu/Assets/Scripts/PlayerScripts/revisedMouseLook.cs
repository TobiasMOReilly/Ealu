using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revisedMouseLook : MonoBehaviour {

    public float SpeedH = 10f;
    public float SpeedV = 10f;

    private float yaw = 0f;
    private float pitch = 0f;
    private float minPitch = -30f;
    private float maxPitch = 60f;

    GameObject character;

    // Use this for initialization
    void Start () {
        character = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        CameraRotate();
       // transform.localRotation = Quaternion.AngleAxis(SpeedH, Vector3.right);
       // character.transform.localRotation = Quaternion.AngleAxis(SpeedV, character.transform.up);
    }

    void CameraRotate()
    {
        //yaw += Input.GetAxis("Mouse X") * SpeedH;
        pitch -= Input.GetAxis("Mouse Y") * SpeedV;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

    }
}
