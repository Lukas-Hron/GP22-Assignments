using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    float Ymultiplier;
    float time;
    public float sizeMultiplier;

    void Update()
    {

        time += Time.deltaTime;
        Ymultiplier = Mathf.Cos(time);
        Background(0);

        for (int i = 0; i < 20; i++) //Draw name offset in different sizes/colors
        {
            sizeMultiplier = 0.8f+((float)i/100);
            Stroke(i*5, 0, i*5);
            DrawName();
        } 
    }

    public float Yvalue(float i)
    {
        return (i - 5) * (sizeMultiplier * Ymultiplier) + 5;
    }

    public float Xvalue(float i)
    {
        return (i-2.5f) * (sizeMultiplier)+2.5f;
    }

    public void DrawName()
    {
        BeginShape();//L
        Vertex(Xvalue(3), Yvalue(8));
        Vertex(Xvalue(3), Yvalue(3));
        Vertex(Xvalue(7), Yvalue(3));
        Vertex(Xvalue(7), Yvalue(4));
        Vertex(Xvalue(4), Yvalue(4));
        Vertex(Xvalue(4), Yvalue(8));
        Vertex(Xvalue(3), Yvalue(8));
        EndShape();

        BeginShape();//H
        Vertex(Xvalue(8), Yvalue(8));
        Vertex(Xvalue(8), Yvalue(3));
        Vertex(Xvalue(9), Yvalue(3));
        Vertex(Xvalue(9), Yvalue(5.5f));
        Vertex(Xvalue(11), Yvalue(5.5f));
        Vertex(Xvalue(11), Yvalue(3));
        Vertex(Xvalue(12), Yvalue(3));
        Vertex(Xvalue(12), Yvalue(8));
        Vertex(Xvalue(11), Yvalue(8));
        Vertex(Xvalue(11), Yvalue(6.5f));
        Vertex(Xvalue(9), Yvalue(6.5f));
        Vertex(Xvalue(9), Yvalue(8));
        Vertex(Xvalue(9), Yvalue(8));
        Vertex(Xvalue(8), Yvalue(8));
        EndShape();
    }

}
