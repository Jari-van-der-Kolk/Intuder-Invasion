using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour, IAreaCheckProvider
{
    public LayerMask mask;
    public Vector2 radius;

    public bool CreateCheck()
    {
        return Physics2D.OverlapBox(transform.position, radius, 0, mask);
    }
}
