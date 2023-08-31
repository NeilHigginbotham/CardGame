using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Land : MonoBehaviour, IPointerClickHandler
{
    public CardDisplay card;

    public bool isCardTappedLand = false;


    void Start()
    {

    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (card.hasBeenPlayed == true && isCardTappedLand == false)
            {
                Debug.Log("Make one mana");
                isCardTappedLand = true;
            }
        }
    }
}