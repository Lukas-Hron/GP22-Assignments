using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotationBasedOnAngle : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> foodSprites;
    public bool isTurnRight;
    Transform player;
    float angleUnit;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        angleUnit = foodSprites.Count / 360f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerDirection = (player.position - transform.position).normalized;
        playerDirection.y = 0;
        float viewAngle = Vector3.SignedAngle(Vector3.forward, playerDirection, Vector3.up) + 180;

        transform.forward = new Vector3(playerDirection.x, 0, playerDirection.z);

        spriteRenderer.sprite = foodSprites[(int)Mathf.Round(Mathf.Clamp((viewAngle * angleUnit), 0, foodSprites.Count-1))];
    }
}
