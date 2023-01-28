using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerRound = 1;

    public CardGameplay cardPlayer1;
    public CardGameplay cardPLayer2;

    public void Awake()
    {
        
    }

    public void Battle()
    {
        if (cardPlayer1.damage >= cardPLayer2.health && cardPLayer2.damage >= cardPlayer1.health)
        {
            Debug.Log("Draw!");
        }
        else if (cardPLayer2.damage >= cardPlayer1.health)
        {
            Debug.Log("Player 2 Wins!");
        }
        else if (cardPlayer1.damage >= cardPLayer2.health)
        {
            Debug.Log("Player 1 Wins!");
        }
        else
        {
            Debug.Log("Draw!");
        }
    }
    
    public void EndRound()
    {
        switch (playerRound)
        {
            case 1: playerRound = 2;
                break;
            case 2: playerRound = 1;
                break;
            default: Debug.Log("No PLayers Found");
                break;
        }
    }
}
