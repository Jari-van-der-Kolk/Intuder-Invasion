using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public float health { get; private set; }

    public void ModifyHealth(float value)
    {
        health = health + value;
        HealthCheck();
    }
    public void HealthCheck()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
