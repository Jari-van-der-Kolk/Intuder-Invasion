using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnPointsInArea : MonoBehaviour
{
    private IAreaCheckProvider areaCheckProvider;
    GameObject[] foo;

    private void Start()
    {
         foo = GameObject.FindGameObjectsWithTag("Spawn Point");           
    }

    private void Update()
    {
        foreach (Collider o in areaCheckProvider.Objects())
        {
            for (int i = 0; i < areaCheckProvider.Objects().Length; i++)
            {

            }
            o.gameObject.SetActive(false);
        }
        if (true)
        {

        }
    }
}
