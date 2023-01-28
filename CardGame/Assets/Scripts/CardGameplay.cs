using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardGameplay : MonoBehaviour
{
    public Card card;
    public Transform battlePoint;
    public Transform handPoint;
    [SerializeField]
    public bool onBattle = false;
    public int player;
    public GameManager gameManager;
    public int health;
    public int damage;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        health = card.health;
        damage = card.damage;
    }

    private void Update()
    {
        if (gameManager.winner == 1 && player == 1)
        {
            animator.SetBool("Win", true);
        }
        else if (gameManager.winner == 2 && player == 2)
        {
            animator.SetBool("Win2", true);
        }
    }
}
