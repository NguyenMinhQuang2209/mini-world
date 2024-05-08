using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public static GenerateMap instance;

    [SerializeField] private Transform foundation;
    [SerializeField] private Texture2D mapNoise;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject water;
    [SerializeField] private float offsetXPos = 0f;
    [SerializeField] private float offsetYPos = 0f;
    [SerializeField] private Vector2Int fromToXAxis = new();
    [SerializeField] private Vector2Int fromToYAxis = new();
    [SerializeField] private List<MapFoudation> foudations = new();
    [SerializeField] private Vector2 mapSize = new(0.16f, 0.16f);

    Vector2 boundXAxis = new();
    Vector2 boundYAxis = new();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        ReadMap();
    }
    public void ReadMap()
    {
        Color[] pixels = mapNoise.GetPixels();
        int width = mapNoise.width;
        int height = mapNoise.height;

        int fromI = fromToXAxis.x;
        int fromJ = fromToYAxis.x;

        int toI = fromToXAxis.y < 0 ? width : fromToXAxis.y;
        int toJ = fromToYAxis.y < 0 ? height : fromToYAxis.y;

        boundXAxis = new(offsetXPos, (toI - 1) * mapSize.x + offsetXPos);
        boundYAxis = new(offsetYPos, (toJ - 1) * mapSize.y + offsetYPos);

        for (int i = fromI; i < toI; i++)
        {
            for (int j = fromJ; j < toJ; j++)
            {
                int index = i * width + j;
                float gray = pixels[index].r;
                Vector2 pos = new(i * mapSize.x + offsetXPos, j * mapSize.y + offsetYPos);
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
    public Vector2 GetBoundXAxis()
    {
        return boundXAxis;
    }
    public Vector2 GetBoundYAxis()
    {
        return boundYAxis;
    }
}
[System.Serializable]
public class MapFoudation
{
    public Color color;
    public GameObject foundation;
}