using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public Text healthUI;

    public Text coinNumUI;

    public Text endMessage;

    private void Awake()
    {
        _instance = this;
    }

    public void ChangeHealth(int amount)
    {
        healthUI.text = "X " + amount;
    }

    public void ChangeCoinNum(int amount)
    {
        coinNumUI.text = "X " + amount;
    }

    public void ShowEndMessage()
    {
        endMessage.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        LevelLoader._instance.LoadNextLevel();
    }
}
