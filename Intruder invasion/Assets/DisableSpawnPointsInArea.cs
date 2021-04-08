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

        for (int i = 0; i < SpawnHandler.instance.spawns.Length; i++)
        {
            if (current == null) return;
            if (SpawnHandler.instance.spawns[i].Location == current[i].transform)
            {
                SpawnHandler.instance.spawns[i].OnOff = true;
                Debug.Log(SpawnHandler.instance.spawns[i].name);
            }
            else if (SpawnHandler.instance.spawns[i].Location == previous[i].transform && SpawnHandler.instance.spawns[i].Location != current[i].transform)
            {
                Debug.Log("fuck you");
            }
        }



    }
}
