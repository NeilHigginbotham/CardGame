using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text healthText;


    public Image cardBorder;
    public Image artworkImage;

    public bool hasBeenPlayed;
    public int handIndex;

    private GameController gm;

    void Start()
    {
        gm = FindObjectOfType<GameController>();
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
        manaText.text = card.manaCost.ToString();
        cardBorder.sprite = card.cardBorder;
    }

    // Update is called once per frame
    public void PlayCard()
    {
        if (hasBeenPlayed == false)
        {
            transform.position += Vector3.up * 5;
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            Debug.Log("Card played");
        }
    }
}