using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCustom : MonoBehaviour
{
    [SerializeField] private Vector2 xAxis = new();
    [SerializeField] private Vector2 yAxis = new();

    public Transform spawnTemp;
    public GameObject spawnItem;
    private void Start()
    {
        SpawnGrid();
    }
    public void SpawnGrid()
    {
        int totalXAxis = (int)Mathf.Floor((xAxis.y - xAxis.x) / 0.16f);
        int totalYAxis = (int)Mathf.Floor((yAxis.y - yAxis.x) / 0.16f);

        for (int i = 0; i < totalXAxis - 1; i++)
        {
            for (int j = 0; j < totalYAxis - 1; j++)
            {
                Vector2 pos = new(i * 0.16f, j * 0.16f);
                SpawnItem(pos);
            }
        }
    }
    public void SpawnItem(Vector2 pos)
    {
        Instantiate(spawnItem, pos, Quaternion.identity, spawnTemp);
    }
}
