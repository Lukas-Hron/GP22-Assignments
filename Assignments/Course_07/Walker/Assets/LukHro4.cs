using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class LukHro4 : IRandomWalker
{
	int lineLegnth=3;
	int tickCounter;
	int dirCounter;
	Vector2Int currentPosition;
	public string GetName()
	{
		return "Hronare";
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		currentPosition = new Vector2Int(playAreaWidth/2,playAreaHeight/2);
		return currentPosition;
	}

	public Vector2 Movement()
	{
		tickCounter++;
		if (tickCounter % lineLegnth == 0)
        {

			if (dirCounter <= 2)
            {
				dirCounter++;
            }

            else
            {
                dirCounter = 0;
			}

        }

        if (dirCounter % 2 == 0)
        {
			lineLegnth++;
		}

		switch (dirCounter)
		{
			case 0:
				return Vector2.up;
			case 1:
				return Vector2.right;
			case 2:
				return Vector2.down;
			default:
				return Vector2.left;
		}
	}

}