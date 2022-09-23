using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    float accelerationMultiplier = 30;
    float drag = 0.997f;
    public Vector2 position;
    public Vector2 velocity;
    public float size = 0.5f;

    public Player(float x, float y)
    {
        position = new Vector2(x, y);
    }

    public void Draw()
    {
        NoStroke();
        Fill(255);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {
        ColissionCheck();
        velocity += Acceleration() * Time.deltaTime * accelerationMultiplier;
        velocity *= drag;
        position += velocity * Time.deltaTime;
    }
    private Vector2 Acceleration()
    {
        Vector2 inputAcceleration;

        if (Input.GetKey(KeyCode.W))
            inputAcceleration.y = 1;
        else if (Input.GetKey(KeyCode.S))
            inputAcceleration.y = -1;
        else
            inputAcceleration.y = 0;

        if (Input.GetKey(KeyCode.D))
            inputAcceleration.x = 1;
        else if (Input.GetKey(KeyCode.A))
            inputAcceleration.x = -1;
        else
            inputAcceleration.x = 0;

        return inputAcceleration.normalized;
    }
    private void ColissionCheck()
    {
        if (position.x - (size / 2) < 0)
        {
            velocity = (Vector2.Reflect(velocity, Vector2.left));
            position.x += (size / 2) - (position.x);
        }
        if (position.x + (size / 2) > Width)
        {
            velocity = (Vector2.Reflect(velocity, Vector2.left));
            position.x = position.x - ((size / 2) - (Width - position.x));
        }

        if (position.y - (size / 2) < 0)
        {
            velocity = (Vector2.Reflect(velocity, Vector2.down));
            position.y += (size / 2) - (position.y);
        }
        if (position.y + (size / 2) > Height)
        {
            velocity = (Vector2.Reflect(velocity, Vector2.down));
            position.y = position.y - ((size / 2) - (Height - position.y));
        }
    }
}
