using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerClickHandler
// This script enables draggable UI using Unity Interfaces that account for the pointer's position.
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Camera mainCamera;
    private Vector2 offset;
    public bool isCardTapped = false;
    public bool isDragged = false;
    public bool isRightClickDown = false;


    public Land land;
    public CardDisplay card;

    private void Start()
    {
        // Not necessary because script is alrady on object I guess. Could be useful for another object.
        // ->    card = FindObjectOfType<CardDisplay>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        mainCamera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Works with the OnDrag method.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mouse drag moves the UI elements.
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint) & card.hasBeenPlayed == true)
        {
            Vector2 anchoredPosition = localPoint - offset;
            Vector2 scaledAnchoredPosition = anchoredPosition / canvas.scaleFactor;

            rectTransform.anchoredPosition = scaledAnchoredPosition;
            isDragged = true;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (card.hasBeenPlayed == true & isCardTapped == false)
            {
                if (!isDragged)
                {
                    StartCoroutine(Tap());
                }
                else
                {
                    isDragged = false;
                }
            }
            /* preserving code for tests. trying to make the untap phase do this logic automatically to untap cards on the battlefield.
            if (card.hasBeenPlayed == true & isCardTapped == true)
            {
                StartCoroutine(UnTap());
            }*/
        }
    }
    public IEnumerator Tap()
    { 

        // Delay for a short period (adjust the delay as needed)
        yield return new WaitForSeconds(0.1f);

        // Rotate the UI object by 90 degrees and render the card visually "tapped"
        rectTransform.Rotate(Vector3.back, 90f);

        // Card tapped bool state
        isCardTapped = true;
    }
    public IEnumerator UnTap()  // Untap the card if it is on the battlefield. This triggers in the TurnManager Untap Step
    {
        yield return new WaitForSeconds(0.1f);
        if (card.isOnBattlefield == true & isCardTapped == true)
        {
            // Rotate the UI object by 90 degrees and render the card visually "untapped"
            rectTransform.Rotate(Vector3.forward, 90f);

            // Card untapped bool state
            isCardTapped = false;
        }
        else
        {
            card.isOnBattlefield = false;
        }
    }

    public IEnumerator ManaUnTap() // Trying to set the bool and make the logic understand that the land is untapped
    {
        yield return new WaitForSeconds(0.1f);
        if (card.isOnBattlefield == true)
        {
            land.isCardTappedLand = false;
        }
        else // Not sure if this else statement will work properly
        {
            land.isCardTappedLand = true;
        }
    }


}