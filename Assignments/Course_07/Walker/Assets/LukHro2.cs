using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class LukHro2 : IRandomWalker
{
    Vector2Int currentPosition;
	Vector2Int playArea;
	public Vector2Int targetPosition = new Vector2Int(100,50);

    public string GetName()
	{
		return "Hronare";
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		currentPosition = new Vector2Int(playAreaWidth / 2,playAreaHeight / 2);
		playArea = new Vector2Int(playAreaWidth, playAreaHeight);
		return currentPosition;
	}

	public Vector2 Movement()
	{
		if (currentPosition == targetPosition)
		{
			AssignNextTarget();
		}

		List<float> howClose = new List<float>();
		howClose.Add(PosWeight(currentPosition + Vector2.up));
		howClose.Add(PosWeight(currentPosition + Vector2.down));
		howClose.Add(PosWeight(currentPosition + Vector2.left));
		howClose.Add(PosWeight(currentPosition + Vector2.right));

		foreach (var x in howClose)
		{
			Debug.Log(x.ToString());
		}

		switch (howClose.IndexOf(howClose.AsQueryable().Min()))
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
	private float PosWeight(Vector2 pos)
	{		
		return Vector2.Distance(pos,targetPosition);

	}

	private void AssignNextTarget()
    {
		targetPosition.x = Random.Range(1, playArea.x - 1);
		targetPosition.y = Random.Range(1, playArea.y - 1);
	}
}