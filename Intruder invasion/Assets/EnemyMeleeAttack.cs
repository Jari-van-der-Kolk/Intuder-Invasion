using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private HealthBehaviour playerHealth;

    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;

    private float timer;
    
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBehaviour>();
    }

    void Update()
    {
        timer += attackSpeed * Time.deltaTime;

        // checks if the player is in the correct area and if the timer is over 0, if so the player recieves damage
        if (Physics2D.CircleCast(transform.position, radius, Vector2.up, float.MaxValue, mask) && timer >= 0)
        {
            timer = 0;
            playerHealth.ModifyHealth(-damage);
        }
    }
}
