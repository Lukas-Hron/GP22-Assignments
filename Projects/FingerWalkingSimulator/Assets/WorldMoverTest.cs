using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoverTest : MonoBehaviour
{
    public Vector3 currentGroundedShoePosition;
    public Vector3 groundedShoePositionLastFrame;
    // Vector to store the difference between the mouse positions in the current and last frames
    public Vector3 shoePositionVector;
    public Vector3 targetPos;
    float cameraSize;
    float cameraAspect;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        cameraAspect = Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        Panning();
    }

    public void Panning()
    {

        // Calculate the difference between the current and last positions of the mouse
        shoePositionVector = (groundedShoePositionLastFrame - currentGroundedShoePosition) * -1;
    

        transform.position += shoePositionVector;
        // Update the last position of the mouse for the next frame
        groundedShoePositionLastFrame = currentGroundedShoePosition;

    }
}
