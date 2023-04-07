using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class ManagerItem : Singleton<ManagerItem>
{
    public int coins;

    private void Start()
    {
        Reset();
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
