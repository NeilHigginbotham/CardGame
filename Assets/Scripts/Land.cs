using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Land : MonoBehaviour, IPointerClickHandler
{
    public CardDisplay card;

    private Text player1manacounter;
    private int player1manacount = 0;
    public bool isCardTappedLand = false;


    void Start()
    {
        //Player1Mana = GameObject.Find("Player1Mana");
        player1manacounter = GameObject.Find("player1manacounter").GetComponent<UnityEngine.UI.Text>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (card.hasBeenPlayed == true && isCardTappedLand == false)
            {
                // If the land has been played and is untapped then we will make one mana.
                Debug.Log("Make one mana");
                isCardTappedLand = true;
                ManaGain();
            }
        }
    }
    public void ManaGain()
    {
        player1manacount++;
        UpdateText();
    }
    private void UpdateText()
    {
        player1manacounter.text = "player1mana" + player1manacount.ToString();
    }
}