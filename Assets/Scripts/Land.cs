using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Land : MonoBehaviour, IPointerClickHandler
{
    public CardDisplay card;

    GameObject Player1Mana;
    //public GameObject Player1Mana;
    public bool isCardTappedLand = false;


    void Start()
    {
        Player1Mana = GameObject.Find("Player1Mana");
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
                Player1Mana.SetActive(false);

            }
        }
    }
}