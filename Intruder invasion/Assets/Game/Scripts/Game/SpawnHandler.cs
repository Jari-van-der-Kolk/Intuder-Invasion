using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

[SerializeField]
[System.Serializable]
public class spawn
{
    public string name;
    public Transform Location;
    [Header("Object pool indexer")]
    public int index;
    [Space]
    [Header("Spawn settings")]
    [Range(.1f, 3)]
    public float spawnSpeed;
    [HideInInspector] public float defaultSpawnSpeed;
    public float timer;
    public bool OnOff;
    [Header("Random spawn settings")]
    public bool randomSpawnTimer;
    public float Minimum, Maximum;

}

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private bool enableGizmos;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float2 radius;
    [SerializeField] private int amountLimit;
    public int amountOfEnemies;

    public spawn[] spawns;

    #region Singleton
    public static SpawnHandler instance;
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < spawns.Length; i++)
        {
            //Gives all the information to the spawn location objects to disable them if the player comes in the area
            spawns[i].name = i.ToString();
            spawns[i].Location.gameObject.AddComponent<DisableSpawnMethods>();
            spawns[i].Location.gameObject.GetComponent<DisableSpawnMethods>().index = spawns[i].name;
            spawns[i].Location.gameObject.AddComponent<AreaCheck>();
            var check = spawns[i].Location.gameObject.GetComponent<AreaCheck>();
            check.radius = new Vector2(radius.x, radius.y);
            check.mask = mask;
            spawns[i].Location.gameObject.AddComponent<DisableSpawn>();
        }
    }
    #endregion

    private void Start()
    {
        foreach (spawn s in spawns)
        {
            s.defaultSpawnSpeed = s.spawnSpeed;
            if (s.randomSpawnTimer == true)
                s.spawnSpeed = UnityEngine.Random.Range(s.Minimum / 100, s.Maximum / 100);
        }
    }

    private void Update()
    {
        foreach (spawn s in spawns)
        {
            if (s.OnOff == false)
            {
                s.timer += Time.deltaTime * s.spawnSpeed;

                if (s.timer >= 1f && amountOfEnemies <= amountLimit)
                {
                    GameObject enemy = ObjectPooler.Instance.GetPooledObject(s.index);
                    enemy.transform.position = s.Location.position;
                    enemy.SetActive(true);
                    amountOfEnemies++;
                    if (s.randomSpawnTimer == true)
                        s.spawnSpeed = UnityEngine.Random.Range(s.Minimum / 100, s.Maximum / 100);
                    else
                        s.spawnSpeed = s.defaultSpawnSpeed;
                    s.timer = 0;
                }
            }
        }

    }
    

    public void TurnOnOrOff(string name, bool OnOff)
    {
        spawn s = Array.Find(spawns, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.OnOff = OnOff;
    }
    public void TurnAllOnOrOff(bool OnOff)
    {
        for (int i = 0; i < spawns.Length; i++)
        {
            spawns[i].OnOff = OnOff;
        }
    }
    private void OnDrawGizmos()
    {
        if (enableGizmos == true)
        {
            foreach (spawn s in spawns)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(s.Location.position, .5f);
                Gizmos.DrawWireCube(s.Location.position, new Vector2(radius.x,radius.y));
            }

        }
    }
}

