using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [SerializeField] float chaseRange;
    [SerializeField] float turnspeed = 5f;

    float distancetoTarget = Mathf.Infinity;
    bool isProvoked = false;
    NavMeshAgent Enemy;
    EnemyHealth health;
    CapsuleCollider Capcoll;
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        Capcoll = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.isDead())
        {
            Capcoll.enabled = false;
            enabled = false;
            Enemy.enabled = false;
            return;
        }
        distancetoTarget = Vector3.Distance(player.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distancetoTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FactTarget();
        if(distancetoTarget >= Enemy.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distancetoTarget <= Enemy.stoppingDistance)
        {
            AttackTarget();
        }
        Enemy.SetDestination(player.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        Enemy.SetDestination(player.position);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void FactTarget()
    {
        Vector3 direction =  (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*turnspeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
