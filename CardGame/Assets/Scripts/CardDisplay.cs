using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;

    public Image artworkImage;
    void Start()
    {
        nameText.text = card.name;

        artworkImage.sprite = card.artwork;
        
        damageText.text = card.damage.ToString();
        healthText.text = card.health.ToString();
    }
}
