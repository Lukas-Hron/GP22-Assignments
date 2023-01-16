using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheGroundedChecker : MonoBehaviour
{
    public WorldMoverTest DEBUGWALKTHING;
    GameObject leftShoe, rightShoe;
    bool bothShoesActive,rightShoeGrounded,rightShoeAhead,changeDetector, changeDetector2;
    public float highestPosition;
    public Color DEBUGgroundedColor;
    [SerializeField] float shoeGoundedDistance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        leftShoe = GetComponent<ShoeController>().leftShoe;
        rightShoe = GetComponent<ShoeController>().rightShoe;
        bothShoesActive = GetComponent<ShoeController>().bothShoesAssigned;
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            changeDetector = rightShoeAhead;
            if (leftShoe.transform.position.y < rightShoe.transform.position.y)
                rightShoeAhead = true;
            else
                rightShoeAhead = false;

            if (changeDetector != rightShoeAhead)
            {
                highestPosition = -10;
            }

            changeDetector2 = rightShoeGrounded;

            if (rightShoeAhead)
            {
                if (highestPosition < rightShoe.transform.position.y)
                    highestPosition = rightShoe.transform.position.y;
                else if (highestPosition - rightShoe.transform.position.y > shoeGoundedDistance)
                {
                    rightShoeGrounded = true;
                }   
            }

            if (!rightShoeAhead)
            {
                if (highestPosition < leftShoe.transform.position.y)
                    highestPosition = leftShoe.transform.position.y;
                else if (highestPosition - leftShoe.transform.position.y > shoeGoundedDistance)
                {
                    rightShoeGrounded = false;
                }
            }

            if (changeDetector2 != rightShoeGrounded)
            {
                if (rightShoeGrounded)
                {
                    DEBUGWALKTHING.groundedShoePositionLastFrame = rightShoe.transform.position;
                }
                else
                {
                    DEBUGWALKTHING.groundedShoePositionLastFrame = leftShoe.transform.position;
                }
            }

            if (rightShoeGrounded)
            {
                DEBUGWALKTHING.currentGroundedShoePosition = rightShoe.transform.position;
                leftShoe.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                rightShoe.GetComponentInChildren<SpriteRenderer>().color = DEBUGgroundedColor;
            }
            else
            {
                DEBUGWALKTHING.currentGroundedShoePosition = leftShoe.transform.position;
                rightShoe.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                leftShoe.GetComponentInChildren<SpriteRenderer>().color = DEBUGgroundedColor;
            }


            Debug.Log("RightShoeGrounded: " + rightShoeGrounded);
            Debug.Log("RightShoeAhead: " + rightShoeAhead);
            Debug.Log("Distance form highest point: " + (highestPosition - leftShoe.transform.position.y));
            Debug.Log("Left shoe position: " + leftShoe.transform.position.y);
            Debug.Log("Right shoe position: " + rightShoe.transform.position.y);
        }
    }   
}
