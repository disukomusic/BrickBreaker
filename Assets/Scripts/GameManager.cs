using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;

    private GameState gameState;
    private int lives;
    
    void Start()
    {
        gameState = GameState.Gameplay;
        lives = 3;
        SpawnInNewBall();
    }

    public GameState GetGameState()
    {
        return gameState;
    }
    
    //called by the ball when it goes into death zone.
    public void BallDeath()
    {
        lives -= 1;
        if (lives == 0)
        {
            gameState = GameState.GameOver;
        }
        SpawnInNewBall();
    }

    //called by brick when it is destroyed
    public void BrickDestroyed()
    {
        Brick[] bricks = GameObject.FindObjectsOfType<Brick>();
        Debug.Log("Bricks in Scene:" + bricks.Length);
        if (bricks.Length <= 1)
        {
                gameState = GameState.Victory;
        }
    }
    
    private void SpawnInNewBall()
    {
        if (gameState == GameState.Gameplay)
        {
            GameObject ballObject = Instantiate(ballPrefab, ballSpawnLocation.position, Quaternion.identity);
            Ball ball = ballObject.GetComponent<Ball>();
            ball.SetGameManager(this);  
        }
    }
}
