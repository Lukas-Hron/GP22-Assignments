using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassAssignmentMain : ProcessingLite.GP21
{
    public int maxEnemyCount;
    int enemyCount = 1;
    Player playerCircle;
    Enemy[] enemyCircle;
    bool winCondition = false;

    float enemySpawnTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerCircle = new Player(Width / 2, Height / 2);
        enemyCircle = new Enemy[maxEnemyCount];
        enemyCircle[enemyCount] = new Enemy(playerCircle.position,playerCircle.size);
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        if (Input.GetKeyDown(KeyCode.R))
            restartGame();

        if (Time.time > enemySpawnTimer && enemyCount<100)
        {
            enemySpawnTimer += 3;
            enemyCount++;
            enemyCircle[enemyCount] = new Enemy(playerCircle.position, playerCircle.size);
            Debug.Log("Spawned Enemy");
        }



        if (!winCondition)
        {

            playerCircle.UpdatePos();
            playerCircle.Draw();

            for (int i = 1;i<=enemyCount;i++)
            {
                enemyCircle[i].UpdatePos();
                enemyCircle[i].Draw();
                if (enemyCircle[i].PlayerCollision(playerCircle.position, playerCircle.size))
                    winCondition = true;
            }
        }
        else
        {

            Fill(100, 100, 100);
            TextSize((int)(Width * 5));
            Text("Finish!", Width / 2, (Height / 3) * 2);
            playerCircle.velocity = Vector2.zero;
        }

    }

    private void restartGame()
    {
        enemyCount = 1;
        enemyCircle[enemyCount] = new Enemy(playerCircle.position, playerCircle.size);
        winCondition = false;
        playerCircle.velocity = Vector2.zero;
        playerCircle.position = new Vector2(Width / 2, Height / 2);
    }
}
