using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth player;
    [SerializeField] float damage = 40f;
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackPlayer()
    {
        if(player == null) return;
        player.PlayerDamage(damage);
        Debug.Log("Attack player : "+damage);
    }
}
