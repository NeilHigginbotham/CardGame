using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<CardDisplay> deck = new List<CardDisplay>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public TextMeshProUGUI deckSizeText;

    private void Start()
    {
        // Draw 7 cards at the start of the game
        DrawStartingCards(7);
    }


    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            CardDisplay randCard = deck[Random.Range(0, deck.Count)];

            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    randCard.GameObject().SetActive(true);
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
        deckSizeText.text = deck.Count.ToString();
    }

    public void DrawStartingCards(int numCards)
    {
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
