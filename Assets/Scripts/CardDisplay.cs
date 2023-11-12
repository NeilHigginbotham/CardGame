using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{


    // References to the card text below as indicated for each card

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text healthText;


    public Image cardBorder;
    public Image artworkImage;

    public bool hasBeenPlayed = false; // Stops card from being played after being played already
    public bool isBeingPlayed = false; // Stops card from being played over and over before it enters battlefield
    public bool isOnBattlefield = false; // useful for lots of our logic for creatures and lands.
    public int handIndex;

    private GameController gm;
    public Card card;
    private TurnManager turnManager;

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
        turnManager = FindObjectOfType<TurnManager>();

    }

    // Update is called once per frame
    public void PlayCard()
    {
        if (!hasBeenPlayed && !isBeingPlayed && GameController.player1ManaCount >= card.manaCost && turnManager.isMainPhase)
        {   
            GameController.player1ManaCount -= card.manaCost;
            
            UpdateManaText();
            isBeingPlayed = true;
            StartCoroutine(PlayedDelay());
            Debug.Log("Card played. New mana count:" + GameController.player1ManaCount);
        }
    }
    public void PlayLandCard()
    {
        if (!hasBeenPlayed && !isBeingPlayed && GameController.player1ManaCount >= card.manaCost && turnManager.isMainPhase && turnManager.canPlayLand)
        {
            GameController.player1ManaCount -= card.manaCost;

            UpdateManaText();
            isBeingPlayed = true;
            StartCoroutine(PlayedDelay());
            turnManager.canPlayLand = false;
            Debug.Log("Card played. New mana count:" + GameController.player1ManaCount);
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
        yield return new WaitForSeconds(1.5f);
        hasBeenPlayed = true;                    // was 0.5f but im adjusting it to be longer so
        isOnBattlefield = true;
        Debug.Log("Card played");                // the card is not instantly tapped after being played
    }

}