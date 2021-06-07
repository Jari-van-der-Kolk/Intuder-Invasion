using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class DNode
{

    public float fCost{ get { return gCost - hCost; } }
    public float gCost;
    public float hCost;
    
    

    public int gridX, gridY;
    
    public bool walkable;
    public Vector3 worldPosition;
	
    public DNode(bool _walkable, Vector3 _worldPos,int _gridX, int _gridY ) {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = gridY;
    }
    
    
}
