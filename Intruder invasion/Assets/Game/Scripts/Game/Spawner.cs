using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

public class Spawner : MonoBehaviour
{
    [SerializeField] private int amountLimit;
    public int amountOfEnemies;

    public spawn[] spawns;

    #region Singleton
    public static Spawner instance;
    private void Awake() => instance = this;
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
        if (s != null)
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
        foreach (spawn s in spawns)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(s.Location.position, .5f);
        }
    }


}

