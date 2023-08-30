using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PhaseManager : MonoBehaviour
{
    public Button untapButton;
    public Button upkeepButton;
    public Button drawButton;
    public Button mainButton;
    public Button attackButton;
    public Button secondmainButton;
    public Button endButton;

    private GamePhase currentPhase;
    private void Start()
    {
        // Start game phase
        currentPhase = GamePhase.Untap;
        HighlightButton(untapButton);

        untapButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.Untap));
        upkeepButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.Upkeep));
        drawButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.Draw));
        mainButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.Main));
        attackButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.Attack));
        secondmainButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.SecondMain));
        endButton.onClick.AddListener(() => SetCurrentPhase(GamePhase.End));


    }
 
    public void SetCurrentPhase(GamePhase newPhase)
    {
        currentPhase = newPhase;

        // Update the highlighted button based on the current phase
        switch (currentPhase)
        {
            case GamePhase.Untap:
                HighlightButton(untapButton);
                break;
            case GamePhase.Upkeep:
                HighlightButton(upkeepButton);
                break;
            case GamePhase.Draw:
                HighlightButton(drawButton);
                break;
            case GamePhase.Main:
                HighlightButton(mainButton);
                break;
            case GamePhase.Attack:
                HighlightButton(attackButton);
                break;
            case GamePhase.SecondMain:
                HighlightButton(secondmainButton);
                break;
            case GamePhase.End:
                HighlightButton(endButton);
                break;
            default:
                break;
        }
    }
    private void ResetButtonOutlines()
    {
        // Reset all buttons' outlines to default values
        untapButton.GetComponent<Outline>().effectColor = Color.clear;
        upkeepButton.GetComponent<Outline>().effectColor = Color.clear;
        drawButton.GetComponent<Outline>().effectColor = Color.clear;
        mainButton.GetComponent<Outline>().effectColor = Color.clear;
        attackButton.GetComponent<Outline>().effectColor = Color.clear;
        secondmainButton.GetComponent<Outline>().effectColor = Color.clear;
        endButton.GetComponent<Outline>().effectColor = Color.clear;
    }
    private void HighlightButton(Button buttonToHighlight)
    {
        // Reset all buttons' outlines to default values
        ResetButtonOutlines();

        // Set the outline color of the highlighted button to black
        buttonToHighlight.GetComponent<Outline>().effectColor = Color.black;
        /*
        // Reset all buttons' outlines to default values
        untapButton.GetComponent<Outline>().effectColor = Color.clear;
        upkeepButton.GetComponent<Outline>().effectColor = Color.clear;
        drawButton.GetComponent<Outline>().effectColor = Color.clear;
        mainButton.GetComponent<Outline>().effectColor = Color.clear;
        attackButton.GetComponent<Outline>().effectColor = Color.clear;
        secondmainButton.GetComponent<Outline>().effectColor = Color.clear;
        endButton.GetComponent<Outline>().effectColor = Color.clear;

        // Set the outline color of the highlighted button to black
        buttonToHighlight.GetComponent<Outline>().effectColor = Color.black;
        */
    }
}

public enum GamePhase
{
    Untap,
    Upkeep,
    Draw,
    Main,
    Attack,
    SecondMain,
    End
}
