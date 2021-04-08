using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAreaCheckProvider
{
    public bool inArray { get; }
    public Collider2D[] Objects();
}
