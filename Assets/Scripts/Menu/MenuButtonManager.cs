using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = 1f;
    public float delay = 0.5f;
    public Ease ease = Ease.OutBack;

    private void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
        
    }

    private void HideAllButtons()
    {
        foreach (var a in buttons)
        {
            a.transform.localScale = Vector3.zero;
            a.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            var a = buttons[i];
            a.SetActive(true);
            a.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);
        }
    }
}
