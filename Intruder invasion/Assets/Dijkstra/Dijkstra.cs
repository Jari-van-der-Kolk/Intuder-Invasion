using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;


   
    
    //private void Pick
    
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPoint.position, 1f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(endPoint.position, 1f);

        }
    }
}
