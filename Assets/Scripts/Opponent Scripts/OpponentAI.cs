using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentAI : MonoBehaviour
{

    public Image AiLand;
    public Image AiLandZone;
    public Transform[] landSlots;
    public bool[] availableLandSlots;
    public Button AiCreature;
    public Image AiCreatureZone;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AiPlayCreature()
    {
        RectTransform rectTransform = AiCreatureZone.GetComponent<RectTransform>();

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPos, Camera.main, out worldPos);

        Button CreatureInstance = Instantiate(AiCreature, worldPos, Quaternion.identity);

        float scaleFactor = 1.0f; // Adjust this value based on your preference
        CreatureInstance.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);

        CreatureInstance.transform.SetParent(AiCreatureZone.transform, false);

    }
    public void AiPlays()
    {
        RectTransform rectTransform = AiLandZone.GetComponent<RectTransform>();

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPos, Camera.main, out worldPos);

        {
            for (int i = 0; i < availableLandSlots.Length; i++)
            {
                if (availableLandSlots[i] == true)
                {
                    // Instantiate AiLand at the calculated world position
                    Image aiLandInstance = Instantiate(AiLand, worldPos, Quaternion.identity);

                    float scaleFactor = 10.0f; // Adjust this value based on your preference
                    aiLandInstance.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);


                    // Make the land go to the position of its chosen slot.
                    aiLandInstance.transform.position = landSlots[i].position;
                    availableLandSlots[i] = false;
                    // Set the parent of the instantiated object to AiLandZone
                    aiLandInstance.transform.SetParent(AiLandZone.transform, false);

                    if (CountInstantiatedCards() >= 2)
                    {
                        AiPlayCreature();
                        Debug.Log("AiLand PLAYS CREATURE");
                    }

                    return;     // Not sure if return is needed.
                }
            }
        }
    }
    private int CountInstantiatedCards()
    {
        int count = 0;
        foreach (var slot in availableLandSlots)
        {
            if (!slot)
            {
                count++;
            }
        }
        return count;
    }
}
