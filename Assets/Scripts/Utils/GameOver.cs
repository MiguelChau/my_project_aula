using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject uiGameOverScreen;
    public AudioSource audioSourceGameOver;
   

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            ShowGameOverScreen();
        }
    }

    public void ShowGameOverScreen()
    {
        if (audioSourceGameOver != null) audioSourceGameOver.Play();
        uiGameOverScreen.SetActive(true);
              

        gameObject.SetActive(true);
    }

    public void HideGameOverScreen()
    {
       
        gameObject.SetActive(false);
    }

}


