using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    [Header("Mouse touch")]
    [SerializeField] private GameObject touchObj;

    [SerializeField] private PathFindingItem item;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = (int)(touchPos.x / 0.16f);
            int y = (int)(touchPos.y / 0.16f);

            float prevX = x * 0.16f;
            float nextX = (x + 1) * 0.16f;

            float prevY = y * 0.16f;
            float nextY = (y + 1) * 0.16f;

            float nextXPos = Mathf.Abs(touchPos.x - prevX) > Mathf.Abs(touchPos.x - nextX) ? nextX : prevX;
            float nextYPos = Mathf.Abs(touchPos.y - prevY) > Mathf.Abs(touchPos.y - nextY) ? nextY : prevY;

            Vector2 newPos = new(nextXPos, nextYPos);
            touchObj.transform.position = newPos;
            item.Finding(newPos);
        }
    }
}
