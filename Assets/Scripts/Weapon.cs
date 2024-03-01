using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Shoot triggered");
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit "+hit.transform.gameObject.name);
        }
        else
        {
            return;
        }
    }
}
