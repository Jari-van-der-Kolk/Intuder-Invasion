using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNode
{
    public bool visited;
    public bool walkable;


    public struct Costs
    {
        public float h; // distance to starting spot
        public float g; // distance to ending spot 
        public float f { get { return h + g; } }
    }


    // continue making the grid node


    // reminder that it only has to go through the algoritm once
    
    // you can calculate the distance easaly in unity with : cost = (target - node position).mag

    // the node has to check its surroundings
                                                            

}
