using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : ProcessingLite.GP21
{
    public int charCount;
    Character[] circleChar;
    float[] disToCircle;
    bool gameOver = false;
    int arrayIndex;

    // Start is called before the first frame update
    void Start()
    {
        circleChar = new Character[charCount];
        disToCircle = new float[charCount];

        for (int i = 0; i < charCount; i++)
        {
            circleChar[i] = new Character();
        }
        circleChar[UnityEngine.Random.Range(1, charCount)].isZombie = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Background(255);
            for (int i = 0; i < charCount; i++)
            {
                circleChar[i].UpdateChar();
                circleChar[i].DrawChar();

                if (circleChar[i].isZombie)
                {
                    Array.Clear(disToCircle, 0, charCount);
                    for (int e = 0; e < charCount; e++)
                    {
                        if (circleChar[e].isZombie == false)
                        {
                            disToCircle[e] = Vector2.Distance(circleChar[i].charPos, circleChar[e].charPos);
                        }

                        if (circleChar[i].ZombieColission(circleChar[e].charPos, circleChar[e].charSize))
                            circleChar[e].isZombie = true;
                    }
                    arrayIndex = circleChar[i].GetIndexOfLowestValue(disToCircle);
                    if (arrayIndex != -1)
                    {
                        circleChar[i].charVel = (circleChar[arrayIndex].charPos - circleChar[i].charPos).normalized * circleChar[i].charVel.magnitude;
                        Debug.Log(arrayIndex);
                    }
                    else
                    {
                        gameOver = true;
                    }
                    

                }


            }
        }
        else
        {
            Background(255);
            Fill(0, 0, 0);
            TextSize((int)(Width * 5));
            Text("Game over", Width / 2, (Height / 3) * 2);
        }
    }
}
