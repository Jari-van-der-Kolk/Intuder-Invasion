using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToPlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent navMesh;

    void Awake() => navMesh = GetComponent<NavMeshAgent>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        navMesh.SetDestination(player.position);
    }

}
