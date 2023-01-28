using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerRound = 1;
    public ParticleSystem PS1;
    public ParticleSystem PS2;
    public Button button;

    public int winner = 0;

    public GameObject card1;
    public GameObject card2;
    public CardGameplay cardPlayer1;
    public CardGameplay cardPLayer2;

    public void StartGame()
    {
        card1.SetActive(true);
        card2.SetActive(true);
    }

    public void Battle()
    {
        if (cardPlayer1.damage >= cardPLayer2.health && cardPLayer2.damage >= cardPlayer1.health)
        {
            Debug.Log("Draw!");
            button.gameObject.SetActive(true);
        }
        else if (cardPLayer2.damage >= cardPlayer1.health)
        {
            Debug.Log("Player 2 Wins!");
            PS2.Play();
            winner = 2;
            button.gameObject.SetActive(true);
        }
        else if (cardPlayer1.damage >= cardPLayer2.health)
        {
            Debug.Log("Player 1 Wins!");
            PS1.Play();
            winner = 1;
            button.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Draw!");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
