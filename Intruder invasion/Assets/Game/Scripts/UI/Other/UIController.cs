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
    }

    private bool isMenuActive;

    public void EnableMenu()
    {
        isMenuActive = !isMenuActive;
        panel.SetActive(isMenuActive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            EnableMenu();
        }
    }
}
