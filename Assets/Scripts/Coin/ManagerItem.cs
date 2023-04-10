using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using UnityEngine.UI;

public class ManagerItem : Singleton<ManagerItem>
{
    public int coins;

    
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

   

    private void UpdateUI()
    {
        uiTextCoins.text = coins.ToString();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();

    }
   
}
