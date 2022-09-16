using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAssignment : ProcessingLite.GP21
{
    Vector2 circlePosition;
    Vector2 circleMovement;
    Vector2 mousePosition;
    Vector2 triangleVector;
    Vector2 triVecReverse;

    float circleDiameter = 1;
    [Range(0.0f, 1.0f)]
    public float triangleMultiplier;
    float MovementMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(0.4f);
        Fill(255);
        Stroke(255);

    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        mousePosition = new Vector2(MouseX, MouseY);

        if (Input.GetMouseButtonDown(0))
        {
            circlePosition = mousePosition;
            circleMovement = Vector2.zero;
        }

        if (Input.GetMouseButton(0))
        {
            triangleVector = circlePosition - mousePosition;
            triVecReverse.x = triangleVector.y * -1;
            triVecReverse.y = triangleVector.x;
            Triangle(
                mousePosition.x,
                mousePosition.y,
                mousePosition.x + (triangleVector.normalized.x*triangleMultiplier) + (triVecReverse.normalized.x*triangleMultiplier),
                mousePosition.y + (triangleVector.normalized.y*triangleMultiplier) + (triVecReverse.normalized.y*triangleMultiplier),
                mousePosition.x + (triangleVector.normalized.x*triangleMultiplier) - (triVecReverse.normalized.x*triangleMultiplier),
                mousePosition.y + (triangleVector.normalized.y*triangleMultiplier) - (triVecReverse.normalized.y*triangleMultiplier)
                ); //All this just to draw a triangle in the right position and direction


            Line(circlePosition.x, circlePosition.y, mousePosition.x, mousePosition.y); //Draw line
        }

        if (Input.GetMouseButtonUp(0))
        {
            circleMovement = ((mousePosition-circlePosition)*MovementMultiplier)*Time.deltaTime; //Calculate Movement Vector
        }
        circlePosition = circlePosition + circleMovement; //Move Circle position

        //Collision and bounce
        if (circlePosition.x + (circleDiameter / 2) > Width || circlePosition.x - (circleDiameter / 2) < 0)
        {
            circleMovement = Vector2.Reflect(circleMovement, Vector2.left);
        }     
        if (circlePosition.y + (circleDiameter / 2) > Height || circlePosition.y - (circleDiameter / 2) < 0)
        {
            circleMovement = Vector2.Reflect(circleMovement, Vector2.down);
        }

        Circle(circlePosition.x, circlePosition.y, circleDiameter); //Draw circle
    }
}
