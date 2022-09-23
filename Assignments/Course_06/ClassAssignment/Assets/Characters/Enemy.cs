using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ProcessingLite.GP21
{
    Vector2 position;
    public Vector2 velocity;
    float size = 2f;

    public Enemy(Vector2 playerPos, float playerSize)
    {
        float maxDistance = playerSize*2 + (size/2);

        position.x = Random.Range(0 + size, Width - size);
        position.y = Random.Range(0 + size, Height - size);

        while (Vector2.Distance(playerPos,position) < maxDistance)
        {
            position.x = Random.Range(0 + size, Width - size);
            position.y = Random.Range(0 + size, Height - size);
            Debug.LogWarning("Ball Spawned in player, resetting position");
        }

        velocity.x = Random.Range(-2f,2f);
        velocity.y = Random.Range(-2f,2f);
    }
    public void Draw()
    {
        NoStroke();
        Fill(255, 0, 0);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {
        ColissionCheck();
        position += velocity * Time.deltaTime;
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
    public bool PlayerCollision(Vector2 playerPos,float playerSize)
    {
        float maxDistance = (playerSize)/2f + (size)/2f;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(playerPos.x - position.x) > maxDistance || Mathf.Abs(playerPos.y - position.y) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(playerPos.x, playerPos.y), new Vector2(position.x, position.y)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }

}
