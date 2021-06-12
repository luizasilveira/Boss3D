using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensivity;

    public float minXlook;
    public float maxXLook;
    public Transform camAnchor;
    public bool invertXRotation;
    private float curXRot;

    void Start(){
      Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate(){
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //rotate Horizontally
        transform.eulerAngles += Vector3.up * x * lookSensivity;
        if(invertXRotation){
            curXRot += y * lookSensivity;
        }else{
            curXRot -= y * lookSensivity;
        }

        //rotate Horizontally

        curXRot = Mathf.Clamp(curXRot,minXlook,maxXLook);

        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;
        camAnchor.eulerAngles = clampedAngle;

    }

}
