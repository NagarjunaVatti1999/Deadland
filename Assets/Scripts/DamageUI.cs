using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;
    void Start()
    {
        impactCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayDamageUI()
    {
        StartCoroutine(BloodSplatter());
    }

    IEnumerator BloodSplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
