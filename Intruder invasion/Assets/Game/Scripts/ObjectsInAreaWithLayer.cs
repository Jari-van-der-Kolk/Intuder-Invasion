using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInAreaWithLayer : MonoBehaviour, IAreaCheckProvider
{
    [SerializeField] private Vector3 radius;
    [SerializeField] private LayerMask mask;

    public bool inArray { get; }

    public Collider[] Objects()
    {
        return Physics.OverlapBox(transform.position, radius,Quaternion.identity, mask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, radius);
    }

}
