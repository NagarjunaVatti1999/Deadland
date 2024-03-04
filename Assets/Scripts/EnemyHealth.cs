using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float hitPoints = 100f;

    public bool isdead = false;
    public bool isDead()
    {
        return isdead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        isdead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
    