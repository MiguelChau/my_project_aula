using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollactableCoinBase : CollactableItemBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ManagerItem.Instance.AddCoins();
    }
}
