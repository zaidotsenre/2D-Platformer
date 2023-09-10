using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public int index;

    public bool visited;
    public bool entry;
    public bool exit;

    // walls
    public bool top;
    public bool right;
    public bool bottom;
    public bool left;

    // edge
    public bool topEdge;
    public bool rightEdge;
    public bool bottomEdge;
    public bool leftEdge;
}