using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : ProcessingLite.GP21
{
    Vector2 horizonPoint;
    public float rectAmount;
    float frameCount;
    public int recSpeed;


    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(0.2f);
        Stroke(0, 255, 0);
        Application.targetFrameRate = 24;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount %= recSpeed;


        Background(0, 0, 0);
        horizonPoint.x = Width / 2;
        horizonPoint.y = Height / 2;

        for (int i = 1; i < rectAmount; i++)
        {
            Rect(
            Vector2.Lerp(Vector2.zero, horizonPoint, (1/rectAmount)* ((float)i)).x,
            Vector2.Lerp(Vector2.zero, horizonPoint,(1/rectAmount)* (float)i).y,
            Vector2.Lerp(new Vector2(Width, Height), horizonPoint,(1/rectAmount)* (float)i).x,
            Vector2.Lerp(new Vector2(Width, Height), horizonPoint,(1/rectAmount)* (float)i).y);
        }

        //Draw 3 central lines
        for (float i = 1; i < 4; i++)
        {
            LineToHorizon((Width / 4) * i, 0);
            LineToHorizon((Width / 4) * i, Height);
            LineToHorizon(0, (Height / 4) * i);
            LineToHorizon(Width, (Height / 4) * i);
        }
        //Draw corner lines
        LineToHorizon(0, 0);
        LineToHorizon(Width, 0);
        LineToHorizon(0, Height);
        LineToHorizon(Width, Height);



    }
    void LineToHorizon(float floatX,float floatY)
    {
        Line(floatX, floatY, horizonPoint.x, horizonPoint.y);
    }
}
