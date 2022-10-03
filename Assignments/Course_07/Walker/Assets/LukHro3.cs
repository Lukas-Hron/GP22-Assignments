using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class LukHro3 : IRandomWalker
{
    Vector2Int currentPosition;

    List<Vector2Int> pastPositions = new List<Vector2Int>();
    Vector2Int playArea;
    public Vector2Int targetPosition = new Vector2Int(100, 50);
    Vector2 currentVec;

    public string GetName()
    {
        return "Hronaren";
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        currentPosition.x = Random.Range(playAreaWidth / 100, playAreaWidth - (playAreaWidth / 100));
        currentPosition.y = Random.Range(playAreaWidth / 100, playAreaHeight - (playAreaWidth / 100));
        playArea = new Vector2Int(playAreaWidth, playAreaHeight);
        return currentPosition;
    }

    public Vector2 Movement()
    {
        currentVec = BestDir();
        if (currentVec.x == 0 || currentVec.y == 0)
        {
            Vector2Int randomDir = RandomDir();
            currentPosition += randomDir;
            pastPositions.Add(currentPosition);
            return randomDir;
        }


        Vector2Int dirVec = SnapVector(currentVec);
        currentPosition+=dirVec;

        pastPositions.Add(currentPosition);

        return dirVec;
    }

    private Vector2Int SnapVector(Vector2 vec)
    {
        vec = vec.normalized;
        if (Vector2.Dot(Vector2.up, vec) >= 0.5)
            return Vector2Int.up;

        else if (Vector2.Dot(Vector2.down, vec) >= 0.5)
            return Vector2Int.down;

        else if (Vector2.Dot(Vector2.left, vec) >= 0.5)
            return Vector2Int.left;

        else if (Vector2.Dot(Vector2.right, vec) >= 0.5)
            return Vector2Int.right;

        else 
            return Vector2Int.zero;
    }

    private Vector2 BestDir()
    {
        Vector2 sum = Vector2.zero;
        Vector2[] tileVectors = new Vector2[]
        {
            TileVector(currentPosition+Vector2Int.up),
            TileVector(currentPosition+Vector2Int.up+Vector2Int.left),
            TileVector(currentPosition+Vector2Int.up+Vector2Int.right),
            TileVector(currentPosition+Vector2Int.down),
            TileVector(currentPosition+Vector2Int.down+Vector2Int.left),
            TileVector(currentPosition+Vector2Int.down+Vector2Int.right),
            TileVector(currentPosition+Vector2Int.left),
            TileVector(currentPosition+Vector2Int.right),
        };
        foreach (Vector2 x in tileVectors)
        {
            sum += x;
        }
        Debug.Log(sum);

        return sum;
    }

    private Vector2 TileVector(Vector2Int pos)
    {
        if (pos.x >= playArea.x-1||pos.x<= 1)
        {
            return (currentPosition - pos) * 10;
        }
        if (pos.y >= playArea.y - 1 || pos.y <= 1)
        {
            return (currentPosition - pos) * 10;
        }
        if (pastPositions.Contains(pos))
        {
            return (currentPosition - pos);
        }
        else
        {
            return Vector2.zero;
        }
    }

    private Vector2Int RandomDir()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                return new Vector2Int(-1, 0);
            case 1:
                return new Vector2Int(1, 0);
            case 2:
                return new Vector2Int(0, 1);
            default:
                return new Vector2Int(0, -1);
        }
    }
}
