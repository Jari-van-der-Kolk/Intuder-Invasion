using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private float startHealth;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float CurrentHealth;

    public float health { get; private set; }

    private void Start()
    {
        health = startHealth;
        CurrentHealth = health;
    }
    public void ModifyHealth(float value)
    {
        health = health + value;
        CurrentHealth = health; 
        HealthCheck();
    }
    public bool HealthCheck()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
            return false;
        }
        return true;
    }

    private void PlayerDeath()
    {
        //let the player show the Death screen menu
    }

}
