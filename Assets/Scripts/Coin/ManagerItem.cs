using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ManagerItem : Singleton<ManagerItem>
{
    public SOInt coins;

    
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

   

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();

    }
   
}
