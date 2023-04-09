using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using UnityEngine.UI;

public class ManagerItem : Singleton<ManagerItem>
{
    public int coins;

    [Header("Coins")]
    public int currentCoins;
    public TMP_Text uiTextCoins;

    private void Start()
    {
        Reset();
    }

    public void AddCoin()
    {
        currentCoins++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextCoins.text = currentCoins.ToString();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        
    }
   
}
