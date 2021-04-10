using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnPointsInArea : MonoBehaviour
{
    private IAreaCheckProvider areaCheckProvider;
    public Collider2D[] current;
    public Transform[] spawns;
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
            if (spawns[i] == current[i].transform)
            {
                SpawnHandler.instance.spawns[i].OnOff = true;
            }
           /* else if (previous[i] == current[i] && current[i] == null)
            {
                SpawnHandler.instance.spawns[i].OnOff = false;
            }*/
        }



    }
}
