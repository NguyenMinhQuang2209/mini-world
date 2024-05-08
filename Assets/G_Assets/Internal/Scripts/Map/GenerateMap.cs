using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Transform foundation;
    [SerializeField] private Texture2D mapNoise;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject water;
    [SerializeField] private int offsetWidth = 100;
    [SerializeField] private int offsetHeight = 100;
    [SerializeField] private List<MapFoudation> foudations = new();
    [SerializeField] private Vector2 mapSize = new(0.16f, 0.16f);
    private void Start()
    {
        ReadMap();
    }
    public void ReadMap()
    {
        Color[] pixels = mapNoise.GetPixels();
        int width = mapNoise.width;
        int height = mapNoise.height;
        for (int i = offsetWidth; i < width; i++)
        {
            for (int j = offsetHeight; j < height; j++)
            {
                int index = i * width + j;
                float gray = pixels[index].r;
                Vector2 pos = new(i * mapSize.x, j * mapSize.y);
                GameObject obj = ground;
                if (gray > 0f)
                {
                    obj = water;
                }
                SpawnObject(obj, pos);
            }
        }
    }
    public void SpawnObject(GameObject obj, Vector2 pos)
    {
        Instantiate(obj, pos, Quaternion.identity, foundation.transform);
    }
}
[System.Serializable]
public class MapFoudation
{
    public Color color;
    public GameObject foundation;
}