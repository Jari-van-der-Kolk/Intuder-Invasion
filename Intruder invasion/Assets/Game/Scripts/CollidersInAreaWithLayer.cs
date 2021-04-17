using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersInAreaWithLayer : MonoBehaviour, IAreaColliderProvider
{
    [SerializeField] private Vector3 radius;
    [SerializeField] private LayerMask mask;

    public bool inArray { get; }

    public Collider2D[] Objects()
    {
        return Physics2D.OverlapBoxAll(transform.position, radius, 0, mask); 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, radius);
    }

}
