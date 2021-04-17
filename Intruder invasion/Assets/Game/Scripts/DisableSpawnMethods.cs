using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnMethods : MonoBehaviour, IDisable
{
    public string index;
    public void Disable() => SpawnHandler.instance.TurnOnOrOff(index, true);
    public void Enable() => SpawnHandler.instance.TurnOnOrOff(index, false);
}
