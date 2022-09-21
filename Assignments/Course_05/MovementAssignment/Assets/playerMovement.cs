using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : ProcessingLite.GP21
{
    public AudioSource audioSource;
    public AudioClip bounce;
    public AudioClip kill;
    Vector2 playerVelocity;
    Vector2 playerAcceleration;
    float playerDrag = 200f;
    float bounceLoss = 0.9f;
    Vector2 playerPosition;

    public float circleSize = 3f;

    Vector2 enemyPosition;

    float shakeOffset;
    Vector2 screenOffset;
    public float shakeMultiplier;

    bool winCondition = true;
    double gameTimer;
    double highScore;
    float endTimeBuffer;
    float soundPlayBuffer;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition.x = Width / 2;
        playerPosition.y = Height / 2;
        ResetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (endTimeBuffer>3)
        GetPlayerAcceleration();

        playerVelocity += (playerAcceleration / 10) * Time.deltaTime; //Change velocity based on acceleration
        playerVelocity -= (playerDrag * Time.deltaTime) * (playerVelocity / 100); //Add drag to player velocity



        //Collision
        if (playerPosition.x - (circleSize / 2) < 0)
        {
            playerVelocity = (Vector2.Reflect(playerVelocity, Vector2.left) * bounceLoss);
            playerPosition.x += (circleSize / 2) - (playerPosition.x);
            shakeOffset = playerVelocity.x * shakeMultiplier;
            PlayBounceSound();
        }
        if (playerPosition.x + (circleSize / 2) > Width)
        {
            playerVelocity = (Vector2.Reflect(playerVelocity, Vector2.left) * bounceLoss);
            playerPosition.x = playerPosition.x - ((circleSize / 2) - (Width - playerPosition.x));
            shakeOffset = -playerVelocity.x * shakeMultiplier;
            PlayBounceSound();
        }

        if (playerPosition.y - (circleSize / 2) < 0)
        {
            playerVelocity = (Vector2.Reflect(playerVelocity, Vector2.down) * bounceLoss);
            playerPosition.y += (circleSize / 2) - (playerPosition.y);
            shakeOffset = playerVelocity.y * shakeMultiplier;
            PlayBounceSound();
        }
        if (playerPosition.y + (circleSize / 2) > Height)
        {
            playerVelocity = (Vector2.Reflect(playerVelocity, Vector2.down) * bounceLoss);
            playerPosition.y = playerPosition.y - ((circleSize / 2) - (Height - playerPosition.y));
            shakeOffset = -playerVelocity.y * shakeMultiplier;
            PlayBounceSound();
        }
        if (Vector2.Distance(playerPosition, enemyPosition) < (circleSize / 2) + (circleSize / 4)) //Enemy colission 
        {
            audioSource.PlayOneShot(kill, 1);
            playerVelocity = (Vector2.Reflect(playerVelocity, (playerPosition - enemyPosition).normalized));
            shakeOffset = playerVelocity.magnitude * shakeMultiplier;
            if (circleSize > 0.3f)
            {
                circleSize -= 0.1f;
            }
            else
            {
                circleSize = 3f; //win reset
                playerPosition.x = Width / 2;
                playerPosition.y = Height / 2;
                winCondition = true;
                endTimeBuffer = 0;
                playerAcceleration = Vector2.zero;
                playerVelocity = Vector2.zero;
            }

            ResetEnemy();

            while (Vector2.Distance(playerPosition, enemyPosition) < circleSize * 2)
            {
                ResetEnemy();
            }
        }

        //Screen shake
        if (shakeOffset > 0)
        {
            shakeOffset -= 2 * Time.deltaTime;
            screenOffset.x = Random.Range((shakeOffset / 4) * -1, shakeOffset / 4);
            screenOffset.y = Random.Range((shakeOffset / 4) * -1, shakeOffset / 4);
        }
        else
        {
            shakeOffset = 0;
            screenOffset = Vector2.zero;
        }

        playerPosition += playerVelocity; //Add velocity to player
        Background(0);
        NoStroke();
        Fill(255);
        Circle(playerPosition.x + screenOffset.x, playerPosition.y + screenOffset.y, circleSize);  //draw player circle
        Fill(255, 0, 0);
        Circle(enemyPosition.x + screenOffset.x, enemyPosition.y + screenOffset.y, circleSize / 2); //draw enemy circle
        NoFill();
        Stroke(255);
        Rect(screenOffset.x + Width, screenOffset.y + Height, screenOffset.x, screenOffset.y);

        if (winCondition)
        {
            WinCondition(gameTimer);
        }
        else
        {
            Fill(100, 100, 100);
            gameTimer += Time.deltaTime;
            TextSize((int)(Width * 2));
            Text((Mathf.Round((float)gameTimer * 100) / 100).ToString() + " Seconds.", Width / 2, (Height / 6) * 5);
        }
    }

    public Vector2 GetPlayerAcceleration()
    {
        if (Input.GetKey(KeyCode.W))
            playerAcceleration.y = 1;
        else if (Input.GetKey(KeyCode.S))
            playerAcceleration.y = -1;
        else
            playerAcceleration.y = 0;

        if (Input.GetKey(KeyCode.D))
            playerAcceleration.x = 1;
        else if (Input.GetKey(KeyCode.A))
            playerAcceleration.x = -1;
        else
            playerAcceleration.x = 0;

        return playerAcceleration;
    }

    void ResetEnemy()
    {
        enemyPosition.x = Random.Range((circleSize / 4), Width - (circleSize / 4));
        enemyPosition.y = Random.Range((circleSize / 4), Height - (circleSize / 4));
    }

    void WinCondition(double finalTime)
    {
        Fill(100, 100, 100);
        TextSize((int)(Width * 5));

        if (finalTime < highScore)
        {
            Text("High Score!", Width / 2, (Height / 3) * 2);
        }
        else
        {
            Text("Finish!", Width / 2, (Height / 3) * 2);
        }


        TextSize((int)(Width * 3));
        Text((Mathf.Round((float)finalTime * 100) / 100).ToString() + " Seconds.", Width / 2, (Height / 2));
        if (playerAcceleration != Vector2.zero)
        {
            winCondition = false;
            highScore = finalTime;
            gameTimer = 0;
        }
        endTimeBuffer += Time.deltaTime;


    }
    void PlayBounceSound()
    {
        if (playerVelocity.magnitude>0.01)
            audioSource.PlayOneShot(bounce, playerVelocity.magnitude*50);
    }

}
