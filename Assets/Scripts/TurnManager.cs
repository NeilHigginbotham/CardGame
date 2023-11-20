using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public bool isPlayer1Turn = true; // Flag to track the current player's turn
    private List<string> phases = new List<string> { "Untap", "Draw", "Main", "Attack", "End" };
    private int currentPhaseIndex = 0;
    //bool buttonPressed = false;

    // Allows us to designate a group of objects to activate the coroutine on.
    public DraggableUI[] untappableCards;
    public Land[] unmanatappableCards;     

    private TextMeshProUGUI player1manacounter; // Reference to the mana text UI element

    public Button advanceButton;

    public Button untapButton;
    public Button drawButton;
    public Button mainButton;
    public Button attackButton;
    public Button endButton;

    public GameController controller;
    public OpponentAI OppAi;

    public bool isMainPhase = false; // Bool that determines whether we can play cards or not
    public bool isAttackPhase = false; // Bool that determines whether we can attack or not

    public bool canPlayLand = true;
    public bool phaseReady = true;
    public bool isPlayerTurn = true;
    public bool isAITurn = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game with Player 1's turn
        StartCoroutine(StartPlayerTurn());

        player1manacounter = GameObject.Find("player1manacounter").GetComponent<TextMeshProUGUI>(); // Statement allowing us to manipulate the mana text
    }

    // Coroutine to start a player's turn
    IEnumerator StartPlayerTurn()
    {
        string currentPlayerName = isPlayer1Turn ? "Player 1" : "Player 2";
        Debug.Log($"{currentPlayerName}'s Turn - {phases[currentPhaseIndex]} Phase");

        // Add any phase-specific logic here in the future
        switch (phases[currentPhaseIndex])
        {
            case "Untap":
                Debug.Log("Untap phase logic");
                TriggerUntapCoroutineOnAllCards(); // Trigger untap on our stuff
                TriggerManaUntapCoroutineOnAllCards(); // Tells our lands they can make mana again
                HighlightButton(untapButton);
                canPlayLand = true;
                break;
            case "Draw":
                Debug.Log("Draw phase logic");
                HighlightButton(drawButton);

                if (isPlayerTurn)
                {
                    controller.DrawCard();
                }

                break;
            case "Main":
                Debug.Log("Main phase logic");
                HighlightButton(mainButton);

                isMainPhase = true;

                if (isAITurn)
                {
                    OppAi.AiPlayLand();
                }

                break;
            case "Attack":
                Debug.Log("Attack phase logic");
                HighlightButton(attackButton);
                isMainPhase = false;
                isAttackPhase = true;
                /* isAttackPhase = true;
                phaseReady = false;
                // Insert way to initiatize and complete the attacking in Combat manager here. Upon completion of combat, the phaseReady bool
                // will change and we can move to the end step.
                */
                break;
            case "End":
                Debug.Log("End phase logic");
                isAttackPhase = false;
                if (isPlayerTurn)
                {
                    isAITurn = true;
                    isPlayerTurn = false;
                }
                else
                {
                    isAITurn = false;
                    isPlayerTurn = true;
                }
                
                GameController.player1ManaCount = 0;  // Set the mana count to zero at the end of the turn
                player1manacounter.text = " " + GameController.player1ManaCount.ToString();
                HighlightButton(endButton);
                break;
        }

        // Let the player take actions during the phase
        yield return StartCoroutine(PlayerActionsDuringPhase());

        /*
        //
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;
        
        // Check if all phases are done and move to the next player's turn. The player turns are tracked by the following logic.
        if (currentPhaseIndex == 0)
        {
            isPlayer1Turn = !isPlayer1Turn;
        }
        */
        StartCoroutine(StartPlayerTurn());
        
    }

    /*
    public void StartNextPhase()
    {
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;

        // Check if all phases are done and move to the next player's turn
        if (currentPhaseIndex == 0)
        {
            isPlayer1Turn = !isPlayer1Turn;
        }
    }*/

    public void PhaseButtonPressed() //The button isn't currently used because we are instead letting the "Z" key progress the phases.
        // But it could be used so there are additional controls in the game.
    {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
        bool buttonPressed = true;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
    }


    // Coroutine for player actions during a phase
    IEnumerator PlayerActionsDuringPhase()
    {
        bool phaseCompleted = false;

        // Display instructions to the player and wait for their actions
        Debug.Log("Perform your actions for this phase...");

        bool buttonPressed = false;

        while (!buttonPressed & phaseReady)
        {
            // Check if the button is pressed
            if (Input.GetKeyDown(KeyCode.Z))
            {
                buttonPressed = true;
                currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;

                // Check if all phases are done and move to the next player's turn
                if (currentPhaseIndex == 0)
                {
                    isPlayer1Turn = !isPlayer1Turn; // Determine if it is player1's turn

                    ResetButtonColors();  // Reset the button at at the end of phase
                }
            }

            yield return null;
        }

        // Pause for a few seconds
        // yield return new WaitForSeconds(2f);
        // ^ Useful if we want to test speeding through phases.
        phaseCompleted = true;

        // Wait until the player has completed their actions
        while (!phaseCompleted)
        {
            yield return null;
        }
    }
    private void HighlightButton(Button buttonToHighlight)
    {
        ColorBlock colors = buttonToHighlight.colors;
        colors.normalColor = Color.black;
        buttonToHighlight.colors = colors;
    }
    private void ResetButtonColors()
    {
        // Reset all button colors to their default values
        ColorBlock colors;

        colors = untapButton.colors;
        colors.normalColor = Color.white; 
        untapButton.colors = colors;

        colors = drawButton.colors;
        colors.normalColor = Color.white; 
        drawButton.colors = colors;

        colors = mainButton.colors;
        colors.normalColor = Color.white; 
        mainButton.colors = colors;

        colors = attackButton.colors;
        colors.normalColor = Color.white; 
        attackButton.colors = colors;

        colors = endButton.colors;
        colors.normalColor = Color.white; 
        endButton.colors = colors;
    }
    public void StartNextPhase()
    {
        Debug.Log("A");
    }
    private void TriggerUntapCoroutineOnAllCards()
    {
        foreach (var obj in untappableCards)
        {
            StartCoroutine(obj.UnTap());

        }
    }

    private void TriggerManaUntapCoroutineOnAllCards()
    {
        foreach (var obj in unmanatappableCards)
        {
            StartCoroutine(obj.ManaUnTap());

        }
    }
}