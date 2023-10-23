using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancePhase : MonoBehaviour
{
    public TurnManager turnManager; // TurnManager script reference

    private Button advanceButton; // Reference to the button component
   

    void Start()
    {
        advanceButton = GetComponent<Button>();

        advanceButton.onClick.AddListener(AdvanceToPhase);
    }

    // Update is called once per frame
    void Update()
    {
        advanceButton.interactable = turnManager.isPlayer1Turn;
    }

    private void AdvanceToPhase()
    {
        turnManager.StartNextPhase();
    }
}
