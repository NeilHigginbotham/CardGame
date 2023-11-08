using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class EnterMap : MonoBehaviour
{
    public Button mapButton;

    void Start()
    {
        mapButton.onClick.AddListener(EnterGameMap);
    }

    public void EnterGameMap()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Scenechange");
    }
}