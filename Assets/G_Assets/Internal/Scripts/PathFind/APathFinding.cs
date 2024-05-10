using System.Collections.Generic;
using UnityEngine;

public class APathFinding
{
    public static int STRAIGHT = 10;
    public static int DIALOG = 14;
    List<NodePath> processed = new();
    List<NodePath> searched = new();
    public List<NodePath> FindPaths(Vector2 from, Vector2 to)
    {
        NodePath startNode = new()
        {
            gCost = int.MaxValue,
            pos = from,
            connection = null,
        };
        startNode.hCost = GetDistance(startNode.pos, to);
        startNode.CaculateFCost();
        processed = new() { startNode };
        while (processed.Count > 0)
        {
            NodePath currentNode = GetLowestFCost(processed);
            if (currentNode.pos == to)
            {
                return CaculateNodePath(currentNode);
            }
            processed.Remove(currentNode);
            searched.Add(currentNode);

            foreach (NodePath neighbour in GetNeighbourList(currentNode.pos))
            {
                float tentactive = currentNode.gCost + GetDistance(currentNode.pos, neighbour.pos);
                if (tentactive < neighbour.gCost)
                {
                    neighbour.connection = currentNode;
                    neighbour.gCost = tentactive;
                    neighbour.hCost = GetDistance(neighbour.pos, to);
                    neighbour.CaculateFCost();
                    if (!processed.Contains(neighbour))
                    {
                        processed.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }
    public List<NodePath> CaculateNodePath(NodePath node)
    {
        List<NodePath> paths = new();
        NodePath currentNode = node;
        paths.Add(currentNode);
        while (currentNode.connection != null)
        {
            paths.Add(currentNode.connection);
            currentNode = currentNode.connection;
        }
        Debug.Log(paths.Count);
        return paths;
    }
    public List<NodePath> GetNeighbourList(Vector2 from)
    {
        List<NodePath> neighbours = new();

        Vector2 left = new(from.x - 0.16f, from.y);
        Vector2 topLeft = new(from.x - 0.16f, from.y + 0.16f);
        Vector2 bottomLeft = new(from.x - 0.16f, from.y - 0.16f);

        Vector2 right = new(from.x + 0.16f, from.y);
        Vector2 topRight = new(from.x + 0.16f, from.y + 0.16f);
        Vector2 bottomRight = new(from.x + 0.16f, from.y - 0.16f);

        Vector2 top = new(from.x, from.y + 0.16f);
        Vector2 bottom = new(from.x, from.y - 0.16f);

        CraeteNewNode(left, neighbours);
        CraeteNewNode(topLeft, neighbours);
        CraeteNewNode(bottomLeft, neighbours);

        CraeteNewNode(right, neighbours);
        CraeteNewNode(topRight, neighbours);
        CraeteNewNode(bottomRight, neighbours);

        CraeteNewNode(top, neighbours);
        CraeteNewNode(bottom, neighbours);

        return neighbours;
    }
    public void CraeteNewNode(Vector2 pos, List<NodePath> list)
    {
        NodePath newNode = new()
        {
            pos = pos,
            gCost = int.MaxValue
        };
        list.Add(newNode);
    }
    public NodePath GetLowestFCost(List<NodePath> list)
    {
        NodePath lowestNode = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (lowestNode.fCost > list[i].fCost)
            {
                lowestNode = list[i];
            }
        }
        return lowestNode;
    }
    public float GetDistance(Vector2 from, Vector2 to)
    {

        int fromXIndex = (int)(from.x / 0.16f);
        int fromYIndex = (int)(from.y / 0.16f);

        int toXIndex = (int)(to.x / 0.16f);
        int toYIndex = (int)(to.y / 0.16f);

        int x = Mathf.Abs(fromXIndex - toXIndex);
        int y = Mathf.Abs(fromYIndex - toYIndex);
        int remain = Mathf.Abs(x - y);

        return DIALOG * Mathf.Min(x, y) + STRAIGHT * remain;
    }
}
