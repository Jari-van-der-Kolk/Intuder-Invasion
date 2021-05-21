using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public float Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ModifyScore(float amount)
    {
        Score = Score + amount;
    }
    private void Update()
    {
        Debug.Log(Score);
    }

}
