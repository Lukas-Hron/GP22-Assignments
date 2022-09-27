using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ProcessingLite.GP21
{
    private float zombieMoveSpeedMultiplier = 0.5f;
    public float charSize;
    public Vector2 charPos;
    public Vector2 charVel;
    Vector2 rotCharVel;
    Vector3Int charColor;
   public bool isZombie;

    public Character()
    {
        charSize = Random.Range(0.4f, 0.5f);
        charPos = new Vector2(Random.Range(0 + (charSize / 2), Width - (charSize / 2)), Random.Range(0 + (charSize / 2), Height - (charSize / 2)));
        charVel = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        charColor = new Vector3Int(Random.Range(232 - 20, 232 + 20), Random.Range(190 - 10, 190 + 10), Random.Range(172 - 10, 172 + 10));
    }

    public void UpdateChar()
    {
        if (!isZombie)
            charPos += charVel * Time.deltaTime;
        else
        {
            charPos += (charVel*zombieMoveSpeedMultiplier) * Time.deltaTime;
        }


        if (charPos.x > Width)
            charPos.x -= Width;
        else if (charPos.x < 0)
            charPos.x += Width;

        if (charPos.y > Height)
            charPos.y -= Height;
        else if (charPos.y < 0)
            charPos.y += Height;
    }

    public void DrawChar()
    {
        NoStroke();
        if (!isZombie)
        Fill(charColor.x, charColor.y, charColor.z);
        else
        {
            Fill(20, 100, 20);
        }


        Circle(charPos.x, charPos.y, charSize);
    }


    public bool ZombieColission(Vector2 otrPos, float otrSize)
    {
        float maxDistance = (otrSize) / 2f + (charSize) / 2f;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(otrPos.x - charPos.x) > maxDistance || Mathf.Abs(otrPos.y - charPos.y) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(otrPos.x, otrPos.y), new Vector2(charPos.x, charPos.y)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
    private Vector2 RotateVector2(Vector2 vec)
    {
        return new Vector2(vec.y, vec.x * -1.0f);
    }


    //Stole this code 
    public int GetIndexOfLowestValue(float[] arr)
    {
        float value = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < value && arr[i] >= 0.05)
            {
                index = i;
                value = arr[i];
            }
        }
        Debug.LogError(index);
        return index;
    }


}
