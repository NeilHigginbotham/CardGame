using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentAI : MonoBehaviour
{

    public Image AiLand;
    public Image AiLandZone;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void AiPlayLand()
    {
        RectTransform rectTransform = AiLandZone.GetComponent<RectTransform>();

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPos, Camera.main, out worldPos);

        // Instantiate AiLand at the calculated world position
        Image aiLandInstance = Instantiate(AiLand, worldPos, Quaternion.identity);

        float scaleFactor = 10.0f; // Adjust this value based on your preference
        aiLandInstance.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);

        // Set the parent of the instantiated object to AiLandZone
        aiLandInstance.transform.SetParent(AiLandZone.transform, false);


        //Instantiate(AiLand, AiLandZone, Quaternion.identity);
    }
}
