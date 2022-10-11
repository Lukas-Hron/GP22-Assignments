using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector2 screenMiddle;
    private Vector2 screenMax;
    private Vector2 playerScreenPos;

    private float distanceToPlayer;
    private float cameraEaseVal;

    public float maxDistanceFromCamera;
    public float speed = 2;
    public float cameraPanEase;

    private void Start()
    {
        screenMax = new Vector2(Screen.width, Screen.height);
        screenMiddle = screenMax / 2;
    }
    void FixedUpdate()
    {
        distanceToPlayer = Vector2.Distance(playerScreenPos, screenMiddle);
        playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);

        if ( distanceToPlayer > maxDistanceFromCamera)
        {
            cameraEaseVal = (distanceToPlayer - maxDistanceFromCamera) * cameraPanEase;
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position - new Vector3(0, 0, 10), speed * Time.deltaTime * cameraEaseVal);
        }
    }

}
