using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour {

    private bool isLerping;
    private float lerpTimeStart;
    private float lerpTime = 0.2f;

    private Quaternion startRotation;
    private Quaternion endRotation;

    private bool rotateComplete;
    private int rotateCount = 0;
    private bool scanComplete;

    private bool isScannning = false;

    public void ScanArea()
    {
        //if(!isLerping)
        //{
        //    StartRotation();
        //}

        //Rotate();

        //if(rotateCount == 2)
        //{
        //    scanComplete = true;
        //}
        //print("SCAN COUNT " + rotateCount);
        if(!isScannning)
        {
            StartCoroutine(Scanning());
        }
    }

    IEnumerator Scanning()
    {
        isScannning = true;
        yield return new WaitForSeconds(5);
        scanComplete = true;
    }

    private void StartRotation()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.LookRotation(-transform.forward /2, Vector3.up);
        
        lerpTimeStart = Time.time;
        isLerping = true;

    }

    private void Rotate()
    {
        //Calculate precentage complete
        float preComp = (Time.time - lerpTimeStart) * lerpTime;

        transform.rotation = Quaternion.Lerp(startRotation, endRotation, preComp);

        if (transform.rotation == endRotation)
        {
            isLerping = false;
            rotateCount++;
        }
    }

    public void resetScan()
    {
        isLerping = false;
        scanComplete = false;
        isScannning = false;
        rotateCount = 0;
    }

    public bool IsComplete()
    {
        return scanComplete;
    }

}
