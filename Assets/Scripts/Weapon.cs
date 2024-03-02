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
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float TimeBetweenShots = 0.5f;
    bool canShoot = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetAmmo() > 0)
        {
            ammoSlot.DecreaseAmmo();
            PlaMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(TimeBetweenShots);
        canShoot = true;
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
