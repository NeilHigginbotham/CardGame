using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterBattle : MonoBehaviour
{
    public Button phynissaButton;
    void Start()
    {
        phynissaButton.onClick.AddListener(EnterNissaBattle);
    }

    void EnterNissaBattle()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Battle Entered");
    }
}
