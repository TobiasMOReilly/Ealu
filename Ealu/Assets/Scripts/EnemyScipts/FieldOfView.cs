using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    //--------Game Object Must Have a Sphere Collider--------//

    [SerializeField] private Transform EyePoint;
    [SerializeField] private Transform target;
    [SerializeField] private float MaxViewAngle;

    private bool playerInRange;
    private float maxViewLength;
    private Vector3 lastKnownPosition;

    // Use this for initialization
    void Start () {

        playerInRange = false;
        maxViewLength = GetComponentInChildren<SphereCollider>().radius;
    }
	
    //CHECK IF PLAYER IS WITHIN FIELD OF VIEW
    public bool PlayerInView()
    {
        if(!playerInRange)
        {
            //print("Leaving FOV");
            return false;
        }

        bool lineOfSight = false;

        Vector3 playerDirection = (target.position - transform.position) + (transform.position - EyePoint.position); // direction from enemy eye level to player head level

        float angle = Vector3.Angle(transform.forward, playerDirection);

        float maxRadius = GetComponentInChildren<SphereCollider>().radius;

        if (playerInRange && angle <= MaxViewAngle)
        {
            //Check if enemy has line of sight
            Ray eyeRay = new Ray(EyePoint.position, playerDirection);
            RaycastHit hitInfo;

            if (Physics.Raycast(eyeRay, out hitInfo, maxRadius, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
            {
                if (hitInfo.collider.gameObject.tag.Equals("Player"))
                {
                    print("FOV: SEE PLAYER");
                    lineOfSight = true;
                    lastKnownPosition = target.transform.position;
                }
                else
                    lineOfSight = false;
            }
        }

        return lineOfSight;
    }
    //ONTRIGGER ENTER EVENT
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerInRange = true;
        }
    }
    //ONTRIGGER EXIT EVENT
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            playerInRange = false;
        }
    }

    //DRAW THE FIELD OF VIEW
    public void DrawFieldOfView()
    {
        //Draw center viewline
        Debug.DrawRay(transform.position, transform.forward * maxViewLength, Color.green);
        //Draw maxAngle viewlines
        Vector3 directionRight = Quaternion.AngleAxis(MaxViewAngle, transform.up) * transform.forward;
        Vector3 directionLeft = Quaternion.AngleAxis(-MaxViewAngle, transform.up) * transform.forward;
        Debug.DrawRay(transform.position, directionRight * maxViewLength, Color.green);
        Debug.DrawRay(transform.position, directionLeft * maxViewLength, Color.green);

        //Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
        Debug.DrawRay(EyePoint.position, (target.position - transform.position) + (transform.position - EyePoint.position), Color.cyan);

    }


    //GETTERS / SETTERS
    public void SetFOVTarget(Transform target)
    {
        this.target = target;
    }
    public Transform GetFOVTarget()
    {
        return target;
    }
    public Vector3 GetLastKnownPosition()
    {
        return lastKnownPosition;
    }
}
