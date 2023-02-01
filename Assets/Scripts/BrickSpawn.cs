using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawn : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject brickPrefab;
    public Transform _brickStart;
    public int columnCount;
    public int rowCount;

    void Awake()
    {
        _brickStart = GetComponent<Transform>();
        for (int i = 0; i < rowCount; i += 1)
        {
            BrickLine(-i, columnCount);
        }
    }


    public void BrickLine(float yPos, int width)
    {
        for(int i = 0; i < width; i+= 1)
        {
            GameObject brick = Instantiate(brickPrefab, _brickStart.position + new Vector3(i,yPos,0), Quaternion.identity);
            brick.GetComponent<Brick>().SetGameManager(gameManager);
        }
    }
    
}
