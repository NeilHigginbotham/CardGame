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
        // Works with the OnDrag method.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (card.hasBeenPlayed == true & isCardTapped == false)
        {
            if (!isDragged)
            {
                StartCoroutine(TapAfterPlay());
            }
            else
            {
                isDragged = false;
            }
        }
        if (card.hasBeenPlayed == true & isCardTapped == true)
        {
            StartCoroutine(UnTapAfterPlay());
        }
    }
    private IEnumerator TapAfterPlay()
    {
        // Delay for a short period (adjust the delay as needed)
        yield return new WaitForSeconds(0.1f);

        // Rotate the UI object by 90 degrees
        rectTransform.Rotate(Vector3.back, 90f);

        // Reset the flag
        isCardTapped = true;
    }
    private IEnumerator UnTapAfterPlay()
    {
        // Delay for a short period (adjust the delay as needed)
        yield return new WaitForSeconds(0.1f);

        // Rotate the UI object by 90 degrees
        rectTransform.Rotate(Vector3.forward, 90f);

        // Reset the flag
        isCardTapped = false;
    }
}