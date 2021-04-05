using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionProvider : MonoBehaviour, IPositionProvider
{
    [SerializeField] private Transform position;

    public Vector3 ProvidePosition() => position.position;
}
