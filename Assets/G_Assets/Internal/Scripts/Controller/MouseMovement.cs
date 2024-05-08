using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Camera mCamera;
    [SerializeField] private float zoomMin = 1f;
    [SerializeField] private float zoomMax = 1f;
    [SerializeField] private float scrollSensitivity = 1f;
    [SerializeField] private float defaultMouseSize = 2f;
    Vector3 mDragPos;
    private void Start()
    {
        mCamera.orthographicSize = defaultMouseSize;
    }

    private void Update()
    {
        CameraChangePosition();
    }
    public void CameraChangePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mDragPos = mCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 diff = mDragPos - mCamera.ScreenToWorldPoint(Input.mousePosition);
            diff.z = 0.0f;
            diff.x *= mouseSensitivity;
            diff.y *= mouseSensitivity;
            mCamera.transform.position += diff;
        }

        float scrollAmount = Input.GetAxis("Mouse ScrollWheel");
        if (scrollAmount != 0f)
        {
            defaultMouseSize = ClampSize(defaultMouseSize - scrollAmount * scrollSensitivity, zoomMin, zoomMax);
            mCamera.orthographicSize = defaultMouseSize;
        }
    }
    public float ClampSize(float size, float min, float max)
    {
        return Mathf.Clamp(size, min, max);
    }
}
