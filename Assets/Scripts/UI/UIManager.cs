using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject victoryPanel;
    public GameObject losePanel;
    public GameObject HUDPanel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        losePanel.SetActive(false);
        HUDPanel.SetActive(true);
        
    
    }

    void Update()
    {
        if (gameManager.GetGameState() == GameState.Victory)
        {
            SetVictoryPanels();
        }
        else if (gameManager.GetGameState() == GameState.GameOver)
        {
            SetGameOverPanels();
        }
        else
        {
            //gameplay
        }
    }

    private void SetGameOverPanels()
    {
        victoryPanel.SetActive(false);
        losePanel.SetActive(true);
        HUDPanel.SetActive(false);
    }
    
    private void SetVictoryPanels()
    {
        victoryPanel.SetActive(true);
        losePanel.SetActive(false);
        HUDPanel.SetActive(false);
    }
}
