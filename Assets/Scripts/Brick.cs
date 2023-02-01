using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        SetGameManager(_gameManager);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            BallHitBrick();
        }
        
    }

    private void BallHitBrick()
    {
        _gameManager.BrickDestroyed();
        Destroy(gameObject);
    }
    
    public void SetGameManager(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    
}

