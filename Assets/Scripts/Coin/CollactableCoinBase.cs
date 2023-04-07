using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableCoinBase : CollactableItemBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ManagerItem.Instance.AddCoins();
    }
}
