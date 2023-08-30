using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardZoom : MonoBehaviour, IPointerDownHandler
{
    public GameObject tempenlargedobject;
    private GameObject instantiatedEnlargedObject;
    public float scaleFactor = 2.0f;

    public Vector3 offset = new Vector3(0f, 0f, 1f);
    public float yOffset = 0.5f;

    private Canvas canvas;

    public void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    public void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (instantiatedEnlargedObject != null)
            {
                Destroy(instantiatedEnlargedObject);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 cardPosition = transform.position + new Vector3(0f, yOffset, 0f); ;
            instantiatedEnlargedObject = Instantiate(tempenlargedobject, cardPosition, Quaternion.identity);
            instantiatedEnlargedObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            //instantiatedEnlargedObject.transform.SetParent(transform);
            instantiatedEnlargedObject.transform.SetParent(canvas.transform);
        }
    }
}