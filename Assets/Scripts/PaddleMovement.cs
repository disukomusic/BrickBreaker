using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
   
    private Rigidbody2D _rigidbody2D;
    private float _movement;

    public GameManager _gameManager;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_gameManager.GetGameState() == GameState.Gameplay)
        {
            Vector2 delta = new Vector2(_movement * Time.deltaTime * speed, 0);
            _rigidbody2D.MovePosition(_rigidbody2D.position+delta);   
        }

    }
}
