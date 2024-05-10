using UnityEngine;

public class NodePath
{
    public float gCost = 0;
    public float hCost = 0;
    public float fCost = 0;
    public NodePath connection = null;
    public Vector2 pos;
    public void CaculateFCost()
    {
        fCost = hCost + gCost;
    }
}
