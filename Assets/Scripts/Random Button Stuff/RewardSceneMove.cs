using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardSceneMove : MonoBehaviour
{
    public Button rewardButton1;
    public Button rewardButton2;
    public Button rewardButton3;
    void Start()
    {
        rewardButton1.onClick.AddListener(PostWinScreen);
        rewardButton2.onClick.AddListener(PostWinScreen);
        rewardButton3.onClick.AddListener(PostWinScreen);
    }

    void PostWinScreen()
    {
        SceneManager.LoadScene(5);
        Debug.Log("Post Win Screen Enter");
    }
}
