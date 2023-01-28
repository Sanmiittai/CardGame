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
    private bool onBattle = false;
    public int player;
    public GameManager gameManager;
    public int health;
    public int damage;

    static List<CardGameplay> objectList;
 
    void Awake()
    {
        if(objectList == null) //to make sure the list is only initialized once
            objectList = new List<CardGameplay>();
        AddToList(this); //every MyClass object will execute this once, thus every MyClass will be in the list
    }
 
    void AddToList(CardGameplay classObject) //we do this to avoid adding an object twice to the list
    {
        if(!objectList.Contains(classObject)) //dont add if its already there
            objectList.Add(classObject);
    }
 
//with that you can simply search in that list for an object that has that boolean true:
 
    public static CardGameplay GetCardOnBattle()
    {
        return objectList.Find(x => x.onBattle = true); //find object x that has "yourBooleanValue" true
    }
    private void Start()
    {
        health = card.health;
        damage = card.damage;
    }

    public void OnMouseDown()
    {
        if (player == gameManager.playerRound)
        {
            if(!onBattle)
            {
                onBattle = true;
                transform.position = battlePoint.position;
            }
            else
            {
                onBattle = false;
                transform.position = handPoint.position;
            }
        }
    }
}
