using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 currentMouseScreenPosition;
    public Vector3 mouseScreenPositionLastFrame;
    public Vector3 mouseVector;
    public float cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        cameraSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize = Mathf.Clamp(cameraSize+(Input.mouseScrollDelta.y*-1),1,20); //Camera size change
        Camera.main.orthographicSize = cameraSize;

        if (Input.GetMouseButtonDown(0) || Input.mouseScrollDelta.y != 0f)
        {
            mouseScreenPositionLastFrame = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentMouseScreenPosition = Input.mousePosition;

            mouseVector = mouseScreenPositionLastFrame - currentMouseScreenPosition;
            mouseVector.x /= Screen.width;
            mouseVector.x *= Camera.main.orthographicSize * 2 * Camera.main.aspect;

            mouseVector.y /= Screen.height;
            mouseVector.y *= Camera.main.orthographicSize * 2;
            transform.position += mouseVector;

            mouseScreenPositionLastFrame = Input.mousePosition;
        }
    }
}
