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

    float distancetoTarget = Mathf.Infinity;
    bool isProvoked = false;
    NavMeshAgent Enemy;
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("attacking");
    }

    private void ChaseTarget()
    {
        Enemy.SetDestination(player.position);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
