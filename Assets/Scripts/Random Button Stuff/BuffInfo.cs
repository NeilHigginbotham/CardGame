using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffInfo : MonoBehaviour
{
    private Button BuffDisplay;
    public string BuffInformationText;
    private GameObject BuffInformation;
    void Start()
    {
        BuffDisplay = GetComponent<Button>();
        BuffDisplay.onClick.AddListener(BuffDisplayMenu);

        BuffInformation = GameObject.Find(BuffInformationText);

        if (BuffInformation != null)
        {
            BuffInformation.SetActive(false);
        }
        else
        {
            Debug.LogWarning("BuffInformation not found with name: " + BuffInformationText);
        }
    }

    public void BuffDisplayMenu()
    {
        if (BuffInformation != null)
        {
            BuffInformation.SetActive(true);
            Debug.Log("BUFF ACTIVE");

            Invoke("DeactivateBuffInformation", 3f);
        }
    }



    private void DeactivateBuffInformation()
    {
        if (BuffInformation != null)
        {
            BuffInformation.SetActive(false);
            Debug.Log("BUFF DEACTIVATED");
        }
    }
}