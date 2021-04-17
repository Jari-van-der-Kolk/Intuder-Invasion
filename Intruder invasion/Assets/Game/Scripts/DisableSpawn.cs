using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawn : MonoBehaviour
{
    private IAreaCheckProvider areaCheckProvider;
    private IDisable disable;
    private bool InArea;

    private void Awake()
    {
        areaCheckProvider = GetComponent<IAreaCheckProvider>();
        disable = GetComponent<IDisable>();
    }

    private void Update()
    {
        var Previous = InArea;
        InArea = areaCheckProvider.CreateCheck();
        if (InArea)
        {
            disable.Disable(); 
        }
        else if (Previous == true && InArea == false)
        {
            disable.Enable();
        }
    }
}


