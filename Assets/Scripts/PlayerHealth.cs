using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float PHealth = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamage(float damage)
    {
        if(PHealth <= 0)GetComponent<DeathHandler>().HandleDeath();
        PHealth -= damage;
    }
}
