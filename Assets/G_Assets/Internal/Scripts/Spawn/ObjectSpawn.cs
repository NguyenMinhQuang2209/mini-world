using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] private List<Sprite> itemTypes = new();
    [SerializeField] private bool useSpawnRandomItem = true;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (useSpawnRandomItem)
        {
            int pos = Random.Range(0, itemTypes.Count);
            spriteRenderer.sprite = itemTypes[pos];
        }
    }
}
