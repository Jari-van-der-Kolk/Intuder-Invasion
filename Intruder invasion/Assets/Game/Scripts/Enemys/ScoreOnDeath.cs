using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    [SerializeField] private float value = 10f;
    private float copyValue;
    private void Awake()
    {
        copyValue = value;
        value = 0;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.ModifyScore(value);
        value = copyValue;
    }
}
