using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnPointsInArea : MonoBehaviour
{
    private IAreaCheckProvider areaCheckProvider;
    public Collider2D[] current;
    private void Awake()
    {
        areaCheckProvider = GetComponent<IAreaCheckProvider>();
    }

    private void Update()
    {
        current = areaCheckProvider.Objects();
        var previous = current;
        for (int i = 0; i < current.Length; i++)
        {
            int foo = current[i].GetComponent<DisableObject>().index;
            SpawnHandler.instance.spawns[foo].OnOff = true;
        }



    }
}
