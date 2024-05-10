using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingItem : MonoBehaviour
{
    public void Finding(Vector2 to)
    {
        APathFinding aStar = new();
        List<NodePath> paths = aStar.FindPaths(transform.position, to);
    }
}
