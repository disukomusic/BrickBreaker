using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float launchSpeed;
    public float delayBeforeLaunch;
    
    private Rigidbody2D _rigidbody2D;
    private float timer;
    private GameManager _gameManager;
    private bool launched;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {   
        //FireInRandomDirection();
        timer = 0;
        launched = false;
    }

    void Update()
    {
        if (!launched)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeLaunch)
            {
                FireInRandomDirection();
            } 
        }
    }
    
    public void SetGameManager(GameManager manager)
    {
        _gameManager = manager;
    }
    
    public void FireInRandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        while (Mathf.Abs(randomDirection.y) < 0.1f)
        {   
           randomDirection = Random.insideUnitCircle.normalized;
        }
        
        _rigidbody2D.velocity = randomDirection * launchSpeed;
        launched = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _gameManager.BallDeath();
        if (col.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject); 
        }
    }
}
