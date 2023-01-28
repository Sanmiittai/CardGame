using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Cards")]
    public GameObject peasantPlayer1;
    public GameObject peasantPlayer2;
    public GameObject magePlayer1;
    public GameObject magePlayer2;
    public GameObject knightPlayer1;
    public GameObject knightPlayer2;
    public GameObject warriorPlayer1;
    public GameObject warriorPlayer2;
    public GameObject dragonPlayer1;
    public GameObject dragonPlayer2;

    [Header("Round")]
    public int playerRound = 1;
    
    [Header("Particles")]
    public ParticleSystem PS1;
    public ParticleSystem PS2;
    
    [Header("UI")]
    public Button restartButton;
    public Button startButton;
    public TextMeshProUGUI narratorText;

    [Header("Winner")]
    public int winner = 0;
    
    [Header("Card Scripts")]
    public CardGameplay cardPlayer1;
    public CardGameplay cardPlayer2;

    private float randomCardPlayer1;
    private float randomCardPlayer2;
    
    

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        
        randomCardPlayer1 = Random.Range(1f, 100f);
        switch (randomCardPlayer1)
        {
            case <=10:
                peasantPlayer1.SetActive(true);
                    cardPlayer1 = peasantPlayer1.GetComponent<CardGameplay>();
                break;
            case <=45: magePlayer1.SetActive(true);
                cardPlayer1 = magePlayer1.GetComponent<CardGameplay>();
                break;
            case <=75: knightPlayer1.SetActive(true);
                cardPlayer1 = knightPlayer1.GetComponent<CardGameplay>();
                break;
            case <=95: warriorPlayer1.SetActive(true);
                cardPlayer1 = warriorPlayer1.GetComponent<CardGameplay>();
                break;
            case <=100: dragonPlayer1.SetActive(true);
                cardPlayer1 = dragonPlayer1.GetComponent<CardGameplay>();
                break;
            default: Debug.Log("No Card Found.");
                break;
        }
        
        randomCardPlayer2 = Random.Range(1f, 100f);
        switch (randomCardPlayer2)
        {
            case <=15: peasantPlayer2.SetActive(true);
                cardPlayer2 = peasantPlayer2.GetComponent<CardGameplay>();
                break;
            case <=45: magePlayer2.SetActive(true);
                cardPlayer2 = magePlayer2.GetComponent<CardGameplay>();
                break;
            case <=75: knightPlayer2.SetActive(true);
                cardPlayer2 = knightPlayer2.GetComponent<CardGameplay>();
                break;
            case <=99: warriorPlayer2.SetActive(true);
                cardPlayer2 = warriorPlayer2.GetComponent<CardGameplay>();
                break;
            case <=100:dragonPlayer2.SetActive(true);
                cardPlayer2 = dragonPlayer2.GetComponent<CardGameplay>();
                break;
            default: Debug.Log("No Card Found.");
                break;
        }
        narratorText.text = "Player 1 Round!";
    }

    public void Battle()
    {
        if (cardPlayer1.damage == cardPlayer2.health && cardPlayer2.damage == cardPlayer1.health)
        {
            narratorText.text = "Draw!";
            restartButton.gameObject.SetActive(true);
        }
        else if(cardPlayer1.damage >= cardPlayer2.health && cardPlayer1.health >= cardPlayer2.health && 
                cardPlayer2.damage < cardPlayer1.health)
        {
            narratorText.text = "Player 1 Wins!";
            PS1.Play();
            winner = 1;
            restartButton.gameObject.SetActive(true);
        }
        else if(cardPlayer1.damage >= cardPlayer2.health && cardPlayer1.health > cardPlayer2.health || 
                cardPlayer1.damage > cardPlayer2. damage && cardPlayer1.health >= cardPlayer2.health)
        {
            narratorText.text = "Player 1 Wins!";
            PS1.Play();
            winner = 1;
            restartButton.gameObject.SetActive(true);
        }
        else if (cardPlayer2.damage >= cardPlayer1.health && cardPlayer2.health >= cardPlayer1.health &&
                 cardPlayer1.damage < cardPlayer2.health)
        {
            narratorText.text = "Player 2 Wins!";
            PS2.Play();
            winner = 2;
            restartButton.gameObject.SetActive(true);
        }
        else if (cardPlayer2.damage >= cardPlayer2.health && cardPlayer2.health > cardPlayer1.health ||
                 cardPlayer2.damage > cardPlayer1. damage && cardPlayer2.health >= cardPlayer1.health)
        {
            narratorText.text = "Player 2 Wins!";
            PS2.Play();
            winner = 2;
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            narratorText.text = "Draw!";
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
