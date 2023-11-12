using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    // WIP     Notes for this script. phases work great. they shift every 1f currently but I want them to end differently depending on the phase or maybe
    // just for simplicity every phase will be manually ended. this gets a lot more complicated if i add in instant speed stuff but perhaps
    // later it can be modified to work at instant speed.
    // 9/11/2023 look at the unity card games notes for info on player buttons that shift phases
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

    public bool isMainPhase = false; // Bool that determines whether it is the main phase or not

    public bool canPlayLand = true; //WIP

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
                controller.DrawCard();
                break;
            // insert a draw function maybe from draw card code       Draw();
            case "Main":
                Debug.Log("Main phase logic");
                HighlightButton(mainButton);
                isMainPhase = true;
                break;
            case "Attack":
                Debug.Log("Attack phase logic");
                HighlightButton(attackButton);
                isMainPhase = false;
                break;
            case "End":
                Debug.Log("End phase logic");

                GameController.player1ManaCount = 0;  // Set the mana count to zero at the end of the turn
                player1manacounter.text = " " + GameController.player1ManaCount.ToString();
                HighlightButton(endButton);
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

    public void PhaseButtonPressed() //The button isn't currently used because we are instead letting the "Z" key progress the phases
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