using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    
    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private bool isMenuActive;

    public void EnableMenu()
    {
        isMenuActive = !isMenuActive;
        panel.SetActive(isMenuActive);
        if (panel.activeSelf == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EnableMenu();
        }
    }

    public void Quit() => Application.Quit();
}
