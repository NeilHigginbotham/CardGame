using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    // WIP     Notes for this script. phases work great. they shift every 1f currently but I want them to end differently depending on the phase or maybe
    // just for simplicity every phase will be manually ended. this gets a lot more complicated if i add in instant speed stuff but perhaps
    // later it can be modified to work at instant speed.
    // 9/11/2023 look at the unity card games notes for info on player buttons that shift phases
    public bool isPlayer1Turn = true; // Flag to track the current player's turn
    private List<string> phases = new List<string> { "Untap", "Draw", "Main", "Attack", "End" };
    private int currentPhaseIndex = 0;
    bool buttonPressed = false;

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
                break;
            case "Draw":
                Debug.Log("Draw phase logic");
                HighlightButton(drawButton);
                break;
            // insert a draw function maybe from draw card code       Draw();
            case "Main":
                Debug.Log("Main phase logic");
                HighlightButton(mainButton);
                break;
            case "Attack":
                Debug.Log("Attack phase logic");
                HighlightButton(attackButton);
                break;
            case "End":
                Debug.Log("End phase logic");

                GameController.player1ManaCount = 0;  // Set the mana count to zero at the end of the turn
                player1manacounter.text = " " + GameController.player1ManaCount.ToString();
                break;
        }

        // Let the player take actions during the phase
        yield return StartCoroutine(PlayerActionsDuringPhase());


        /*
        // Move to the next phase
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;

        // Check if all phases are done and move to the next player's turn
        if (currentPhaseIndex == 0)
        {
            isPlayer1Turn = !isPlayer1Turn;
        }
        */ //TEST MOVING THIS TO START PHASE METHOD    A few bugs going on.
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

    public void PhaseButtonPressed()
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

        while (!buttonPressed)
        {
            // Check if the button is pressed
            if (Input.GetKeyDown(KeyCode.Z))
            {
                buttonPressed = true;
                currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;

                // Check if all phases are done and move to the next player's turn
                if (currentPhaseIndex == 0)
                {
                    isPlayer1Turn = !isPlayer1Turn;
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