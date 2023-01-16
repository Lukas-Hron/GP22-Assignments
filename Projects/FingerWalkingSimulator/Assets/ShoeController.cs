using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeController : MonoBehaviour
{
    public bool bothShoesAssigned;
    [SerializeField] public GameObject rightShoe, leftShoe;
    int rightShoeAssigned = -1, leftShoeAssigned = -1;
    [SerializeField] float rotationAngle;


    private void Update()
    {
        if (rightShoeAssigned != -1 && leftShoeAssigned != -1)
        {
            bothShoesAssigned = true;
        }
        else
        {
            bothShoesAssigned = false;
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2 && leftShoeAssigned == -1)
                {
                    leftShoeAssigned = touch.fingerId;
                }
                else if (rightShoeAssigned == -1)
                {
                    rightShoeAssigned = touch.fingerId;
                }
            }

            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                if (touch.fingerId == rightShoeAssigned)
                {
                    rightShoeAssigned = -1;
                }
                else if (touch.fingerId == leftShoeAssigned)
                {
                    leftShoeAssigned = -1;
                }
            }

            if (touch.fingerId == rightShoeAssigned)
            {
                    rightShoe.transform.position = Camera.main.ScreenToWorldPoint(touch.position) + new Vector3(0, 0, 10);
            }
            else if (touch.fingerId == leftShoeAssigned)
            {
                leftShoe.transform.position = Camera.main.ScreenToWorldPoint(touch.position) + new Vector3(0, 0, 10);
            }
        }
    }

    
}
