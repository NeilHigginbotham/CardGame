using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<CardDisplay> deck = new List<CardDisplay>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public TextMeshProUGUI deckSizeText;
    public static int player1ManaCount = 0;

    /*
    private void Awake()
    {
        // Keeps game manager across scenes
        DontDestroyOnLoad(gameObject);

        // Designates event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the player1ManaCount
        player1ManaCount = 0;
        Debug.Log("mana count reset");
    } */

    private void Start()
    {
        // Sets variable for starting hand card draw
        DrawStartingCards(7);

        // Hopefully sets our variable to 0 everytime we enter play mode
        player1ManaCount = 0;
    }


    public void DrawCard()
    {
        //  If the deck has cards, randomly look through the list and find one
        //  Then enable the card, update position, and remove from the deck
        if (deck.Count >= 1)
        {
            CardDisplay randCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    randCard.GameObject().SetActive(true);
                    randCard.handIndex = i;
                    randCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    private void Update()
    {
        // Counts cards in deck
        deckSizeText.text = deck.Count.ToString();
    }

    public void DrawStartingCards(int numCards)
    {
        // Loop that draws cards until we have 7 cards
        for (int drawCount = 0; drawCount < numCards; drawCount++)
        {
            if (deck.Count >= 1)
            {
                CardDisplay randCard = deck[Random.Range(0, deck.Count)];

                for (int i = 0; i < availableCardSlots.Length; i++)
                {
                    if (availableCardSlots[i])
                    {
                        randCard.gameObject.SetActive(true);
                        randCard.handIndex = i;
                        randCard.transform.position = cardSlots[i].position;
                        availableCardSlots[i] = false;
                        deck.Remove(randCard);
                        break;



                    } 
                }
            }
        }
    }
}
