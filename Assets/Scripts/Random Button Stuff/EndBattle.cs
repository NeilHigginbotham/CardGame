using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class EndBattle : MonoBehaviour
{
    public TextMeshProUGUI aiLifeTotalNumber;
    public TextMeshProUGUI playerLifeTotalNumber;


    // Update is called once per frame
    
    void Update()
    {
        if (int.TryParse(aiLifeTotalNumber.text, out int textValue))
        {
            if (textValue == 0)
            {
                AiLoss();
            }
        }

        if (int.TryParse(playerLifeTotalNumber.text, out int textValue2))
        {
            if (textValue2 == 0)
            {
                PlayerLoss();
            }
        }
    }

    void PlayerLoss()
    {
        SceneManager.LoadScene(3);
        // Enter defeat screen
    }

    void AiLoss()
    {
        SceneManager.LoadScene(4);
        //Enter victory screen
    }
}
