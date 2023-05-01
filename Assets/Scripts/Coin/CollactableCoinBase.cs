using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemType
{
    COIN,
    POTION
}
public class CollactableCoinBase : CollactableItemBase
{
    [SerializeField] private ItemType itemType;

    public Collider2D collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        if (itemType == ItemType.COIN)
        {
            ManagerItem.Instance.AddCoins();
        }
        else if (itemType == ItemType.POTION)
        {
            ManagerItem.Instance.AddPotions();
        }

        collider.enabled = false;
    }
}
