using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private float startHealth;

    public float health { get; private set; }

    private void Start()
    {
        health = startHealth;
    }
    public void ModifyHealth(float value)
    {
        health = health + value;
        HealthCheck();
    }
    public bool HealthCheck()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            return false;
        }
        return true;
    }

}
