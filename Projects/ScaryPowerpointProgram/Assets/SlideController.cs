using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public GameObject puzzle1;
    public GameObject puzzle2;

    public CameraController cam;
    public int slideCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.PageUp))
        {
            slideCount--;
            Slide();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.PageDown))
        {
            slideCount++;
            Slide();
        }
    }

    public void Slide()
    {
        
        switch (slideCount)
        {
            case 1:
                cam.NextSlide(8, 17, 0);
                break;
            case 2:
                cam.NextSlide(5, 10.1f, 0);
                break;
            case 3:
                cam.NextSlide(6, 3.2f, 0);
                break;
            case 4:
                cam.NextSlide(4, -1f, 0);
                break;
            case 5:
                cam.NextSlide(0.1f, -1f, 1);
                break;
            case 6:
                cam.NextSlide(0.1f, -1f, 2);
                break;
            case 7:
                cam.NextSlide(3, -5.6f, 0);
                break;
            case 8:
                cam.NextSlide(10, 29.45f, 0);
                break;
            default:
                // code block
                break;
        }
    }
}
