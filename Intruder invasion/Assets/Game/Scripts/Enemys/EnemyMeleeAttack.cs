using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private HealthBehaviour playerHealth;

    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [FormerlySerializedAs("distance")] [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBehaviour>();
    }

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            var foo = Physics2D.CircleCast(transform.position, radius, Vector2.up, float.MaxValue, mask);
            if (foo == true)
            {
                playerHealth.ModifyHealth(-damage);
                
            }
        }
    }
    

    private void Update()
    {
        
        
        
    }

    private void OnDrawGizmos()
    {
        if (playerHealth != null)
        {
              Gizmos.color = Color.cyan;
              Gizmos.DrawWireSphere(transform.position, radius);
              Gizmos.DrawSphere(playerHealth.transform.position, 0.5f);
        }
      
    }
}
