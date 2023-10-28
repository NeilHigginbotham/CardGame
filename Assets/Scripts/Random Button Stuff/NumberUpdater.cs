using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberUpdater : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public Button decreaseButton;
    public Button increaseButton;

    private int currentNumber = 20;
    void Start()
    {
        decreaseButton.onClick.AddListener(DecreaseNumber);
        increaseButton.onClick.AddListener(IncreaseNumber);
        UpdateNumberText();
    }

    void IncreaseNumber()
    {
        currentNumber++;
        UpdateNumberText();
    }
    void DecreaseNumber()
    {
        currentNumber--;
        UpdateNumberText();
    }

    void UpdateNumberText()
    {
        numberText.text = "" + currentNumber;
    }
}
