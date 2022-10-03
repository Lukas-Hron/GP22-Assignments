using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class LukHro : IRandomWalker
{
    Vector2Int currentPosition;
	Vector2Int firstPosition;
	List<Vector2> pastPositions = new List<Vector2>();
	Vector2 playArea;

	public string GetName()
	{
		return "Hronaren";
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		currentPosition.x = Random.Range(playAreaWidth/100, playAreaWidth - (playAreaWidth / 100));
        currentPosition.y = Random.Range(playAreaWidth / 100, playAreaHeight - (playAreaWidth / 100));
		playArea = new Vector2(playAreaWidth, playAreaHeight);

		firstPosition = currentPosition;
		return currentPosition;
	}

	public Vector2 Movement()
	{
		if (pastPositions.Contains(currentPosition))
		{
			pastPositions.Add(currentPosition);
			switch (Random.Range(0, 4))
			{
				case 0:
					if (currentPosition.y + Vector2Int.up.y > playArea.y)
                    {
						currentPosition += Vector2Int.down;
						return new Vector2(0, -1);						
					}

					currentPosition += Vector2Int.up;
					return new Vector2(0, 1);

				case 1:
					if(currentPosition.y + Vector2Int.down.y < 0)
                    {
						currentPosition += Vector2Int.up;
						return new Vector2(0, 1);
					}
					currentPosition += Vector2Int.down;
					return new Vector2(0, -1);

				case 2:
					if (currentPosition.x + Vector2Int.left.x < 0)
					{
						currentPosition += Vector2Int.right;
						return new Vector2(-1, 0);
					}
					currentPosition += Vector2Int.left;
					return new Vector2(1, 0);

				default:
					if (currentPosition.x + Vector2Int.right.x > playArea.x)
					{
						currentPosition += Vector2Int.left;
						return new Vector2(1, 0);
					}
					currentPosition += Vector2Int.right;
					return new Vector2(-1, 0);
			}
		}
		else
		{



			List<float> dirWeights = new List<float>();

			dirWeights.Add(PosWeight(currentPosition + Vector2.up));
			dirWeights.Add(PosWeight(currentPosition + Vector2.down));
			dirWeights.Add(PosWeight(currentPosition + Vector2.left));
			dirWeights.Add(PosWeight(currentPosition + Vector2.right));

			pastPositions.Add(currentPosition);

            foreach (var x in dirWeights)
            {
                Debug.Log(x.ToString());
            }
            Debug.Log("------------------------------------------------");
            Debug.Log(dirWeights.AsQueryable().Min());
            Debug.Log(dirWeights.IndexOf(dirWeights.AsQueryable().Min()));
            Debug.Log(currentPosition);
            Debug.Log(playArea);
            Debug.Log("------------------------------------------------");
            if (currentPosition.x > playArea.x || currentPosition.x < 0 || currentPosition.y > playArea.y || currentPosition.y < 0)
				Debug.LogError("DEAD");

			switch (dirWeights.IndexOf(dirWeights.AsQueryable().Min()))
			{
				case 0:
					currentPosition += Vector2Int.up;
					return new Vector2(0, 1);
				case 1:
					currentPosition += Vector2Int.down;
					return new Vector2(0, -1);
				case 2:
					currentPosition += Vector2Int.left;
					return new Vector2(1, 0);
				default:
					currentPosition += Vector2Int.right;
					return new Vector2(-1, 0);
			}
		}

	}

	private float PosWeight(Vector2 pos)
    {
		float weight=0f;

		Vector2[] posToCheck =
			{
			pos,
			pos+Vector2.up,
			pos+Vector2.down,
			pos+Vector2.left,
			pos+Vector2.right
			};

		foreach (Vector2 i in posToCheck)
        {
            if (pastPositions.Contains(i))
            {
                weight++;
            }

			if (i.x <= 0 || i.x >= playArea.x)
			{
				weight += 1000000;
			}
			if (i.y <= 0 || i.y >= playArea.y)
			{
				weight += 1000000;
			}

		}
		if (pastPositions.Contains(pos))
		{
			weight+=100;
		}

		return (weight) + (Vector2.Distance(firstPosition, pos) / (playArea.y*5));		

	}
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!
