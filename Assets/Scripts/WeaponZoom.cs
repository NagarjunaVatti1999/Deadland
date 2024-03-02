using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera FPSCamera;
    [SerializeField] float ZoomOutFOV = 60f;
    [SerializeField] float ZoomInFOV = 20f;
    bool zoomflag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomflag == false)
            {
                FPSCamera.fieldOfView = ZoomInFOV;
                zoomflag = true;
            }
            else
            {
                FPSCamera.fieldOfView = ZoomOutFOV;
                zoomflag = false;
            }
        }
    }
}
