using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(0.2f);
        Background(0);
        for (int i = 0; i < Height; i++)
        {
            if (i % 3 == 0)             //Every third line turns red
                Stroke(255, 0, 0);
            else
                Stroke(255, 255, 255);

            Line(0, Height - i, i + 1, 0); //Draw the line
        }
    }

    }
