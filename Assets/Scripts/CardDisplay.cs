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

    public bool hasBeenPlayed = false;
    public int handIndex;

    private GameController gm;

    private TextMeshProUGUI player1manacounter;


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

        player1manacounter = GameObject.Find("player1manacounter").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void PlayCard()
    {
        if (!hasBeenPlayed && GameController.player1ManaCount >= card.manaCost)
        {
            GameController.player1ManaCount -= card.manaCost;
            hasBeenPlayed = true;

            UpdateManaText();

            StartCoroutine(PlayedDelay());
            Debug.Log("Card played. New mana count:" + GameController.player1ManaCount);
        }
        else
        {
            Debug.Log("Not enough mana.");
        }
    }

    private void UpdateManaText()
    {
        player1manacounter.text = "x " + GameController.player1ManaCount.ToString();
    }

    private IEnumerator PlayedDelay()
    {
        transform.position += Vector3.up * 300;
        gm.availableCardSlots[handIndex] = true;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Card played");
    }

}