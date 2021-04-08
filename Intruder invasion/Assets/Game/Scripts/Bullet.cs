using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] float damage;
    Rigidbody2D rBody;
    Transform player;
    SpawnHandler spawner;
    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        spawner = FindObjectOfType<SpawnHandler>();
    }
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.right  = player.transform.right;
    }
    void FixedUpdate()
    {
        rBody.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var hit = collision.GetComponent<HealthBehaviour>();
            hit.ModifyHealth(-damage);
            if(hit.HealthCheck() == false)
                spawner.amountOfEnemies--;
        }
        gameObject.SetActive(false);
    }

}
