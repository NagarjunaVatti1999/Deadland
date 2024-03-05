using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] AmmoType ammoType;
    [SerializeField] float TimeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoDisplay;
    [SerializeField] AudioSource gunFireSound;
    bool canShoot = true;
    void Start()
    {
        
    }
    private void OnEnable() {
        canShoot = true;    //this is to nulify the side effect of couroutine. if we sudddenly switch the 
                            //weapon in between coroutine then it might get stuck in false state
                            //so when a new weapon is enabled we set the canshoot to true
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmo(ammoType);
        ammoDisplay.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetAmmo(ammoType) > 0)
        {
            ammoSlot.DecreaseAmmo(ammoType);
            PlaySound();
            PlaMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(TimeBetweenShots);
        canShoot = true;
    }

    private void PlaySound()
    {
        gunFireSound.Play();
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
