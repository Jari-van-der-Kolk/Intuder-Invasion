using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootMotion : MonoBehaviour
{
    [SerializeField] private float animationDistance;
    public Transform[] Arms;
    [HideInInspector] public int index = 0;

    void Start()
    {
        index = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Arms[index].Translate(Vector3.right * animationDistance);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Arms[index].Translate(Vector3.left * animationDistance);
            index++;
            if (index >= Arms.Length)
            {
                index = 0;
            }
        }
    }
}
