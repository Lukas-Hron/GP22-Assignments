using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolLineTest : ProcessingLite.GP21
{
    int FrameCount;


    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(0.2f);
        Stroke(0, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {    
      FrameCount %= 100;
            Background(0);
            for (int i = 0; i < 10; i++)
        {
            float lerpVal = ((float)i / 10) - ((float)FrameCount / 1000); //This is the worst possible way to do this but i don't care at the moment
            Rect(Mathf.Lerp(0, MouseX, lerpVal), Mathf.Lerp(Height, MouseY, lerpVal), Mathf.Lerp(Width, MouseX, lerpVal), Mathf.Lerp(0, MouseY, lerpVal)); //Render boxes
            }
            for (int i = 0; i < Width; i++) //Render lines
            {
                Line(i, 0, MouseX, MouseY);
                Line(i, Height, MouseX, MouseY);
            }
            for (int i = 0; i < Height; i++) //Render Lines
            {
                Line(0, i, MouseX, MouseY);
                Line(Width, i, MouseX, MouseY);
            }
        FrameCount++;
        }
    }
