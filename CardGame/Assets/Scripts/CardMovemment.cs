using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovemment : MonoBehaviour
{
    public GameManager gameManager;
    public CardGameplay cardGameplay;
    public void OnMouseDown()
    {
        if (cardGameplay.player == gameManager.playerRound)
        {
            if(!cardGameplay.onBattle)
            {
                cardGameplay.onBattle = true;
                transform.position = cardGameplay.battlePoint.position;
                gameManager.playerRound++;
                gameManager.narratorText.text = "Player 2 Round!";
            }
        }

        if (gameManager.playerRound == 3)
        {
            gameManager.Battle();
        }
    }
}
