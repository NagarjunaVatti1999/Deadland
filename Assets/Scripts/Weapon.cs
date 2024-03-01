using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform FPCamera;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject BulletImpact;
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
        PlaMuzzleFlash();
        ProcessRaycast();
    }

    private void PlaMuzzleFlash()
    {
        muzzleflash.Play();
    }
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit " + hit.transform.gameObject.name);
            ImpactEffect(hit);
            EnemyHealth EHealth = hit.transform.GetComponent<EnemyHealth>();
            if (EHealth == null) return;
            EHealth.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void ImpactEffect(RaycastHit hit)
    {
        GameObject Impact = Instantiate(BulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(Impact, 0.1f);
    }
}
