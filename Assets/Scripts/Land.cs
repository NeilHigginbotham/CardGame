using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Land : MonoBehaviour, IPointerClickHandler
{
    public CardDisplay card;

    private TextMeshProUGUI player1manacounter;
    public bool isCardTappedLand = false;
    


    void Start()
    {
        // Get our reference for the mana counter
        player1manacounter = GameObject.Find("player1manacounter").GetComponent<TextMeshProUGUI>();

        // Default text update
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (card.hasBeenPlayed == true && isCardTappedLand == false)
            {
                // If the land has been played and is untapped then we will make one mana.
                isCardTappedLand = true;
                GameController.player1ManaCount++;
                UpdateText();
                Debug.Log("land produces mana");
            }
        }
    }
    public void UpdateText()
    {
        player1manacounter.text = "x " + GameController.player1ManaCount.ToString();
    }

    public IEnumerator ManaUnTap() // Trying to set the bool and make the logic understand that the land is untapped
    {
        yield return new WaitForSeconds(0.1f);
        if (card.isOnBattlefield == true)
        {
            isCardTappedLand = false;
            Debug.Log("lands untapped");
        }
        else
        {
            card.isOnBattlefield = false;
        }
    }
}