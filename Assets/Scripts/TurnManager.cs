using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // WIP     Notes for this script. phases work great. they shift every 1f currently but I want them to end differently depending on the phase or maybe
    // just for simplicity every phase will be manually ended. this gets a lot more complicated if i add in instant speed stuff but perhaps
    // later it can be modified to work at instant speed.

    /*
    private bool isPlayer1Turn = true; // Flag to track the current player's turn
    private List<string> phases = new List<string> { "Untap", "Upkeep", "Draw", "Main", "Attack", "Secondmain", "End" };
    private int currentPhaseIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game with Player 1's turn
        StartCoroutine(StartPlayerTurn());
    }

    // Coroutine to start a player's turn
    IEnumerator StartPlayerTurn()
    {
        string currentPlayerName = isPlayer1Turn ? "Player 1" : "Player 2";
        Debug.Log($"{currentPlayerName}'s Turn - {phases[currentPhaseIndex]} Phase");

        // Add any phase-specific logic here
        switch (phases[currentPhaseIndex])
        {
            case "Untap":
                Debug.Log("Untap phase logic");
                break;
            case "Upkeep":
                Debug.Log("Upkeep phase logic       Insert logic for the phases at some point like untap and draw");
                break;
            case "Draw":
                Debug.Log("Draw phase logic");
                break;
            case "Main":
                Debug.Log("Main phase logic");
                break;
            case "Attack":
                Debug.Log("Attack phase logic");
                break;
            case "Secondmain":
                Debug.Log("Secondmain phase logic");
                break;
        }

        // Let the player take actions during the phase
        yield return StartCoroutine(PlayerActionsDuringPhase());

        // Move to the next phase
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;

        // Check if all phases are done and move to the next player's turn
        if (currentPhaseIndex == 0)
        {
            isPlayer1Turn = !isPlayer1Turn;
        }

        StartCoroutine(StartPlayerTurn());
    }

    // Coroutine for player actions during a phase
    IEnumerator PlayerActionsDuringPhase()
    {
        bool phaseCompleted = false;

        // Display instructions to the player and wait for their actions
        Debug.Log("Perform your actions for this phase...");
        // You can implement player input and actions here

        // For the sake of example, let's wait for a few seconds
        yield return new WaitForSeconds(1f);

        phaseCompleted = true;

        // Wait until the player has completed their actions
        while (!phaseCompleted)
        {
            yield return null;
        }
    }*/
}