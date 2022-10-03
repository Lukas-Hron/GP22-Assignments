using UnityEngine;

public class WalkerTest : ProcessingLite.GP21
{
	//This file is only for testing your movement/behavior.
	//The Walkers will compete in a different program!

	IRandomWalker walker;
	Vector2 walkerPos;
	Vector2 lastWalkerPos;
	float scaleFactor = 0.05f;

	void Start()
	{
		//Some adjustments to make testing easier
		Application.targetFrameRate = 1200;
		QualitySettings.vSyncCount = 0;

		//Create a walker from the class Example it has the type of WalkerInterface
		walker = new LukHro4();

        //Get the start position for our walker.
        walkerPos = walker.GetStartPosition((int)(Width / scaleFactor), (int)(Height / scaleFactor));
		lastWalkerPos = walkerPos;
		Stroke(255);
		StrokeWeight(0.2f);
	}

	void Update()
	{
		walkerPos += walker.Movement();
		//Draw the walker
		Line(walkerPos.x * scaleFactor, walkerPos.y * scaleFactor, lastWalkerPos.x * scaleFactor, lastWalkerPos.y * scaleFactor);
		//Get the new movement from the walker.
		lastWalkerPos=walkerPos;
	}
}
