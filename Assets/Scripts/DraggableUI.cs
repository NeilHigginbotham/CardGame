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

    public CardDisplay card;
    public bool hasBeenPlayed;

    private void Start()
    {
        // Not necessary because script is alrady on object I guess.
        // ->    card = FindObjectOfType<CardDisplay>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        mainCamera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (card.hasBeenPlayed == true)
        {
            // Rotate the UI object by 90 degrees
            rectTransform.Rotate(Vector3.forward, 90f);
            Debug.Log("Tapped object and rotated.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            Vector2 anchoredPosition = localPoint - offset;
            Vector2 scaledAnchoredPosition = anchoredPosition / canvas.scaleFactor;

            rectTransform.anchoredPosition = scaledAnchoredPosition;
        }
    } 
}